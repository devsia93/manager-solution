using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RTC.DataAccess
{
    public class ItemsDao : BaseDao, IItemsDao
    {
        private static Items LoadItems(SqlDataReader reader)
        {
            //Создаём пустой объект
            Items items = new Items();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            items.Count = reader.GetInt32(reader.GetOrdinal("Count"));
            items.OrderID = reader.GetInt32(reader.GetOrdinal("OrderID"));
            items.Price = reader.GetDouble(reader.GetOrdinal("Price"));
            items.ProductID = reader.GetInt32(reader.GetOrdinal("ProductID"));
            return items;
        }
        public void Add(Items item)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Items (Count, OrderID, Price, ProductID)" +
                        "VALUES (@Count, @OrderID, @Price, @ProductID)";
                    cmd.Parameters.AddWithValue("@Count", item.Count);
                    cmd.Parameters.AddWithValue("@OrderID", item.OrderID);
                    cmd.Parameters.AddWithValue("@Price", item.Price);
                    cmd.Parameters.AddWithValue("@ProductID", item.ProductID);
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
                    cmd.CommandText = "DELETE FROM Items WHERE ID = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IList<Items> Get(int idOrder)
        {
            IList<Items> items = new List<Items>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Items WHERE OrderID = @idOrder";
                    cmd.Parameters.AddWithValue("@idOrder", idOrder);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            items.Add(LoadItems(dataReader));
                        }
                    }
                }
            }
            return items;
        }

        public IList<Items> GetAll()
        {
            IList<Items> items = new List<Items>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Items";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            items.Add(LoadItems(dataReader));
                        }
                    }
                }
            }
            return items;
        }

        public void Update(Items item)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Items SET Count = @Count, OrderID = @OrderID, Price = @Price, ProductID = @ProductID WHERE ID = @id";
                    cmd.Parameters.AddWithValue("@Count", item.Count);
                    cmd.Parameters.AddWithValue("@OrderID", item.OrderID);
                    cmd.Parameters.AddWithValue("@Price", item.Price);
                    cmd.Parameters.AddWithValue("@ProductID", item.ProductID);
                    cmd.Parameters.AddWithValue("@id", item.ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
