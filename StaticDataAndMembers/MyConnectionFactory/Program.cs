using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
// Эти пространства имен нужны для получения определений
// общих интерфейсов и разнообразных объектов подключений.
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;

namespace MyConnectionFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Прочитать ключ provider.
            string strDataProvider = ConfigurationManager.AppSettings["provider"];
            DataProvider dataProvider = DataProvider.None;

            // Преобразовать строку в перечисление.
            if (Enum.IsDefined(typeof (DataProvider), strDataProvider))
                dataProvider = (DataProvider)Enum.Parse(typeof (DataProvider), strDataProvider);
            else
            {
                Console.WriteLine("Поставщики отсутствуют"); 
                Console.ReadLine();
                return;
            }
            
            IDbConnection dbConnection = GetConnection(dataProvider);
            Console.WriteLine($"Тип подключения: {dbConnection.GetType().Name}");
            
            // Открыть, использовать и закрыть подключение...
            Console.ReadLine();
        }

        // Этот метод возвращает конкретный объект подключения
        // на основе значения перечисления DataProvider.
        static IDbConnection GetConnection(DataProvider dataProvider)
        {
            IDbConnection connection = null;
            switch(dataProvider)
            {
                case DataProvider.SqlServer:
                    connection = new SqlConnection();
                    break;
                case DataProvider.OleDb:
                    connection = new OleDbConnection();
                    break;
                case DataProvider.Odbc:
                    connection = new OdbcConnection();
                    break;
            }
            return connection;
        }
    }
    enum DataProvider
    {
        SqlServer,
        OleDb,
        Odbc,
        None
    }
}
