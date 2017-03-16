using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BmstuLibResources.Core.UrlClickStats;

namespace BmstuLibResources.Pages
{
    public partial class ValidList : System.Web.UI.Page
    {

        private IUrlClickDataHandler urlClickHandler = new PerMonthUrlClickHandler();

        private List<Resources> GetListByTypeId(int typeId, string str_udc)
        {
            List<Resources> result = new List<Resources>();
            using (ResourcesLibModel db = new ResourcesLibModel())
            {
                var resourses = db.Resources;
                var udc = db.Udc;
                foreach (Resources item in resourses)
                {
                    if (item.udc_id.ToString().CompareTo(typeId.ToString()) == 0)
                        result.Add(item);
                }
            }
            return result;
        }

        private void ShowList(List<Resources> list)
        {
            PlaceHolder.Controls.Clear();

            PlaceHolder.Controls.Add(new LiteralControl("<br><ol>"));
            
            // Создаем список ссылок на ресурсы и вставляем в страницу
            foreach (Resources item in list)
            {
                LinkButton link = new LinkButton();
                link.ID = "LinkButton" + item.id;
                link.Font.Size = FontUnit.Larger;
                link.Text = String.Format("{0} - {1}", item.name, item.url);

                link.CommandArgument = String.Format("{0} {1}", item.id, item.url);

                // Обработчик клика на ссылку
                link.Click += new System.EventHandler(this.LinkButton_Click);

                PlaceHolder.Controls.Add(new LiteralControl("<li>"));
                PlaceHolder.Controls.Add(link);
                PlaceHolder.Controls.Add(new LiteralControl("</li>"));
            }

            PlaceHolder.Controls.Add(new LiteralControl("</ol>"));

            LabelMessage.Text = "<h4>Ресурсы по теме:</h4><hr>";
        }


        protected void LinkButton_Click(Object sender, EventArgs e)
        {
            LinkButton link = (LinkButton)sender;
            string[] args = link.CommandArgument.Split(' ');
            int id = Int32.Parse(args[0]);
            string url = args[1];

            // Регистрация перехода по ссылке в БД
            urlClickHandler.RegisterUrlClick(id, DateTime.Now);
            Response.Redirect(url);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            using (ResourcesLibModel db = new ResourcesLibModel())
            {
                var udc = db.Udc;
                foreach (Udc item in udc)
                {
                    DropDownListUdc.Items.Add(item.udc_index.ToString() + " " + "|" + " "
                            + item.description.ToString());
                }
            }
            int id_udc = 0;
            string str_udc = DropDownListUdc.SelectedValue.Split(' ')[0];

                using (ResourcesLibModel db = new ResourcesLibModel())
                {
                    var udc = db.Udc.Where(p => p.udc_index.CompareTo(str_udc) == 0);
                    if (udc == null)
                        return;
                    id_udc = udc.First().id;
                }
                ShowList(GetListByTypeId(id_udc, str_udc));
        }

        protected void Index_Changed(object sender, EventArgs e)
        {
            LabelMessage.Text = " ";
            int id_udc = 0;
            string str_udc = DropDownListUdc.SelectedValue.Split(' ')[0];
            using (ResourcesLibModel db = new ResourcesLibModel())
            {
                var udc = db.Udc.Where(p => p.udc_index.CompareTo(str_udc) == 0);
                if (udc == null)
                    return;
                id_udc = udc.First().id;
            }
            ShowList(GetListByTypeId(id_udc, str_udc));
        }

        void f(object sender, EventArgs e)
        {
            var link = (LinkButton)sender;
            Response.Write("<script>alert('Некорректный ввод данных!');</script>");
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            string request = TextBoxSearch.Text;
            List<Resources> result_list = new List<Resources>();
            if (String.IsNullOrWhiteSpace(request))
                LabelMessage.Text = "Пустой запрос";
            else
            {
                using (ResourcesLibModel db = new ResourcesLibModel())
                {
                    var resourses = db.Resources;
                    foreach (Resources item in resourses)
                    {
                        if (item.name == null)
                            item.name = " ";
                        if (item.resource_author == null)
                            item.resource_author = " ";
                        if (item.name.ToLower().Contains(request.ToLower()) ||
                                    item.resource_author.ToLower().Contains(request.ToLower()))
                            result_list.Add(item);
                    }
                }
                if (result_list.Count == 0)
                    LabelMessage.Text = "Поиск не дал результатов";
                else
                    ShowList(result_list);
            }

        }
    }
}