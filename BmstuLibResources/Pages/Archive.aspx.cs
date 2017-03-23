using System;
using System.Web.UI;


namespace BmstuLibResources
{
    public partial class Archive : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (gvArchive.Rows.Count == 0)
            {
                lblInfo.Visible = true;
                lblInfo.Text = "Архив пуст.";
            }
            else
            {
                lblInfo.Visible = false;
            }
        }
    }
}