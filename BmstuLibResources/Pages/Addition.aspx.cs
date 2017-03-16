using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;


namespace BmstuLibResources
{
    public partial class Addition : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (ResourcesLibModel db = new ResourcesLibModel())
            {
                var udc = db.Udc;
                foreach (Udc item in udc)
                {
                    DropDownListUdc.Items.Add(item.udc_index.ToString() + " " + item.description.ToString());
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string udc_index;
            string name;
            string type;
            string author;
            string url;
            string form;
            DateTime licenDate = DateTime.Now;
            bool isLicense;
            int amount;

            SqlConnection con = null;
            var con_str = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            try
            {
                con = new SqlConnection(con_str);
                con.Open();
            }
            catch (SqlException)
            {
                Response.Write("<script>alert('Ошибка подключени к базе данных!');</script>");
                throw;
            }

            try {
                udc_index = DropDownListUdc.SelectedValue.Split(' ')[0];
                name = txtBName.Text;
                type = listType.SelectedValue;
                author = TexBoxOwner.Text;
                url = txtBUrl.Text;
                amount = Convert.ToInt32(TextBoxAmount.Text);
                form = fromResurce.SelectedValue;
                if (licenseDate.Text != "")
                {
                    licenDate = Convert.ToDateTime(licenseDate.Text);
                    isLicense = true;
                }
                else
                    isLicense = false;
                if (amount <= 0)
                    throw new InvalidCastException();
            } catch(InvalidCastException)
            {
                Response.Write("<script>alert('Некорректный ввод данных!');</script>");
                return;
            }
            
            if (String.IsNullOrWhiteSpace(name) || String.IsNullOrWhiteSpace(author) 
                    || String.IsNullOrWhiteSpace(url))
            {
                Response.Write("<script>alert('Некорректный ввод данных!');</script>");
                return;
            }

            int id_udc = 0;
            using (ResourcesLibModel db = new ResourcesLibModel())
            {
                var udc = db.Udc.Where(p => p.udc_index.CompareTo(udc_index) == 0);
                if (udc == null)
                    return;
                id_udc = udc.First().id;
            }
            string str_cmd = "";
            if (isLicense)
                str_cmd = string.Format("Insert Into Resources (name, url, resource_author, amount_resource, udc_id, create_date, resource_type, html_code, resource_form, license_date) Values(@name, @url, @resource_author, @amount_resource,  @udc_id,  @create_date, @resource_type, @html_code, @resource_form, @license_date)");
            else
                str_cmd = string.Format("Insert Into Resources (name, url, resource_author, amount_resource, udc_id, create_date, resource_type, html_code, resource_form) Values(@name, @url, @resource_author, @amount_resource,  @udc_id,  @create_date, @resource_type, @html_code, @resource_form)");
            using (SqlCommand cmd = new SqlCommand(str_cmd, con))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@resource_author", author);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@url", url);
                    cmd.Parameters.AddWithValue("@amount_resource", amount);
                    cmd.Parameters.AddWithValue("@udc_id", id_udc);
                    cmd.Parameters.AddWithValue("@create_date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@resource_type", type);
                    cmd.Parameters.AddWithValue("@html_code", "");
                    cmd.Parameters.AddWithValue("@resource_form", form);
                    if (isLicense)
                        cmd.Parameters.AddWithValue("@license_date", licenDate);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException)
                {                 
                    Response.Write("<script>alert('Ошибка добавления!');</script>");
                    return;
                }
                catch (System.FormatException ex)
                {
                    Response.Write("<script>alert('Ошибка добавления!');</script>");
                    return;
                }
                Response.Write("<script>alert('Добавлен новый источник!');</script>");
            }

        }
    }
}