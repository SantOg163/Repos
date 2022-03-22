using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Ink;
using AutoLotDAL.Repos;

namespace WpfControlsAndAPIs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Установить режим Ink в качестве стандартного.
            this.MyInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            this.inkRadio.IsChecked = true;
            this.ComboColors.SelectedIndex = 0;
            SetBindings();
        }
        private void ConfigureGrid()
        {
            using(var repo = new InventoryRepo())
        }
        private void SetBindings()
        {
            // Создать объект Binding.
            Binding b = new Binding();
            // Зарегистрировать преобразователь, источник и путь.
            b.Converter = new MyDoubleConverter();
            b.Source = this.mySB;
            b.Path = new PropertyPath("Value");
            // Зарегистрировать преобразователь, источник и путь.
            this.labelSBThumb.SetBinding(Label.ContentProperty, b);
        }

        private void RadioButtonClicked(object sender, RoutedEventArgs e)
        {
            // В зависимости от того, какая кнопка отправила событие,  поместить InkCanvas в нужный режим оперирования.
            switch ((sender as RadioButton)?.Content.ToString())
            {
                // Эти строки должны совпадать со значениями свойства Content каждого элемента RadioButton
                case "Ink Mode":
                    this.MyInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
                    break;
                case "Erse Mode":
                    this.MyInkCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;
                case "Select Mode":
                    this.MyInkCanvas.EditingMode = InkCanvasEditingMode.Select;
                    break;
            }
        }

        private void ColorChanged(object sender, SelectionChangedEventArgs e)
        {
            // Получить выбранный элемент в раскрывающемся списке.
            string colorToUse = (this.ComboColors.SelectedItem as StackPanel)?.Tag.ToString();
            // Изменить цвет, используемый для визуализации штрихов.
            this.MyInkCanvas.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(colorToUse);
        }

        private void SaveData(object sender, RoutedEventArgs e)
        {
            // Сохранить все данные InkCanvas в локальном файле.
            using (FileStream fs = new FileStream("StrokeData.bin", FileMode.Create))
            {
                this.MyInkCanvas.Strokes.Save(fs);
                fs.Close();
            }
        }

        private void ClearData(object sender, RoutedEventArgs e)
        {
            // Очистить все штрихи.
            this.MyInkCanvas.Strokes.Clear();
        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream("StrokeData.bin", FileMode.Open, FileAccess.Read))
            {
                StrokeCollection strokes = new StrokeCollection(fs);
                this.MyInkCanvas.Strokes = strokes;
            }
        }
    }
}