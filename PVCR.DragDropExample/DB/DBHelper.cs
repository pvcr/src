using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCR.DragDropExample.DB
{
    public class DBHelper : IDisposable
    {
        /// <summary>
        /// SqlConnection : This is the connection
        /// </summary>
        SqlConnection _connection; 
        /// <summary>
        /// SqlCommand : This is the command
        /// </summary>
        SqlCommand _command;
        /// <summary>
        /// Constructor: This is the constructor
        /// </summary>
        /// <param name="connectionString">string: This is the data source name</param>
        public DBHelper(string connectionString)
        {
            //Instantiate the connection
            _connection = new SqlConnection(connectionString);

            //Open the connection
            _connection.Open();

            //Notify the user that the connection is opened
            //Console.WriteLine("The connection is established with the database");


        }
        /// <summary>
        /// void: It is used to close the connection if you work within disconnected
        /// mode
        /// </summary>
        public void CloseConnection()
        {
            _connection.Close();
        }
        /// <summary>
        /// OdbcCommand: This function returns a valid odbc connection
        /// </summary>
        /// <param name="Query">string: This is the SQL query</param>
        /// <returns></returns>
        public SqlCommand GetCommand(string query)
        {
            _command = new SqlCommand();
            _command.Connection = _connection;
            _command.CommandText = query;
            return _command;
        }
        /// <summary>
        /// void: This method close the actual connection
        /// </summary>
        public void Dispose()
        {
            _connection.Close();
        }

    }
}
