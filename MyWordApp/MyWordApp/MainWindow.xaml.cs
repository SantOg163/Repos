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
using Microsoft.Win32;

namespace MyWordApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetF1CommandBinding();
        }
        private void SetF1CommandBinding()
        {
            CommandBinding helpBinding = new CommandBinding(ApplicationCommands.Help);
            helpBinding.CanExecute += CanHelpExecute;
            helpBinding.Executed += HelpExecuted;
            CommandBindings.Add(helpBinding);
        }
        private void CanHelpExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // Если нужно предотвратить выполнение команды, то можно установить CanExecute в false.
            e.CanExecute = true;
        }
        private void HelpExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Look, it is not that difficult. Just type something!","Help!");
        }
        protected void FileExit_Click(object sender, RoutedEventArgs e)
        {
            //закрыть окно
            this.Close();
        }
        protected void ToolsSpellingHints_Click(object sender, RoutedEventArgs e)
        {
            string spellingHints =string.Empty;
            // Попробовать получить ошибку правописания в текущем положении курсора ввода.
            SpellingError error = txtData.GetSpellingError(txtData.CaretIndex);
            if (error != null)
            {
                // Построить строку с предполагаемыми вариантами правописания.
                foreach (string s in error.Suggestions)
                    spellingHints += $"{s}\n";
                // Отобразить предполагаемые варианты и раскрыть элемент Expander.
                lblSpellingHints.Content = spellingHints;
                expanderSpelling.IsExpanded = true;
            }
        }

        private void MouseEnterExitArea(object sender, MouseEventArgs e)
        {
            statBarText.Text = "Exit the Application"; 
        }
        private void MouseEnterToolsHintsArea(object sender, MouseEventArgs e)
        {
            statBarText.Text = "Show Spelling Suggestions";
        }
        private void MouseLeaveArea(object sender, MouseEventArgs e)
        {
            statBarText.Text = "Ready";
        }

        private void OpenCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            // Создать диалоговое окно открытия файла и показать в нем только текстовые файлы.
            var openDlg = new OpenFileDialog { Filter = "Text Files |*.txt"};
            // Был ли совершен щелчок на кнопке ОК?
            if(openDlg.ShowDialog() == true)
            {
                // Загрузить содержимое выбранного файла.
                string dataFromFile = File.ReadAllText(openDlg.FileName);
                // Отобразить строку в TextBox.
                txtData.Text = dataFromFile;
            }
        }

        private void SaveCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var saveDlg = new SaveFileDialog { Filter = "Text Files |*.txt" };
            // Был ли совершен щелчок на кнопке ОК?
            if (saveDlg.ShowDialog() == true)
            {
                // Сохранить данные из TextBox в указанном файле.
                File.WriteAllText(saveDlg.FileName, txtData.Text);
            }
        }

        private void OpenCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
