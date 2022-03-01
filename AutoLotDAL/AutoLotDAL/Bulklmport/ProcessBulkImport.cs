using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using AutoLotDAL.Models;

namespace AutoLotDAL.Bulklmport
{
    public class ProcessBulkImport<T>
    {
        private static SqlConnection _connection;
        private static readonly string _connectionString = @"Data Source = (local)/SQLEXPRESS; Integrated Security = true; Initial Catalog = AutoLot";
        private static void OpenConnection()
        {
            _connection = new SqlConnection();
            _connection.ConnectionString = _connectionString;
            _connection.Open();
        }
        private static void CloseConnection()
        {
            if (_connection.State != ConnectionState.Closed ) 
                _connection.Close(); 
        }
        public static void ExecuteBulkImport(IEnumerable<T> records, string tableName)
        {
            OpenConnection();
            using (SqlConnection conn = _connection)
            {
                SqlBulkCopy bc = new SqlBulkCopy(conn)
                {
                    DestinationTableName = tableName
                };
                var dataReader = new MyDataReader<T>(records.ToList());
                try
                {
                    bc.WriteToServer(dataReader);
                }
                catch (Exception ex)
                {
                    // Здесь должно что-то делаться.
                }
                finally
                {
                    CloseConnection();
                }
            }
        }

        public void ExecuteBulkImport(List<T> cars, string v)
        {
            throw new NotImplementedException();
        }
    }
}

