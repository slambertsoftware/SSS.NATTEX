using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.Models
{
    public class SQLHelper
    {
        SqlConnection connection;

        public SQLHelper(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public bool IsConnected()
        {
            bool result = false;
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
                result = true;
            }
            return result;
        }
    }
}
