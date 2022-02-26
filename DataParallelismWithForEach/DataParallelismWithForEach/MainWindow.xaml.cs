using System;
using System.Drawing;
using System.Threading;
using System.IO;
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

namespace DataParallelismWithForEach
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Новая переменная уровня Window.
        private CancellationTokenSource cancelToken = new CancellationTokenSource();
        public MainWindow()
        {
            InitializeComponent();
        }
        public void cmdCancel_Click(object sender, EventArgs e)
        {
            // Используется для сообщения всем рабочим потокам о необходимости останова!
            cancelToken.Cancel();
        }
        public void cmdProcess__Click(object sender, EventArgs e)
        {
            ProcessFiles();
        }
        private void ProcessFiles()
        {
            // Использовать экземпляр ParallelOptions для хранения CancellationToken.
            ParallelOptions parOpts = new ParallelOptions();
            parOpts.CancellationToken = cancelToken.Token;
            parOpts.MaxDegreeOfParallelism = System.Environment.ProcessorCount;
            //Загрузить все файлы *.jpg и создать новый каталог для модифицированных данных.
            string[] files = Directory.GetFiles(@".\TestPictures", "*.jpg", SearchOption.AllDirectories);
            string newDir = @".\ModifiedPictures";
            Directory.CreateDirectory(newDir);
            try
            {
                // Обработать данные изображения в параллельном режиме!
                Parallel.ForEach(files, parOpts, currentFile =>
                {
                    parOpts.CancellationToken.ThrowIfCancellationRequested();
                    string filename = Path.GetFileName(currentFile);
                    using (Bitmap bitmap = new Bitmap(currentFile))
                    {
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        bitmap.Save(Path.Combine(newDir, filename));
                        this.Dispatcher.Invoke((Action)delegate
                        {
                            this.Title = $"Processing {filename} on thread { Thread.CurrentThread.ManagedThreadId}";
                            this.Dispatcher.Invoke((Action)delegate
                            {
                                this.Title = "Done!"; // Готово!
                            });
                        });
                    }
                });
            }
            catch (OperationCanceledException e)
            {
                this.Title = e.Message;
            }
        }
    }
}