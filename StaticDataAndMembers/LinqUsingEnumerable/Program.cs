using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqUsingEnumerable
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
        static void QueryStringsWithOperators()
        {
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            var subset = from g in currentVideoGames where g.Contains(" ") orderby g select g;
            foreach (var g in subset)
                Console.WriteLine(g);
        }
        static void QueryStringsWithEnumerableAndLambdas()
        {
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            var subset = currentVideoGames.Where(g=>g.Contains(" ")).OrderBy(g=>g).Select(g=>g);
            foreach (var g in subset)
                Console.WriteLine(g);
        }
        static void QueryStringsWithAnonymousMethods()
        {
            Console.WriteLine("***** Using Anonymous Methods *****");
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};
            // Построить необходимые делегаты Funco с использованием анонимных методов.
            Func<string, bool> searchFilter =
            delegate (string game) { return game.Contains(" "); };
            Func<string, string> itemToProcess = delegate (string s) { return s; };
            // Передать делегаты в методы класса Enumerable.
            var subset = currentVideoGames.Where(searchFilter).OrderBy(itemToProcess).Select(itemToProcess);
            // Вывести результаты,
            foreach (var game in subset)
                Console.WriteLine("Item: {0}", game);
            Console.WriteLine();
        }


    }
}
