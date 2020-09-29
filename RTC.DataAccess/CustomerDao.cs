using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RTC.DataAccess
{
    public class CustomerDao : BaseDao, ICustomerDao
    {
        private static Customer LoadCustomer(SqlDataReader reader)
        {
            //Создаём пустой объект
            Customer customer = new Customer();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            customer.Adress = reader.GetString(reader.GetOrdinal("Adress"));
            customer.ID = reader.GetInt32(reader.GetOrdinal("ID"));
            customer.Info = reader.GetString(reader.GetOrdinal("Info"));
            customer.ManagerID = reader.GetInt32(reader.GetOrdinal("ManagerID"));
            customer.Name = reader.GetString(reader.GetOrdinal("Name"));
            customer.Phone = reader.GetString(reader.GetOrdinal("Phone"));
            return customer;
        }
        public void Add(Customer customer)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Customer (Adress, Info, ManagerID, Name, Phone)" +
                        "VALUES (@Adress, @Info, @ManagerID, @Name, @Phone)";
                    cmd.Parameters.AddWithValue("@Adress", customer.Adress);
                    cmd.Parameters.AddWithValue("@Info", customer.Info);
                    cmd.Parameters.AddWithValue("@ManagerID", customer.ManagerID);
                    cmd.Parameters.AddWithValue("@Name", customer.Name);
                    cmd.Parameters.AddWithValue("@Phone", customer.Phone);
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
                    cmd.CommandText = "DELETE FROM Customer WHERE ID = @ID";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Customer Get(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Customer WHERE ID = @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : LoadCustomer(dataReader);
                    }
                }
            }
        }

        public IList<Customer> GetAll()
        {
            IList<Customer> customers = new List<Customer>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Customer";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            customers.Add(LoadCustomer(dataReader));
                        }
                    }
                }

            }
            return customers;
        }

        public IList<Customer> SearchCustomer(string Name)
        {
            IList<Customer> customers = new List<Customer>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Customer WHERE Name = @Name";
                    cmd.Parameters.AddWithValue("@Name", Name);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            customers.Add(LoadCustomer(dataReader));
                        }
                    }
                }
            }
            return customers;
        }

        public void Update(Customer customer)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Customer SET Adress = @Adress," +
                        " Info = @Info, ManagerID = @ManagerID, Name = @Name, Phone = @Phone " +
                        "WHERE ID = @ID";
                    cmd.Parameters.AddWithValue("@ID", customer.ID);
                    cmd.Parameters.AddWithValue("@Adress", customer.Adress);
                    cmd.Parameters.AddWithValue("@Info", customer.Info);
                    cmd.Parameters.AddWithValue("@ManagerID", customer.ManagerID);
                    cmd.Parameters.AddWithValue("@Name", customer.Name);
                    cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
