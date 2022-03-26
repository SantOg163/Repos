using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Reflection;
using System.Xml;
using System.Windows.Markup;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TreesAndTemplatesApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Control _ctrlToExamine = null;
        string _dataToShow = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnShowLogicalTree_Click(object sender, RoutedEventArgs e)
        {
            _dataToShow = "";
            BuildLogicalTree(0, this);
            txtDisplayArea.Text = _dataToShow;
        }
        void BuildLogicalTree(int depth, object obj)
        {
            // Добавить имя типа к переменной-члену _dataToShow.
            _dataToShow += new string(' ', depth) + obj.GetType().Name + "\n";
            // Если элемент - не DependencyObject, тогда пропустить его.
            if (!(obj is DependencyObject))
                return;
            // Выполнить рекурсивный вызов для каждого логического дочернего элемента
            foreach (var child in LogicalTreeHelper.GetChildren((DependencyObject)obj))
                BuildLogicalTree(depth + 5, child);                
        }

        private void btnShowVisualTree_Click(object sender, RoutedEventArgs e)
        {
            _dataToShow = "";
            BuildVisualTree(0, this);
            txtDisplayArea.Text = _dataToShow;
        }
        void BuildVisualTree(int depth, DependencyObject obj)
        {
            // Добавить имя типа к переменной-члену _dataToShow.
            _dataToShow += new string(' ', depth) + obj.GetType().Name + "\n";
            // Выполнить рекурсивный вызов для каждого визуально дочернего элемента,
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
                BuildVisualTree(depth + 1, VisualTreeHelper.GetChild(obj, i));
        }
        private void btnTemplate_Click(object sender, RoutedEventArgs e)
        {
            _dataToShow = "";
            ShowTemplate();
            txtDisplayArea.Text = _dataToShow;
        }
        private void ShowTemplate()
        {
            if (_ctrlToExamine != null)
                stackTemplatePanel.Children.Remove(_ctrlToExamine);
            try
            {
                // Загрузить PresentationFramework и создать экземпляр
                // указанного элемента управления. Установить его размеры для
                // отображения, а затем добавить в пустой контейнер StackPanel.
                Assembly asm = Assembly.Load("PresentationFramework, Version=4.0.0.0, " +
                "Culture = neutral, PublicKeyToken = 31bf3856ad364e35");
                _ctrlToExamine = (Control)asm.CreateInstance(txtFullName.Text);
                _ctrlToExamine.Height = 200;
                _ctrlToExamine.Width = 200;
                _ctrlToExamine.Margin = new Thickness(5);
                stackTemplatePanel.Children.Add(_ctrlToExamine);
                // Определить настройки XML для предохранения отступов,
                var xmlSettings = new XmlWriterSettings { Indent = true };
                // Создать объект StringBuilder для хранения разметки XAML.
                var strBuilder = new StringBuilder();
                // Создать объект XmlWriter на основе имеющихся настроек.
                var xWriter = XmlWriter.Create(strBuilder, xmlSettings);
                // Сохранить разметку XAML в объекте XmlWriter на основе ControlTemplate.
                XamlWriter.Save(_ctrlToExamine.Template, xWriter);
                // Отобразить разметку XAML в текстовом поле.
                _dataToShow = strBuilder.ToString();

            }
            catch (Exception ex)
            { _dataToShow = ex.Message; }
        }

    }
}
