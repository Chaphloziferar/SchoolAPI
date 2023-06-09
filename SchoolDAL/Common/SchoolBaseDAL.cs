using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDAL
{
    public class SchoolBaseDAL
    {
        public string ConnectionString { get; set; }

        public SchoolBaseDAL(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
