using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Projekat
{
    public static class Database
    {
        public static string connectionString = "Server=DESKTOP-3ELM7OD\\SQLEXPRESS;Database=prodaja_muzicke_opreme;Trusted_Connection=True;";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
