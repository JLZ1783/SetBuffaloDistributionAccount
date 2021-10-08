using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Microsoft.Dexterity;
using System.Text;
using System.Threading.Tasks;

namespace ZeptoConnNet
{
    public static class ZeptoGPConn
    {
        public static SqlConnection GetConnection(string dsn, string database, string username, string password)
        {
            GPConnection.Startup();

            GPConnection gpConnObj = new GPConnection();
            gpConnObj.Init("", "");

            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = "DATABASE=" + database;

            gpConnObj.Connect(sqlConn, dsn, username, password);

            return sqlConn;

        }
    }
}
