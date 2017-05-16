using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerSql
{
    public class DataLayer
    {
        SqlConnection conn;

        public SqlConnection Conn
        {
            get { return conn; }
        }

        public DataLayer(String connectionString)
        {
            conn = new SqlConnection(connectionString);
        }


        public DataTable GetDataTable(string query)
        {
            DataTable Return = new DataTable("DataView");

            SqlCommand cmd = new SqlCommand(query, conn);
            
            try
            {
                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                    Return.Load(rd);
            }
            catch (Exception)
            { }
            finally
            {
                conn.Close();
            }


            return Return;
        }


        //public void Insert(DataTable dt, string query)
        //{
        //    int id = -1;
        //    int stepId = -1;
            
            

            
        //}
    }
}
