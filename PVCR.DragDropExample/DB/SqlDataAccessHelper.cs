using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCR.DragDropExample.DB
{
    public class SqlDataAccessHelper
    {
        public int ExecuteNonQuery(string comndTxt,CommandType cmndType,params SqlParameter[] cmndParams)
        {

            int affectedRows = 0;
            using (var conn= ConnectionManager.GetSqlConnection())
            {
                using (var comnd=new SqlCommand(comndTxt,conn))
                {
                    comnd.CommandType = cmndType;
                    if (cmndParams != null)
                        comnd.Parameters.AddRange(cmndParams);

                    affectedRows = comnd.ExecuteNonQuery();
                }
            }
            
                return affectedRows;
        }

        public DataSet ExecuteQuery(string comndTxt, CommandType cmndType, params SqlParameter[] cmndParams)
        {
            DataSet ds;

            using (var conn = ConnectionManager.GetSqlConnection())
            {
                using (var comnd = new SqlCommand(comndTxt, conn))
                {
                    ds = new DataSet();
                    comnd.CommandType = cmndType;
                    if (cmndParams != null)
                        comnd.Parameters.AddRange(cmndParams);
                    SqlDataAdapter da = new SqlDataAdapter(comnd);
                    da.Fill(ds);                   
                }
            }
            return ds;
        }


        public IDataReader ExecuteReader(string comndTxt, CommandType cmndType, params SqlParameter[] cmndParams)
        {
            var con = ConnectionManager.GetSqlConnection();
            var cmd = new SqlCommand(comndTxt, con);
            cmd.CommandType = cmndType;
            if (cmndParams != null)
                cmd.Parameters.AddRange(cmndParams);
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}
