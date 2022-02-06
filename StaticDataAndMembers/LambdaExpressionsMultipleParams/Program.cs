using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressionsMultipleParams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            // Зарегистрировать делегат как лямбда-выражение.
            SimpleMath m = new SimpleMath();
            m.SetMathHandler ((msg, result) => { Console.WriteLine("Message: {0}, Result: {1}", msg, result); });
            // Это приведет к выполнению лямбда-выражения,
            m.Add(10, 10);
            m.SetMathHandler((msg,result) => { Console.WriteLine(result+" "+msg); });
            Console.ReadKey();
        }
    }
}
