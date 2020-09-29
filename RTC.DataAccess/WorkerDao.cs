using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RTC.DataAccess
{
    public class WorkerDao : BaseDao, IWorkerDao
    {
        private static Worker LoadWorker(SqlDataReader reader)
        {
            //Создаём пустой объект
            Worker worker = new Worker();
            //Заполняем поля объекта в соответствии с названиями полей результирующего
            // набора данных
            worker.Adress = reader.GetString(reader.GetOrdinal("Adress"));
            worker.ID = reader.GetInt32(reader.GetOrdinal("ID"));
            worker.Name = reader.GetString(reader.GetOrdinal("Name"));
            worker.Phone = reader.GetString(reader.GetOrdinal("Phone"));
            return worker;
        }
        public void Add(Worker worker)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Worker (Adress, Name, Phone)" +
                        "VALUES (@Adress, @Name, @Phone)";
                    cmd.Parameters.AddWithValue("@Adress", worker.Adress);
                    cmd.Parameters.AddWithValue("@Name", worker.Name);
                    cmd.Parameters.AddWithValue("@Phone", worker.Phone);
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
                    cmd.CommandText = "DELETE FROM Worker WHERE ID = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Worker Get(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Worker WHERE ID = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : LoadWorker(dataReader);
                    }
                }
            }
        }

        public IList<Worker> GetAll()
        {
            IList<Worker> workers = new List<Worker>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Worker";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            workers.Add(LoadWorker(dataReader));
                        }
                    }
                }
            }
            return workers;
        }

        public void Update(Worker worker)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Worker SET Adress = @Adress, Name = @Name, Phone = @Phone WHERE ID = @id";
                    cmd.Parameters.AddWithValue("@Adress", worker.Adress);
                    cmd.Parameters.AddWithValue("@Name", worker.Name);
                    cmd.Parameters.AddWithValue("@Phone", worker.Phone);
                    cmd.Parameters.AddWithValue("@id", worker.ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
