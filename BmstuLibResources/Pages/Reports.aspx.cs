using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using BmstuLibResources.Core.Reports;

namespace BmstuLibResources
{
    public partial class Reports : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    listYear1.DataSource = GetYearsDataSource();
                    listYear1.DataTextField = "Text";
                    listYear1.DataValueField = "Value";

                    listYear1.DataBind();

                    listYear2.DataSource = GetYearsDataSource();
                    listYear2.DataTextField = "Text";
                    listYear2.DataValueField = "Value";

                    listYear2.DataBind();
                }
                catch (Exception exc)
                {
                    System.Diagnostics.Debug.WriteLine(exc);
                }
            }

        }

        protected void btnGetReport_Click(object sender, EventArgs e)
        {
            int year = Convert.ToInt32(listYear1.SelectedValue);
            DocxGenerator docxGenerator = new DocxGenerator();
            string fileName, reportPath;

            if (listType.SelectedIndex == 0)
            {
                docxGenerator.GetIncomingReport(year);
                reportPath = Path.Combine(docxGenerator.TEMP_REPORT_PATH, docxGenerator.INCOMING_REPORT);
                fileName = docxGenerator.INCOMING_REPORT;
            }
            else if (listType.SelectedIndex == 1)
            {
                docxGenerator.GetRetirementReport(year);
                reportPath = Path.Combine(docxGenerator.TEMP_REPORT_PATH, docxGenerator.RETIREMENT_REPORT);
                fileName = docxGenerator.RETIREMENT_REPORT;
            }
            else
            {
                docxGenerator.GetMotionReport(year);
                reportPath = Path.Combine(docxGenerator.TEMP_REPORT_PATH, docxGenerator.MOTION_REPORT);
                fileName = docxGenerator.MOTION_REPORT;
            }

            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "text/plain";
            response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ";");
            response.TransmitFile(reportPath);
            response.Flush();
            response.End();
        }


        public IEnumerable<ListItem> GetYearsDataSource()
        {
            int currentYear = DateTime.Now.Year;
            const int startYear = 2015;
            List<ListItem> lItems = new List<ListItem>();
            for (int year = startYear; year <= currentYear; year++)
                lItems.Add(new ListItem(year.ToString(), year.ToString()));
            return (IEnumerable<ListItem>)lItems;
        }

        protected void btnGetStats_Click(object sender, EventArgs e)
        {
            string fileName = "Статистика(" + listMonth.SelectedValue + "-" + listYear2.SelectedValue +").docx";
            int year = Convert.ToInt32(listYear2.SelectedValue);
            int month = listMonth.SelectedIndex + 1;
            DateTime upDate = new DateTime(year, month, 1);
            DateTime toDate = new DateTime(year, month, DateTime.DaysInMonth(year, month));

            DocxGenerator docxGenerator = new DocxGenerator();
            string reportPath = Path.Combine(docxGenerator.TEMP_REPORT_PATH, docxGenerator.STATS_REPORT);

            docxGenerator.GetStatisticReport(upDate, toDate);

            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "text/plain";
            response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ";");
            response.TransmitFile(reportPath);
            response.Flush();
            response.End();
        }
    }
}