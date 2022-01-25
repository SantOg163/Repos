using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceNameClash
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Octagon octagon = new Octagon();
            IDrawToForm form = (IDrawToForm)octagon;
            form.Draw();
            IDrawToPrinter printer = (IDrawToPrinter)octagon;
            printer.Draw();
            IDrawToMemory drawToMemory = (IDrawToMemory)octagon;
            drawToMemory.Draw();
            Console.ReadKey();
        }
        // Вывести изображение на форму
        public interface IDrawToForm
        {
            void Draw();
        }
        // Вывести изображение в буфер памяти,
        public interface IDrawToMemory
        {
            void Draw();
        }
        // Вывести изображение на принтер,
        public interface IDrawToPrinter
        {
            void Draw();
        }
        class Octagon : IDrawToPrinter, IDrawToForm, IDrawToMemory
        {
            void IDrawToForm.Draw()
            {
                Console.WriteLine("Octo to form");
            }
            void IDrawToMemory.Draw()
            {
                Console.WriteLine("Octo to memory");
            }
            void IDrawToPrinter.Draw()
            {
                Console.WriteLine("Octo to Printer");
            }
        }
    }
}
