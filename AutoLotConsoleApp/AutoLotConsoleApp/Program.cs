using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotConsoleApp.EF;

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
            using (var context = new AutoLotEntities())
            {
                context.Cars.AddRange(carsToAdd);
                context.SaveChanges();
            }
        }
        private static void PrintAllInventory()
        {
            // Выбрать все элементы из таблицы Inventory базы данных AutoLot и вывести данные с применением специального метода ToString() сущностного класса Саг.
            using (var context = new AutoLotEntities())
            {
                foreach (Car c in context.Cars.Where(c => c.Make == "Mercedes"))
                    Console.WriteLine(c);
            }
        }
        public static void RemoveRecord(Car car)
        {
            using (var context = new AutoLotEntities())
            {
                context.Cars.Remove(car);
                context.SaveChanges();
            }
        }
        public static void RemoveMultipleRecords(IEnumerable<Car> cars)
        {
            using (var context = new AutoLotEntities())
            {
                context.Cars.RemoveRange(cars);
                context.SaveChanges();
            }
        }
        public static void RemoveToId(int carId)
        {
            using (var context = new AutoLotEntities())
            {
                context.Cars.Remove((Car)context.Cars.Where(car => car.CarId == carId));
            }
        }
        private static void RemoveRecordUsingEntityState(int carld)
        {
            using (var context = new AutoLotEntities())
            {
                Car carToDelete = new Car() { CarId = carld };
                context.Entry(carToDelete).State = System.Data.Entity.EntityState.Deleted;
                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
        private void UpdateRecord(int carId)
        {
            using(var context = new AutoLotEntities())
            {
                // Получить запись об автомобиле, обновить ее и сохранить
                Car carToUpdate = context.Cars.Find(carId);
                if(carToUpdate == null)
                {
                    Console.WriteLine(context.Entry(carToUpdate).State);
                    carToUpdate.Color = "Blue";
                    Console.WriteLine(context.Entry(carToUpdate).State);
                    context.SaveChanges();
                }
            }
        }
    }
}
