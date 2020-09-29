using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RTC.DataAccess
{
    public class OrderDao : BaseDao, IOrderDao
    {
        private static Order LoadOrder(SqlDataReader reader)
        {
            //Создаём пустой объект
            Order order = new Order();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            order.CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID"));
            order.Date = reader.GetDateTime(reader.GetOrdinal("Date"));
            order.ID = reader.GetInt32(reader.GetOrdinal("ID"));
            order.Made = reader.GetDouble(reader.GetOrdinal("Made"));
            order.ManagerID = reader.GetInt32(reader.GetOrdinal("ManagerID"));
            order.Price = reader.GetDouble(reader.GetOrdinal("Price"));
            order.Status = reader.GetString(reader.GetOrdinal("Status"));
            order.TypeOfPayment = reader.GetString(reader.GetOrdinal("TypeOfPayment"));
            return order;
        }
        public void Add(Order order)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [Order] (CustomerID, Date, Made, ManagerID, Price, Status, TypeOfPayment)" +
                        "VALUES (@CustomerID, @Date, @Made, @ManagerID, @Price, @Status, @TypeOfPayment)";
                    cmd.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                    cmd.Parameters.AddWithValue("@Date", order.Date);
                    cmd.Parameters.AddWithValue("@Made", order.Made);
                    cmd.Parameters.AddWithValue("@ManagerID", order.ManagerID);
                    cmd.Parameters.AddWithValue("@Price", order.Price);
                    cmd.Parameters.AddWithValue("@Status", order.Status);
                    cmd.Parameters.AddWithValue("@TypeOfPayment", order.TypeOfPayment);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [Order] WHERE ID = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Order Get(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [Order] WHERE ID = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : LoadOrder(dataReader);
                    }
                }
            }
        }

        public int GetMaxID()
        {
            Order order = new Order();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT MAX(ID) FROM [Order]";
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

        }
        public IList<Order> GetFromManager(int idManager)
        {
            IList<Order> orders = new List<Order>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [Order] WHERE ManagerID = @idManager";
                    cmd.Parameters.AddWithValue("@idManager", idManager);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            orders.Add(LoadOrder(dataReader));
                        }
                    }
                }
            }
            return orders;
        }
        public IList<Order> GetAll()
        {
            IList<Order> orders = new List<Order>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [Order]";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            orders.Add(LoadOrder(dataReader));
                        }
                    }
                }
            }
            return orders;
        }

        public void Update(Order order)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE [Order] SET CustomerID = @CustomerID, Date = @Date, Made = @Made, ManagerID = @ManagerID, Price = @Price, Status = @Status, TypeOfPayment = @TypeOfPayment WHERE ID = @id";
                    cmd.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                    cmd.Parameters.AddWithValue("@Date", order.Date);
                    cmd.Parameters.AddWithValue("@Made", order.Made);
                    cmd.Parameters.AddWithValue("@ManagerID", order.ManagerID);
                    cmd.Parameters.AddWithValue("@Price", order.Price);
                    cmd.Parameters.AddWithValue("@Status", order.Status);
                    cmd.Parameters.AddWithValue("@TypeOfPayment", order.TypeOfPayment);
                    cmd.Parameters.AddWithValue("@id", order.ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
