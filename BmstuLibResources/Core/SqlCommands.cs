using System;
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
            catch (SqlException exc)    { Console.Write("Allert: %s", exc);  }
        }

        public void SqlDispose()
        {
            this.con.Close();
        }

        public void Add(resRecord resource)
        {
            SqlConnection();

            if (resource.is_license)
                AddLicense(resource);
            else
                AddNoLicense(resource);

            SqlDispose();
        }

        public void Update(resRecord resource, int id_res)
        {
            SqlConnection();

            if (resource.is_license)
                UpdLicense(resource, id_res);
            else
                UpdNoLicense(resource, id_res);

            SqlDispose();
        }

        public resRecord GetRecord(int id_res)
        {
            resRecord record = new resRecord();

            SqlConnection();

            string str_cmd = "SELECT* FROM Resources WHERE id = " + Convert.ToString(id_res);

            using (SqlCommand cmd = new SqlCommand(str_cmd, this.con))
            {
                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    record.name = dataReader.GetString(1);
                    record.author = dataReader.GetString(2);
                    record.url = dataReader.GetString(3);
                    record.udc_id = dataReader.GetInt32(4);
                    record.create_date = dataReader.GetDateTime(5);
                    record.type_res = dataReader.GetString(10);
                    record.form = dataReader.GetString(9);
                    record.amount = dataReader.GetInt32(11);

                    record.is_editing = dataReader.GetBoolean(12);
                    record.is_license = dataReader.GetBoolean(13);

                    if (record.is_license)
                        record.license = dataReader.GetDateTime(7);
                }
                dataReader.Close();
            }

            SqlDispose();

            return record;
        }

        private void AddNoLicense(resRecord resource)
        {
            string udc_id = Convert.ToString(resource.udc_id);

            string str_cmd = string.Format("Insert Into Resources " +
                   "Values(@name, @author, @url, (Select id From Udc Where id = " + udc_id +
                   "), @create_date, NULL, NULL, '', @form, @type_res, @amount, " +
                   "@is_editing, @is_license);");

            using (SqlCommand cmd = new SqlCommand(str_cmd, this.con))
            {
                cmd.Parameters.AddWithValue("@name", resource.name);
                cmd.Parameters.AddWithValue("@author", resource.author);
                cmd.Parameters.AddWithValue("@url", resource.url);
                cmd.Parameters.AddWithValue("@create_date", resource.create_date);
                cmd.Parameters.AddWithValue("@type_res", resource.type_res);
                cmd.Parameters.AddWithValue("@form", resource.form);
                cmd.Parameters.AddWithValue("@amount", resource.amount);
                cmd.Parameters.AddWithValue("@is_editing", resource.is_editing);
                cmd.Parameters.AddWithValue("@is_license", resource.is_license);
                cmd.ExecuteNonQuery();
            }
        }

        private void AddLicense(resRecord resource)
        {
            string udc_id = Convert.ToString(resource.udc_id);

            string str_cmd = string.Format("Insert Into Resources " +
                   "Values(@name, @author, @url, (Select id From Udc Where id = " + udc_id +
                   "), @create_date, NULL, @license, '', @form, @type_res, @amount, " +
                   "@is_editing, @is_license);");

            using (SqlCommand cmd = new SqlCommand(str_cmd, this.con))
            {
                cmd.Parameters.AddWithValue("@name", resource.name);
                cmd.Parameters.AddWithValue("@author", resource.author);
                cmd.Parameters.AddWithValue("@url", resource.url);
                cmd.Parameters.AddWithValue("@create_date", resource.create_date);
                cmd.Parameters.AddWithValue("@license", resource.license);
                cmd.Parameters.AddWithValue("@type_res", resource.type_res);
                cmd.Parameters.AddWithValue("@form", resource.form);
                cmd.Parameters.AddWithValue("@amount", resource.amount);
                cmd.Parameters.AddWithValue("@is_editing", resource.is_editing);
                cmd.Parameters.AddWithValue("@is_license", resource.is_license);
                cmd.ExecuteNonQuery();
            }
        }

        private void UpdNoLicense(resRecord resource, int id_res)
        {
            string udc_id = Convert.ToString(resource.udc_id);

            string str_cmd = string.Format("Update Resources " +
                    "Set name = @name, author = @author, url = @url, type_res = @type_res, form = @form," + 
                    "amount = @amount, is_editing = @is_editing, is_license = @is_license " +
                    "where id = " + Convert.ToString(id_res));

            using (SqlCommand cmd = new SqlCommand(str_cmd, this.con))
            {
                cmd.Parameters.AddWithValue("@name", resource.name);
                cmd.Parameters.AddWithValue("@author", resource.author);
                cmd.Parameters.AddWithValue("@url", resource.url);
                cmd.Parameters.AddWithValue("@type_res", resource.type_res);
                cmd.Parameters.AddWithValue("@form", resource.form);
                cmd.Parameters.AddWithValue("@amount", resource.amount);
                cmd.Parameters.AddWithValue("@is_editing", resource.is_editing);
                cmd.Parameters.AddWithValue("@is_license", resource.is_license);
                cmd.ExecuteNonQuery();
            }
        }

        private void UpdLicense(resRecord resource, int id_res)
        {
            string udc_id = Convert.ToString(resource.udc_id);

            string str_cmd = string.Format("Update Resources " +
                    "Set name = @name, author = @author, url = @url, license = @license, type_res = @type_res, " + 
                    "form = @form, amount = @amount, is_editing = @is_editing, is_license = @is_license " +
                    "where id = " + Convert.ToString(id_res));

            using (SqlCommand cmd = new SqlCommand(str_cmd, this.con))
            {
                cmd.Parameters.AddWithValue("@name", resource.name);
                cmd.Parameters.AddWithValue("@author", resource.author);
                cmd.Parameters.AddWithValue("@url", resource.url);
                cmd.Parameters.AddWithValue("@create_date", resource.create_date);
                cmd.Parameters.AddWithValue("@license", resource.license);
                cmd.Parameters.AddWithValue("@type_res", resource.type_res);
                cmd.Parameters.AddWithValue("@form", resource.form);
                cmd.Parameters.AddWithValue("@amount", resource.amount);
                cmd.Parameters.AddWithValue("@is_editing", resource.is_editing);
                cmd.Parameters.AddWithValue("@is_license", resource.is_license);
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualize(int id_res)
        {
            SqlConnection();
            string str_cmd = string.Format("UPDATE Resources SET html_code = '';" +
                    "INSERT INTO Validations VALUES(@res_id, @datetime, @is_valid, '');");

            using (SqlCommand cmd = new SqlCommand(str_cmd, this.con))
            {
                cmd.Parameters.AddWithValue("@res_id", id_res);
                cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
                cmd.Parameters.AddWithValue("@is_valid", true);
                cmd.ExecuteNonQuery();
            }

            SqlDispose();
        }

        public void ProvideReserveDate(int id_res)
        {
            SqlConnection();
            string str_cmd = string.Format("UPDATE Resources SET reserve_date = @date WHERE id = @res_id");

            using (SqlCommand cmd = new SqlCommand(str_cmd, this.con))
            {
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@res_id", id_res);
                cmd.ExecuteNonQuery();
            }

            SqlDispose();
        }

        public void Delete(int id_res)
        {
            SqlConnection();

            string str_cmd = string.Format("DELETE FROM Validations WHERE id_resource = @res_id");

            using (SqlCommand cmd = new SqlCommand(str_cmd, this.con))
            {
                cmd.Parameters.AddWithValue("@res_id", id_res);
                cmd.ExecuteNonQuery();
            }

            str_cmd = string.Format("DELETE FROM Resources WHERE id = @res_id");

            using (SqlCommand cmd = new SqlCommand(str_cmd, this.con))
            {
                cmd.Parameters.AddWithValue("@res_id", id_res);
                cmd.ExecuteNonQuery();
            }

            SqlDispose();
        }

        public int GetCount()
        {
            SqlConnection();
            string str_cmd = string.Format("SELECT COUNT (*) FROM Resources");
            var count = 0;

            using (SqlCommand cmd = new SqlCommand(str_cmd, this.con))
            {
                Int32.TryParse(cmd.ExecuteScalar().ToString(), out count);
            }

            SqlDispose();

            return count;
        }
    }

    public struct resRecord
    {
        public string name, author, url;
        public int udc_id;
        public DateTime create_date, reserve_date, license;
        public string html_code;
        public string type_res, form;
        public int amount;
        public Boolean is_editing, is_license;
    }
}