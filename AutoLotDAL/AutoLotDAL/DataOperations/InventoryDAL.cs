using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AutoLotDAL.Models;

namespace AutoLotDAL.DataOperations
{
    public class InventoryDAL
    {
        private readonly string _connectionString;
        private SqlConnection _sqlConnection = null;
        public InventoryDAL():this(@"Data Source = (local)\SQLEXPRESS; Integrated Security = true; Initial Catalog = AutoLot ")
        { }
        public InventoryDAL(string connectionString) => _connectionString = connectionString;
        private void OpenConnection()
        {
            _sqlConnection = new SqlConnection { ConnectionString = _connectionString};
            _sqlConnection.Open();
        }
        private void CloseConnection()
        {
            if(_sqlConnection?.State != ConnectionState.Closed)
                _sqlConnection.Close(); 
        }
        public List<Car> GetAllInventory()
        {
            OpenConnection();
            // This will hold the records.
            List<Car> inventory = new List<Car>();

            // Prep command object.
            string sql = "Select * From Inventory";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    inventory.Add(new Car
                    {
                        CarId = (int)dataReader["CarId"],
                        Color = (string)dataReader["Color"],
                        Make = (string)dataReader["Make"],
                        PetName = (string)dataReader["PetName"]
                    });
                }
                dataReader.Close();
            }
            return inventory;
        }
        public Car GetCar(int carID)
        {
            OpenConnection();
            Car car = null;
            string sql = $"Select * From Inventory where CarId = {carID}";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    car = new Car()
                    {
                        CarId = (int)dataReader["CarId"],
                        Color = (string)dataReader["Color"],
                        Make = (string)dataReader["Make"],
                        PetName = (string)dataReader["PetName"]
                    };

                }
                dataReader.Close();
            }
            return car;
        }
        public void InsertAuto(string color, string make, string petName)
        {
            OpenConnection();
            // Сформатировать и выполнить оператор SQL.
            string sql = $"Insert into Inventory (Make, Color, PetName) Values ('{make}', '{color}', '{petName}')";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))    
            {
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }
        public void InsertAuto(Car car)
        {
            OpenConnection();
            // Сформатировать и выполнить оператор SQL.
            string sql = $"Insert into Inventory (Make, Color, PetName) Values ('{car.Make}', '{car.Color}', '{car.PetName}')";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }
        public void DeleteCar(int carID)
        {
            OpenConnection();
            // Получить идентификатор автомобиля, подлежащего удалению,
            //и удалить запись о нем.
            string sql = $"Delete from Inventory where CarID = '{carID}'";
            using(SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                try
                {
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                catch
                {
                    Exception eror = new Exception("Извините, этот автомобиль заказан");
                    throw eror;
                }
            }
            CloseConnection();
        }
        public void SetPetName(int carID, int PetName)
        {
            OpenConnection();
            string sql = $"Update Inventory Set PetName = '{PetName}' Where CarID ='{carID}'";
            using(SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }
        public string LookUpPetName(int carID)
        {
            OpenConnection();
            string carPetName;
            // Установить имя хранимой процедуры.
            using(SqlCommand command = new SqlCommand("GetPetName",_sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                // Входной параметр.
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@carID",
                    SqlDbType = SqlDbType.Int,
                    Value = carID,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameter);
                // Входной параметр.
                parameter = new SqlParameter
                {
                    ParameterName = "@petName",
                    SqlDbType = SqlDbType.Char,
                    Size = 10,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(parameter);
                // Выполнить хранимую процедуру,
                command.ExecuteNonQuery();
                // Возвратить выходной параметр.
                carPetName = (string)command.Parameters["@petName"].Value;
                CloseConnection();
            }
            return carPetName;
        }
        public void ProcessCreditRisk(bool throwEx, int custId)
        {
            OpenConnection();
            // Первым делом найти текущее имя по идентификатору клиента,
            string fName;
            string lName;
            SqlCommand cmdSelect = new SqlCommand($"Select * From Customers where CustId = {custId}",_sqlConnection);
            using(SqlDataReader dataReader = cmdSelect.ExecuteReader())
            {
                if(dataReader.HasRows)
                {
                    dataReader.Read();
                    fName = (string)dataReader["FirstName"];
                    lName = (string)dataReader["LastName"];
                }
                else
                {
                    CloseConnection();
                    return;
                }
            }
            // Создать объекты команд, которые представляют каждый шаг операции,
            SqlCommand cmdRemove = new SqlCommand($"Delete * From Customers Where CustId = {custId}", _sqlConnection);
            SqlCommand cmdInsert = new SqlCommand($"Insert * Into CreditRisks (LastName, FirstName) Values ({lName},{fName})", _sqlConnection);
            // Это будет получено из объекта подключения.
            SqlTransaction tx = null;
            try
            {
                tx = _sqlConnection.BeginTransaction();
                // Включить команды в транзакцию,
                cmdInsert.Transaction = tx;
                cmdRemove.Transaction = tx;
                // Эмулировать ошибку,
                if (throwEx)
                    throw new Exception("Возникла ошибка, связанная с базой данных! Отказ транзакции...");
                // Зафиксировать транзакцию!
                tx.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Любая ошибка приведет к откату транзакции.
                // Использовать условную операцию для проверки на предмет null,
                tx?.Rollback();
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
