using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RTC.DataAccess
{
    public class BaseDao
    {
        protected static SqlConnection GetConnection() { return new SqlConnection(GetConnectionString()); }

        private static string GetConnectionString() { return ConfigurationManager.ConnectionStrings["vradb"].ConnectionString; }
    }
}
