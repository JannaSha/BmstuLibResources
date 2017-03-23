using System;
using System.Web.UI;


namespace BmstuLibResources
{
    public partial class Edditing : Page
    {
        private int id;
        private resRecord record;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                id = Int32.Parse(Request.QueryString["id"]);

                if (id != -1)
                {
                    SqlCommands cmd = new SqlCommands();
                    record = cmd.GetRecord(id);
                }
            }
            else
                id = -1;

            if (!IsPostBack)
            {
                using (ResourcesLibModel db = new ResourcesLibModel())
                {
                    var udc = db.Udc;
                    foreach (Udc item in udc)
                    {
                        listUdc.Items.Add(item.udc_index.ToString() + " " + item.description.ToString());
                    }
                }
                if (id != -1)
                {
                    txtAmount.Text = record.amount.ToString();
                    txtAuthor.Text = record.author;
                    txtName.Text = record.name;
                    txtUrl.Text = record.url;
                    listUdc.SelectedIndex = record.udc_id - 1;

                    for (int i = 0; String.Compare(listType.Text, record.type_res, true) != 0; i++)
                        listType.SelectedIndex = i;

                    for (int i = 0; String.Compare(listForm.Text, record.form, true) != 0; i++)
                        listForm.SelectedIndex = i;

                    if (record.is_license)
                    {
                        Enable_License();
                        txtLicStart.Text = Convert.ToString(record.license.ToShortDateString());
                    }

                    if ((listType.SelectedIndex == 1) || (listType.SelectedIndex == 3))
                        Enable_Amount();
                    else
                        Disable_Amount();
                }
            }
        }

        protected void btnUpd_Click(object sender, EventArgs e)
        {
            resRecord resource = SaveRecord();

            SqlCommands cmd = new SqlCommands();

            cmd.Update(resource, id);

            GetResponseDialogMessage("Ресурс изменен!");

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

            resource.create_date = record.create_date;
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