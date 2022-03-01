using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL.DataOperations;
using AutoLotDAL.Models;
using AutoLotDAL.Bulklmport;
using System.Collections;

namespace AutoLotClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InventoryDAL dal = new InventoryDAL();
            List<Car> list = dal.GetAllInventory();
            foreach (Car cars in list)
                Console.WriteLine($"CarID: {cars.CarId}\tMake: {cars.Make}\tColor: {cars.Color}\tPetName: {cars.PetName} ");
            Console.WriteLine();
            var car = dal.GetCar(list.OrderBy(x => x.Color).Select(x => x.CarId).First());
            Console.WriteLine(car);
            Console.WriteLine("CarId\tMake\tColor\tPet Name");
            Console.WriteLine($"{car.CarId}\t{ car.Make}\t{ car.Color}\t{ car.PetName}");
            try
            {
                dal.DeleteCar(5);
                Console.WriteLine("Машина удалена");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occurred: {ex.Message}");
                // Возникло исключение
            }
            dal.InsertAuto(new Car
            {
                Color = "Blue",
                Make = "Pilot",
                PetName = "TowMonster"
            });
            list = dal.GetAllInventory();
            var newCar = list.First(x => x.PetName == "TowMonster");
            Console.WriteLine(" ************** New Car ************** ");
            Console.WriteLine("CarId\tMake\tColor\tPet Name");
            Console.WriteLine($"{newCar.CarId}\t{newCar.Make}\t{newCar.Color}\t{ newCar.PetName} ");
            dal.DeleteCar(newCar.CarId);
            var petName = dal.LookUpPetName(car.CarId);
            Console.WriteLine(" ************** New Car ************** ");
            Console.WriteLine($"Car pet name: {petName}");
            Console.Write("Press enter to continue...");
            // Для продолжения нажмите <Enter>...
            Console.ReadLine();
        }
        public static void DoBulkCopy()
        {
            List<Car> cars = new List<Car>()
            {
                new Car(){Color = "Blue", Make = "Honda", PetName = "MyCarl"},
                new Car(){Color = "Red", Make = "Volvo", PetName = "MyCar2" },
                new Car() { Color = "White", Make = "VW", PetName = "МуСагЗ" },
                new Car() { Color = "Yellow", Make = "Toyota", PetName = "MyCar4" }
            };
            ProcessBulkImport<Car>.ExecuteBulkImport(cars, "Inventory");
            InventoryDAL dal = new InventoryDAL();
            var list = dal.GetAllInventory();
            foreach (var itm in list)
                Console.WriteLine($"{itm.CarId}\t{itm.Make}\t{itm.Color}\t{itm.PetName}");
            Console.WriteLine();
        }
    public static void MoveCustomer()
        {
            // Простой способ позволить транзакции успешно завершиться или отказать,
            bool throwEx = true;
            Console.WriteLine("Сгенерировать исключение ? ");
            string userAnswer = Console.ReadLine();
            if(userAnswer.ToLower() == "нет")
                throwEx = false;
            InventoryDAL dal = new InventoryDAL();
            // Обработать клиента 1 - ввести идентификатор клиента,
            // подлежащего перемещению.
            dal.ProcessCreditRisk(throwEx, 1);
            Console.WriteLine("Результат в таблице");
        }
    }
}
