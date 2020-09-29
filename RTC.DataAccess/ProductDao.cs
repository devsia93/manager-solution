using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RTC.DataAccess
{
    public class ProductDao : BaseDao, IProductDao
    {
        private static Product LoadProduct(SqlDataReader reader)
        {
            //Создаём пустой объект
            Product product = new Product();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            product.Count = reader.GetInt32(reader.GetOrdinal("Count"));
            product.ID = reader.GetInt32(reader.GetOrdinal("ID"));
            product.Importer = reader.GetString(reader.GetOrdinal("Importer"));
            product.MRC = reader.GetDouble(reader.GetOrdinal("MRC"));
            product.Price = reader.GetDouble(reader.GetOrdinal("Price"));
            product.Reserve = reader.GetInt32(reader.GetOrdinal("Reserve"));
            product.Title = reader.GetString(reader.GetOrdinal("Title"));
            return product;
        }
        public void Add(Product product)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Product (Count, Importer, MRC, Price, Reserve, Title)" +
                        "VALUES (@Count, @Importer, @MRC, @Price, @Reserve, @Title)";
                    cmd.Parameters.AddWithValue("@Count", product.Count);
                    cmd.Parameters.AddWithValue("@Importer", product.Importer);
                    cmd.Parameters.AddWithValue("@MRC", product.MRC);
                    cmd.Parameters.AddWithValue("@Price", product.Price);
                    cmd.Parameters.AddWithValue("@Reserve", product.Reserve);
                    cmd.Parameters.AddWithValue("@Title", product.Title);
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
                    cmd.CommandText = "DELETE FROM Product WHERE ID = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public Product GetID(string Title)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Product WHERE Title = @Title";
                    cmd.Parameters.AddWithValue("@Title", Title);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : LoadProduct(dataReader);
                    }
                }
            }
        }
        public Product Get(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Product WHERE ID = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : LoadProduct(dataReader);
                    }
                }
            }
        }

        public IList<Product> GetAll()
        {
            IList<Product> products = new List<Product>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Product";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            products.Add(LoadProduct(dataReader));
                        }
                    }
                }
            }
            return products;
        }

        public void AddCount(int count, int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Product SET Count = Count + @count WHERE ID=@id";
                    cmd.Parameters.AddWithValue("@count", count);
                    cmd.Parameters.AddWithValue("@id", id);
                }
            }
        }

        public void Update(Product product)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Product SET Count = @Count, Importer = @Importer, MRC = @MRC, Price = @Price, Reserve = @Reserve, Title = @Title WHERE ID = @id";
                    cmd.Parameters.AddWithValue("@Count", product.Count);
                    cmd.Parameters.AddWithValue("@Importer", product.Importer);
                    cmd.Parameters.AddWithValue("@MRC", product.MRC);
                    cmd.Parameters.AddWithValue("@Price", product.Price);
                    cmd.Parameters.AddWithValue("@Reserve", product.Reserve);
                    cmd.Parameters.AddWithValue("@Title", product.Title);
                    cmd.Parameters.AddWithValue("@id", product.ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
