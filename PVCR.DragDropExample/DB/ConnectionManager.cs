using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCR.DragDropExample.DB
{
    public class ConnectionManager
    {
        public static SqlConnection GetSqlConnection()
        {
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnStrng"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            return con;

        }

        public static OleDbConnection GetOledbConnection()
        {
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnStrng"].ConnectionString;
            OleDbConnection con = new OleDbConnection(connString);
            con.Open();
            return con;

        }

    }
}
