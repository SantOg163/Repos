using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace DataProviderFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Получить строку подключения и поставщик из файла *.config,
            string dataProvider = ConfigurationManager.AppSettings["provider"];
            string connectionstring = ConfigurationManager.AppSettings["connectionString"];
            // Получить фабрику поставщиков.
            DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);
            // Получить объект подключения.
            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                {
                    ShowError("Connection");
                    return;
                }
                Console.WriteLine($"Your connection object is a: {connection.GetType().Name}");
                connection.ConnectionString = connectionstring;
                connection.Open();
                // Создать объект команды.
                DbCommand command = factory.CreateCommand();
                if (command == null)
                {
                    ShowError("Command");
                    return;
                }
                Console.WriteLine($"Your command object is a: {command.GetType().Name}");
                command.Connection = connection;
                command.CommandText = "Select * From Inventory";
                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    Console.WriteLine("Ваш объект чтения данных — это " + dataReader.GetType().Name);
                    while (dataReader.Read())
                        Console.WriteLine($"-> Car #{dataReader["CarID"] } is a {dataReader["Make"]}.");
                }
                Console.ReadLine();

            }
        }
        private static void ShowError(string objectName)
        {
            Console.WriteLine($"There was an issue creating the {objectName}");
            // Возникла проблема с созданием объекта
            Console.ReadLine();
        }
    }
}
