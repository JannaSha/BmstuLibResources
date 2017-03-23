using System;

namespace BmstuLibResources
{
    public partial class Irrelevant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (gvIResources.Rows.Count == 0)
            {
                lblInfo.Visible = true;
                lblInfo.Text = "На данный момент все ресурсы актуальны.";
                btnHandActualize.Visible = false;
                btnReserve.Visible = false;
            }
            else
            {
                lblInfo.Text = "Выберите ресурс и произведите над ним одно из действий.";
                btnHandActualize.Visible = true;
                btnReserve.Visible = true;
            }
        }

        protected void btnReserve_Click(object sender, EventArgs e)
        {
            int id = SelectRecord();

            if (id == -1)
                return;

            SqlCommands cmd = new SqlCommands();
            cmd.ProvideReserveDate(id);

            //GetResponseDialogMessage("Ресурс исключен.");

            Response.Redirect("~/Pages/Irrelevant.aspx");
        }

        protected void btnHandActualize_Click(object sender, EventArgs e)
        {
            int id = SelectRecord();

            if (id == -1)
                return;

            SqlCommands cmd = new SqlCommands();
            cmd.Actualize(id);

            //GetResponseDialogMessage("Ресурс актуализирован вручную.");

            Response.Redirect("~/Pages/Irrelevant.aspx");
        }

        private int SelectRecord()
        {
            int id;
            try
            {
                id = Convert.ToInt32(gvIResources.SelectedRow.Cells[1].Text);
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