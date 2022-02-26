using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithLinqExpressions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Этот массив будет основой для тестирования. . .
            ProductInfo[] itemsInStock = new ProductInfo[]
            {
                new ProductInfo{ Name = "Mac's Coffee",Description = "Coffee with TEETH",NumberInStock = 24},
                new ProductInfo{Name = "Milk Maid Milk",Description = "Milk cow's love",NumberInStock = 100},
                new ProductInfo{ Name = "Pure Silk Tofu",Description = "Bland as Possible",NumberInStock = 120},
                new ProductInfo{ Name = "Crunchy Pops",Description = "Cheezy, peppery goodness",NumberInStock = 2},
                new ProductInfo{ Name = "RipOff Water",Description = "From the tap to your wallet",NumberInStock = 100},
                new ProductInfo{ Name = "Classic Valpo Pizza",Description = "Everyone loves pizza",NumberInStock = 73}
            };
            SelectEverything(itemsInStock);
            Console.WriteLine();
            Array objs = SelectNameAndDescription(itemsInStock);
            foreach (var item in objs)
                Console.WriteLine(item);
            Console.ReadKey();
        }
        static void AggregateOps()
        {
            double[] winterTemps = { 2.0, -21.3, 8, -4, 0, 8.2 } ;
            // Разнообразные примеры агрегации. Выводит максимальную температуру:
            Console.WriteLine("Max temp: { 0} ", (from t in winterTemps select t).Max());
            // Выводит минимальную температуру:
            Console.WriteLine("Min temp: {0}", (from t in winterTemps select t).Min());
            // Выводит среднюю температуру:
            Console.WriteLine("Average temp: {0}", (from t in winterTemps select t).Average());
            // Выводит сумму всех температур:
            Console.WriteLine("Sum of all temps: {0}", (from t in winterTemps select t).Sum());
        }
            public static void SelectEverything(ProductInfo[] products)
        {
            var product = from p in products select p;
            foreach (var item in product)
                Console.WriteLine(item);
        }
        public static Array SelectNameAndDescription(ProductInfo[] products)
        {
            var product = from p in products select new { p.Name, p.Description };
            return product.ToArray();
        }
        static void GetCountFromQuery()
        {
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            // Получить количество элементов из запроса.
            int numb = (from g in currentVideoGames where g.Length > 6 select g).Count();
            // Вывести количество элементов.
            Console.WriteLine("{0} items honor the LINQ query.", numb);
        }
        static void ReverseEverything(ProductInfo[] products)
        {
            Console.WriteLine("Product in reverse:");
            var allProducts = from p in products select p;
            foreach (var prod in allProducts.Reverse())
                Console.WriteLine(prod);
        }
        static void AlphabetizeProductNames(ProductInfo[] products)
        {
            // Получить названия товаров в алфавитном порядке,
            var subset = from p in products orderby p.Name select p;//p.Name descending - обратный порядок
            Console.WriteLine("Ordered by Name:");
            foreach (var p in subset)
                Console.WriteLine(p);
        }
        static void DisplayDiff()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };
            var carDiff = (from c in myCars select c).Except(from c2 in yourCars select c2);
            Console.WriteLine("Here is what you don't have, but I do:");
            foreach (string s in carDiff)
                Console.WriteLine(s); // Выводит Yugo.
        }
        static void Displaylntersection()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };
            // Получить общие члены.
            var carlntersect = (from c in myCars select c).Intersect(from c2 in yourCars select c2);
            Console.WriteLine("Here is what we have in common:");
            foreach (string s in carlntersect)
                Console.WriteLine(s); // Выводит Aztec и BMW.
        }
        static void DisplayUnion()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };
            // Получить объединение двух контейнеров.
            var carUnion = (from c in myCars select c).Union(from c2 in yourCars select c2);
            Console.WriteLine("Here is everything:");
            foreach (string s in carUnion)
                Console.WriteLine(s); // Выводит все общие члены.
        }
        static void DisplayConcat()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };
            var carConcat = (from c in myCars select c).Concat(from c2 in yourCars select c2);
            // Выводит: Yugo Aztec BMW BMW Saab Aztec,
            foreach (string s in carConcat)
                Console.WriteLine(s);
        }
        static void DisplayConcatNoDups()
        {
            List<string> myCars = new List<String> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<String> { "BMW", "Saab", "Aztec" };
            var carConcat = (from c in myCars select c).Concat(from c2 in yourCars select c2);
            // Выводит: Yugo Aztec BMW Saab.
            foreach (string s in carConcat.Distinct())
                Console.WriteLine(s);
        }
    }
}
