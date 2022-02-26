using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FunWithCSharpAsync
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            List<int> list = default;
            string message = await DoWorkAsync();
            Console.WriteLine(message);
            Console.WriteLine("Завершен");
            Console.ReadKey();
        }
        public static string DoWork()
        {
            Thread.Sleep(5_000);
            return "Закончил работу";
        }
        public static async Task<string> DoWorkAsync()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(5_000);
                return "Закончил работу";
            });  
        }
        static async Task MethodWithProblems(int firstParam, int secondParam)
        {
            Console.WriteLine("Enter");
            if(secondParam < 0)
            {
                Console.WriteLine("Bad data");
                return;
            }
            actualImplementation();
            async Task actualImplementation()
            {
                await Task.Run(() =>
                {
                    // Вызвать длительно выполняющийся метод.
                    Thread.Sleep(4_000);
                    Console.WriteLine("First Complete");
                    // Вызвать еще один длительно выполняющийся метод, который терпит 
                    // неудачу из-за того, что значение второго параметра выходит 
                    //за пределы допустимого диапазона.
                    Console.WriteLine("Something bad happened");
                });
            }
        }
    }
}
