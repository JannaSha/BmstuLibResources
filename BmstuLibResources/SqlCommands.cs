using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace BmstuLibResources
{
    public class SqlCommands
    {
        private SqlConnection con = null;

        public SqlCommands() { }

        public void SqlConnection()
        {
            var con_str = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            try
            {
                con = new SqlConnection(con_str);
                con.Open();
            }
            catch(SqlException) 
            {
                // TODO
            }
        }

        public void SqlDispose()
        {
            this.con.Close();
        }

        public void AddResource(string name, string url, int udc_id, string type)
        {
            SqlConnection();
            string str_cmd = string.Format("Insert Into Resources"  + 
                   "Values(@name, @url, (Select id From Udc Where id = " + Convert.ToString(udc_id) + 
                   "), @create_date, @reserve_date, @resource_type, @html_code)");

            using (SqlCommand cmd = new SqlCommand(str_cmd, this.con))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@url", url);
                cmd.Parameters.AddWithValue("@create_date", DateTime.Today);
                cmd.Parameters.AddWithValue("@reserve_date", null);
                cmd.Parameters.AddWithValue("@resource_type", type);
                cmd.ExecuteNonQuery();
            }
        }
    }
}