using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLINQDataProcessingWithCancellation
{
    internal class Program
    {
        static CancellationTokenSource cancelToken = new CancellationTokenSource();
        static void Main(string[] args)
        {
            do 
            {
                Console.WriteLine("Press any key to start processing");
                // Нажмите любую клавишу для начала обработки
                Console.ReadKey();
                Console.WriteLine("Processing");
                Task.Factory.StartNew(() => ProcessIntData());
                Console.Write("Enter Q to quit: ");
                // Введите Q для выхода:
                string answer = Console.ReadLine();
                // Желает ли пользователь выйти?
                if (answer.Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    cancelToken.Cancel();
                    break;
                }
            } while (true);
            Console.ReadLine();
        }
        static void ProcessIntData()
        {
            // Получить очень большой массив целых чисел
            int[] source = Enumerable.Range(0, 10_000_000).ToArray();

            // Найти числа, для которых истинно условие num % 3 == 0, и возвратить их в убывающем порядке.
            int[] modThreelsZero = null;
            try
            {
                modThreelsZero = (source.AsParallel().WithCancellation(cancelToken.Token).Where(s => s % 3 == 0).OrderByDescending(s => s)).ToArray();
                Console.WriteLine();
                Console.WriteLine("Кол-во чисел кратных 3:"+modThreelsZero.Count());
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}
