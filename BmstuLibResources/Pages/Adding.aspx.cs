using System;
using System.Web.UI;



namespace BmstuLibResources
{
    public partial class Adding : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (ResourcesLibModel db = new ResourcesLibModel())
            {
                var udc = db.Udc;
                foreach (Udc item in udc)
                {
                    listUdc.Items.Add(item.udc_index.ToString() + " " + item.description.ToString());
                }
            }

            if ((listType.SelectedIndex == 1) || (listType.SelectedIndex == 3))
                Enable_Amount();
            else
                Disable_Amount();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            resRecord resource = SaveRecord();

            SqlCommands cmd = new SqlCommands();

            cmd.Add(resource);

            Response.Redirect("~/Pages/Validate.aspx");
        }

        private resRecord SaveRecord()
        {   
            resRecord resource = new resRecord();

            resource.name = txtName.Text;
            resource.author = txtAuthor.Text;
            resource.url = txtUrl.Text;

            resource.is_editing = isEditing();
            resource.is_license = isLicense();

            resource.html_code = "";

            resource.create_date = DateTime.Now;
            if (isLicense())
                resource.license = Convert.ToDateTime(txtLicStart.Text);

            resource.udc_id = listUdc.SelectedIndex + 1;
            resource.type_res = listType.Text;
            resource.form = listForm.Text;

            resource.amount = Convert.ToInt32(txtAmount.Text);

            return resource;
        }

        private Boolean isEditing()
        {
            if (String.IsNullOrWhiteSpace(txtName.Text) || String.IsNullOrWhiteSpace(txtAuthor.Text)
                    || String.IsNullOrWhiteSpace(txtUrl.Text) || String.IsNullOrWhiteSpace(txtLicStart.Text)
                    || String.IsNullOrWhiteSpace(txtAmount.Text))
                return true;

            return false;
        }

        private Boolean isLicense()
        {
            if (listType.SelectedIndex > 1)
                return true;
            else
                return false;
        }

        private void Enable_Amount()
        {
            txtAmount.Enabled = true;
            lblAmount.Enabled = true;
        }

        private void Disable_Amount()
        {
            txtAmount.Enabled = false;
            lblAmount.Enabled = false;

            txtAmount.Text = "1";
        }

        private void Enable_License()
        {
            txtLicStart.Enabled = true;
            //txtLicEnd.Enabled = true;

            if (txtLicStart.Text == "")
                txtLicStart.Text = DateTime.Today.ToString();
        }

        private void Disable_License()
        {
            txtLicStart.Enabled = false;
            txtLicEnd.Enabled = false;
        }

        protected void listType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((listType.SelectedIndex == 1) || (listType.SelectedIndex == 3))
                Enable_Amount();
            else
                Disable_Amount();

            if ((listType.SelectedIndex == 0) || (listType.SelectedIndex == 1))
                Disable_License();
            else
                Enable_License();
        }

        private void GetResponseDialogMessage(string msg)
        {
            Response.Write("<script>alert('" + msg + "');</script>");
        }
    }
}