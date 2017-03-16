using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Data;
using BmstuLibResources.Core.Valitadion;


namespace BmstuLibResources
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                FillValidResourcesGridView();
                FillInvalidResourcesGridView();
            }
        }

        private void FillValidResourcesGridView()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string selectSQL = @"SELECT Res.id, [license_date], [resource_form], [name], [resource_author], [url], Udc.description as udc, [create_date], [resource_type], [amount_resource]
                       FROM [Resources] Res JOIN [Udc] Udc ON Udc.id = Res.udc_id
                       WHERE 
					    (
							SELECT TOP 1 v.is_valid FROM Validations v
							WHERE v.resource_id = Res.id
							ORDER BY v.check_datetime DESC
					    ) = 1 
					   OR NOT EXISTS
					   (
							SELECT v.id FROM Validations v
							WHERE v.resource_id = Res.id
					   )";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            adapter.Fill(ds);


            gvValidResources.DataSource = ds;
            gvValidResources.DataBind();
        }

        private void FillInvalidResourcesGridView()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string selectSQL = @"SELECT Res.id, [name], [license_date], [resource_form], [resource_author], [url], Udc.description as udc, [create_date], [resource_type], 
					   (SELECT TOP 1 v.description FROM Validations v
					    WHERE v.resource_id = Res.id
					    ORDER BY v.check_datetime) as error
                       FROM [Resources] Res JOIN [Udc] Udc ON Udc.id = Res.udc_id
					   WHERE 
					   (
							SELECT TOP 1 v.is_valid FROM Validations v
							WHERE v.resource_id = Res.id
							ORDER BY v.check_datetime DESC
					   ) = 0 AND Res.reserve_date IS NULL";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            adapter.Fill(ds);

            gvInvalidResources.DataSource = ds;
            gvInvalidResources.DataBind();
        }


        protected void validateBtn_Click(object sender, EventArgs e)
        {
            Validator validator = new Validator();
            try
            {
                validator.Validate();
            }
            catch (System.Net.WebException exc)
            {
                GetResponseDialogMessage("Ошибка подключения к сети. Проверьте подключение и попробуйте заново.");
            }
            GetResponseDialogMessage("Валидация завершена!");
            Page_Load(sender, e);
        }

        private void GetResponseDialogMessage(string msg)
        {
            Response.Write("<script>alert('" + msg + "');</script>");
        }

        protected void RemoveResourceBtn_Click(object sender, EventArgs e)
        {
            int id;
            try
            {
                id = Convert.ToInt32(gvInvalidResources.SelectedRow.Cells[1].Text);
            }
            catch (NullReferenceException exc)
            {
                GetResponseDialogMessage("Необходимо выбрать запись.");
                return;
            }

            var connectionStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionStr);
                conn.Open();
                string cmd = "UPDATE Resources SET reserve_date = @date WHERE id = @res_id";
                SqlCommand sqlCmd = new SqlCommand(cmd, conn);
                sqlCmd.Parameters.AddWithValue("@date", DateTime.Now);
                sqlCmd.Parameters.AddWithValue("@res_id", id);
                sqlCmd.ExecuteNonQuery();
            }
            catch (SqlException exc)
            {
                GetResponseDialogMessage("Ошибка подключения к базе данных.");
            }


            GetResponseDialogMessage("Ресурс исключен.");
            Page_Load(sender, e);
        }

        protected void ActualizeResourceBtn_Click(object sender, EventArgs e)
        {
            int id;
            try
            {
                id = Convert.ToInt32(gvInvalidResources.SelectedRow.Cells[1].Text);
            }
            catch (NullReferenceException exc)
            {
                GetResponseDialogMessage("Необходимо выбрать запись.");
                return;
            }

            var connectionStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionStr);
                conn.Open();
                string cmd = "UPDATE Resources SET html_code = '';" +
                    "INSERT INTO Validations VALUES(@res_id, @datetime, @is_valid, '');";
                SqlCommand sqlCmd = new SqlCommand(cmd, conn);
                sqlCmd.Parameters.AddWithValue("@res_id", id);
                sqlCmd.Parameters.AddWithValue("@datetime", DateTime.Now);
                sqlCmd.Parameters.AddWithValue("@is_valid", true);
                sqlCmd.ExecuteNonQuery();
            }
            catch (SqlException exc)
            {
                GetResponseDialogMessage("Ошибка подключения к базе данных.");
            }

            GetResponseDialogMessage("Ресурс добавлен в список валидных.");
            Page_Load(sender, e);
        }

    }
}