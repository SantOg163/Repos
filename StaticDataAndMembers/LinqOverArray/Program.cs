using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOverArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QueryOverStringsWithExtensionMethods();
            Console.ReadKey();
        }        
        public static void ReflectOverQueryResults(object resultSet, string queryType = "Query Expressions")
        {
            // Вывести тип результирующего набора.
            Console.WriteLine("resultSet is of type: {0}", resultSet.GetType().Name);
            // Вывести местоположение результирующего набора.
            Console.WriteLine("resultSet location: {0}", resultSet.GetType().Assembly.GetName().Name);
        }
        public static void QueryOverStrings()
        {
            // Предположим, что есть массив строк.
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};
            // Построить выражение запроса для нахождения
            // элементов массива, которые содержат пробелы.
            IEnumerable<string> subset = from games in currentVideoGames where games.Contains(" ") orderby games select games;
            ReflectOverQueryResults(subset);
            foreach (string sub in subset)
                Console.WriteLine(sub);
        }

        public static void QueryOverStringsWithExtensionMethods()
        {
            // Пусть имеется массив строк.
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};
            // Построить выражение запроса для поиска
            // в массиве элементов, содержащих пробелы.
            IEnumerable<string> subset = currentVideoGames.Where(games => games.Contains(" ")).OrderBy(games => games).Select(games => games);
            ReflectOverQueryResults(subset, "Extension methods");
            // Вывести результаты,
            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);

        }
    }
}
