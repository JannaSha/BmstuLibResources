using System;
using System.Web.UI;
using BmstuLibResources.Core.Valitadion;

namespace BmstuLibResources
{
    public partial class Validate : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommands cmd = new SqlCommands();

            lblCount.Text = "Количество ресурсов в базе данных: " + cmd.GetCount();

            if (cmd.GetCount() != 0)
            {
                lblInfo.Visible = true;
                lblInfo.Text = "Для удаления и редактирования необходимо выбрать ресурс.";
            }
            else
                lblInfo.Visible = false;
        }

        protected void btnActualize_Click(object sender, EventArgs e)
        {
            Validator validator = new Validator();
            try
            {
                validator.Validate();
            }
            catch (System.Net.WebException exc)
            {
                GetResponseDialogMessage("Ошибка подключения к сети. Проверьте подключение и попробуйте заново.");
                return;
            }

            //Response.Redirect("~/Pages/Validate.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = SelectRecord();

            if (id != -1)
            {
                SqlCommands cmd = new SqlCommands();

                cmd.Delete(id);
                gvResources.DataBind();

                GetResponseDialogMessage("Запись успешно удалена!");
            }

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int id = SelectRecord();

            if (id != -1)
                Response.Redirect("~/Pages/Editing.aspx?id=" + id.ToString());
        }

        private int SelectRecord()
        {
            int id;
            try
            {
                id = Convert.ToInt32(gvResources.SelectedRow.Cells[1].Text);
            }
            catch (NullReferenceException exc)
            {
                GetResponseDialogMessage("Необходимо выбрать запись.");
                return -1;
            }

            return id;
        }

        private void GetResponseDialogMessage(string msg)
        {
            Response.Write("<script>alert('" + msg + "');</script>");
        }
    }
}