using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AutoLotDataReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //оздать строку подключения с помощью объекта построителя.
            var cnStringBuilder = new SqlConnectionStringBuilder
            {
                InitialCatalog = "AutoLot",
                DataSource = @"(local)\SQLEXPRESS",
                ConnectTimeout = 30,
                IntegratedSecurity = true
            };
            // Создать и открыть подключение.
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source = (local)\SQLEXPRESS; Initial Catalog = AutoLot; Integrated Security = true;Connect Timeout = 30 ";
                connection.Open();
                ShowConnectionStatus(connection);
                // Создать объект команды SQL.
                string sql = "Select * From Inventory";
                SqlCommand myCommand = new SqlCommand(sql, connection);
                // Получить объект чтения данных с помощью ExecuteReader().
                using(SqlDataReader reader = myCommand.ExecuteReader())
                {
                    while (reader.Read())
                        Console.WriteLine($"CarID: {reader["CarID"]}, Make: {reader["Make"]}, Color: {reader["Color"]}, PetName: {reader["PetName"]}");

                }
            }
            Console.ReadLine();
        }
        static void ShowConnectionStatus(SqlConnection connection)
        {
            // Вывести различные сведения о текущем объекте подключения.
            Console.WriteLine($"Database location: {connection.DataSource}");// Местоположение базы данных
            Console.WriteLine($"Database name: {connection.Database}"); // Имя базы данных
            Console.WriteLine($"Timeout: {connection.ConnectionTimeout}"); // Таймаут
            Console.WriteLine($"Connection state: {connection.State}\n"); // Состояние
        }

    }
}
