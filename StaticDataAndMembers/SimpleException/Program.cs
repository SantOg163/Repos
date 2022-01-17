using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car SanT = new Car("Maru",60);
            SanT.Radio(true);
            try
            {     
                for (int i = 0; i < 10; i++)
                    SanT.Accelerate(10);
            }
            catch(Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Ошибка");
                Console.WriteLine();
                Console.WriteLine("Имя: " + e.TargetSite);
                Console.WriteLine("Класс: " + e.TargetSite.DeclaringType);
                Console.WriteLine("Тип: " + e.TargetSite.MemberType);
                Console.WriteLine("Сообщение: "+e.Message);
                Console.WriteLine("Источник: " + e.Source);
                Console.WriteLine("Стек: " + e.StackTrace);
                Console.WriteLine("HelpLink: " + e.HelpLink);
                foreach (DictionaryEntry de in e.Data)
                    Console.WriteLine($"{de.Key}: {de.Value}");
                NullReferenceException nullReEx = new NullReferenceException();
                Console.WriteLine("NullReferenceException - системная ошибка ?" + nullReEx is SystemException);
            }
            Console.ReadKey();
        }
    }
}
