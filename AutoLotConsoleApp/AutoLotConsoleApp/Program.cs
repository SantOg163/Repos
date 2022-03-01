using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotConsoleApp.EF;
using AutoLotConsoleApp;


namespace AutoLotConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new AutoLotEntities();
            PrintAllInventory();
            Console.ReadLine();
        }
        private static int AddNewRecord()
        {
            // Добавить запись в таблицу Inventory базы данных AutoLot.
            using (var context = new AutoLotEntities())
            {
                try
                {
                    // В целях тестирования жестко закодировать данные для новой записи,
                    var car = new Car() { Make = "Yugo", Color = "Brown", CarNickName = "Brownie" };
                    context.Cars.Add(car);
                    context.SaveChanges();
                    // В случае успешного сохранения EF заполняет поле идентификатора значением, сгенерированным базой данных,
                    return car.CarId;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException?.Message);
                    return 0;
                }
            }
        }
        private static void AddNewRecords(IEnumerable<Car> carsToAdd)
        {
            using(var context = new AutoLotEntities())
            {
                context.Cars.AddRange(carsToAdd);
                context.SaveChanges();
            }
        }
        private static void PrintAllInventory()
        {
            // Выбрать все элементы из таблицы Inventory базы данных AutoLot и вывести данные с применением специального метода ToString() сущностного класса Саг.
            using(var context = new AutoLotEntities())
            {
                foreach (Car c in context.Cars.Where(c => c.Make == "Mercedes"))
                    Console.WriteLine(c);
            }
        }
    }
}
