using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;
using System.Linq;
using Novacode;

namespace BmstuLibResources.Core.Reports
{
    public class DocxGenerator
    {
        public readonly string REPORT_TEMPLATES_PATH = HostingEnvironment.MapPath(@"~/App_Data/DocReportTemplates");
        public readonly string TEMP_REPORT_PATH = HostingEnvironment.MapPath(@"~/App_Data");

        public readonly string INCOMING_REPORT = "Поступление.docx";
        public readonly string RETIREMENT_REPORT = "Выбытие.docx";
        public readonly string MOTION_REPORT = "Движение.docx";
        public readonly string STATS_REPORT = "Статистика.docx";
      

        private List<Resources> GetIncomingResourse(DateTime DateFrom, DateTime DateTo)
        {
            List<Resources> result = new List<Resources>();
            ResourcesLibModel db = new ResourcesLibModel();
            var resourses = db.Resources;
            foreach (Resources r in resourses)
            {
                int isFrom = r.create_date.CompareTo(DateFrom);
                int isTo = r.create_date.CompareTo(DateTo);
                if (((isFrom == 1) || (isFrom == 0)) && ((isTo == -1) || (isTo == 0)))
                        result.Add(r);
            }
            return result;
        }

        private List<Resources> GetQuittingResourses(DateTime DateFrom, DateTime DateTo)
        {
            List<Resources> result = new List<Resources>();
            ResourcesLibModel db = new ResourcesLibModel();
            var resourses = db.Resources;
            foreach (Resources r in resourses)
            {
                int isFrom = r.reserve_date.GetValueOrDefault().CompareTo(DateFrom);
                int isTo = r.reserve_date.GetValueOrDefault().CompareTo(DateTo);
                if (((isFrom > 0) || (isFrom == 0)) && ((isTo < 0) || (isTo == 0)))
                    result.Add(r);
            }
            return result;
        }

        private List<DocResourceDescription> GetValidList(DateTime dateFrom, DateTime dateTo)
        {
            List<DocResourceDescription> validData = new List<DocResourceDescription>();
            ResourcesLibModel db = new ResourcesLibModel();
            var resourses = db.Resources;
            foreach (Resources r in resourses)
            {
                if (r.reserve_date != null)
                {
                    if (DateTime.Compare(dateTo, r.reserve_date.GetValueOrDefault()) < 0 &&
                            DateTime.Compare(r.create_date, dateTo) <= 0)
                        validData.Add(new DocResourceDescription(r.name, r.resource_author,
                            true, null, r.create_date, null, 0, r.id));
                }
                else
                    if (DateTime.Compare(r.create_date, dateTo) <= 0)
                        validData.Add(new DocResourceDescription(r.name, r.resource_author,
                            true, null, r.create_date, null, 0, r.id));
            }
            return validData;
        }

        private List<DocResourceDescription> GetNotValidList(DateTime dateFrom, DateTime dateTo)
        {
            List<DocResourceDescription> notValidList = new List<DocResourceDescription>();
            ResourcesLibModel db = new ResourcesLibModel();
            var resourses = db.Resources;
            foreach (Resources r in resourses)
            {
                if (r.reserve_date != null)
                {
                    if (DateTime.Compare(dateFrom, r.reserve_date.GetValueOrDefault()) < 0 &&
                                DateTime.Compare(dateTo, r.reserve_date.GetValueOrDefault()) > 0)
                    {
                        ResourcesLibModel db1 = new ResourcesLibModel();                      
                        var temp = db1.Validations.Where(p => p.resource_id == r.id).OrderByDescending(c => c.check_datetime);
                        if (temp != null)
                        {
                            Validations val = temp.First();
                            notValidList.Add(new DocResourceDescription(r.name, r.resource_author, true,
                                 val.description, r.create_date, r.reserve_date, 0, r.id));
                        }
                        else
                            notValidList.Add(new DocResourceDescription(r.name, r.resource_author, true,
                                 " ", r.create_date, r.reserve_date, 0, r.id));
                    }
                }
            }
            return notValidList;
        }

        private int GetAmountClick(int idRes, DateTime dateIn, DateTime dateTo)
        {
            int amount = 0;
            ResourcesLibModel db = new ResourcesLibModel();
            var stats = db.Stats.Where(
                p => p.resource_id == idRes && p.start_period_datetime >= dateIn &&
                p.finish_period_datetime <= dateTo);
            foreach (Stats s in stats)
            {
                amount += s.visitors_count;
            }
            return amount;
        }

        private List<Int32> GetAmountClickForList(List<DocResourceDescription> data, DateTime dateIn, DateTime dateTo)
        {
            List<Int32> result = new List<Int32>();

            foreach (DocResourceDescription d in data)
            {
                result.Add(GetAmountClick(d.GetId(), dateIn, dateTo));
            }

            return result;
        }

        public void GetStatisticReport(DateTime DateFrom, DateTime DateTo)
        {
            List<DocResourceDescription> notValidList = GetNotValidList(DateFrom, DateTo);
            List<DocResourceDescription> validList = GetValidList(DateFrom, DateTo);
            List<Int32> amountNotValidClick = GetAmountClickForList(notValidList, DateFrom, DateTo);
            List<Int32> amountValidClick = GetAmountClickForList(validList, DateFrom, DateTo);
            string fileName = Path.Combine(TEMP_REPORT_PATH, STATS_REPORT);
            string headLine = "Отчет актуальности и статистики открытых ресурсов";
            string dateString = "Данные представлены за период " + DateFrom.ToShortDateString() +
                "-" + DateTo.ToShortDateString() + ".";
            string incomTitle = "\t\t\tАктуальные ресурсы";
            string quittingTitle = "\t\t\tНеактуальные ресурсы";
            
            var headLineFormat = new Formatting();
            headLineFormat.FontFamily = new System.Drawing.FontFamily("Arial Black");
            headLineFormat.Size = 16D;

            var dateFormat = new Formatting();
            dateFormat.FontFamily = new System.Drawing.FontFamily("Arial");
            dateFormat.Size = 12D;

            var inQuiFormat = new Formatting();
            inQuiFormat.FontFamily = new System.Drawing.FontFamily("Arial");
            inQuiFormat.Size = 12D;
            inQuiFormat.UnderlineStyle = UnderlineStyle.singleLine;

            var itemFormat = new Formatting();
            itemFormat.FontFamily = new System.Drawing.FontFamily("Arial");
            inQuiFormat.Size = 12D;
            inQuiFormat.Position = 30;

            DocX doc = DocX.Create(fileName);
            doc.InsertParagraph(headLine, false, headLineFormat);
            doc.InsertParagraph();
            doc.InsertParagraph(dateString, false, dateFormat);
            doc.InsertParagraph();
            doc.InsertParagraph(incomTitle, false, inQuiFormat);
            if (validList.Count == 0)
                doc.InsertParagraph("Нет ресурсов", false, itemFormat);
            else
            {
                int i = 1;
                foreach (DocResourceDescription des in validList)
                {
                    doc.InsertParagraph(i.ToString() + ". " + des.GetAuthor() + " : " + des.GetName(), false, itemFormat);
                    doc.InsertParagraph("\ta. Дата поступления: " + des.GetCreateDate(), false, itemFormat);
                    doc.InsertParagraph("\tb. Количество посещений за период: " +
                        amountValidClick[i - 1].ToString(), false, itemFormat);
                    doc.InsertParagraph();
                    i++;
                }
            }

            doc.InsertParagraph();
            doc.InsertParagraph(quittingTitle, false, inQuiFormat);
            if (notValidList.Count == 0)
            {
                doc.InsertParagraph();
                doc.InsertParagraph("Нет ресурсов", false, itemFormat);
            }
            else
            {
                int i = 1;
                foreach (DocResourceDescription des in notValidList)
                {
                    doc.InsertParagraph(i.ToString() + ". " + des.GetAuthor() + " : " + des.GetName(), false, itemFormat);
                    doc.InsertParagraph("\ta. Дата поступления: " + des.GetCreateDate(), false, itemFormat);
                    doc.InsertParagraph("\tb. Дата потери актуальности: " + des.GetRemoveDate(), false, itemFormat);
                    doc.InsertParagraph("\tc. Количество посещений за период: " +
                        amountNotValidClick[i - 1].ToString(), false, itemFormat);
                    doc.InsertParagraph("\td. Причина неактуальности: " + des.ValidDescrioption(), false, itemFormat);
                    doc.InsertParagraph();
                    i++;
                }
            }
            try
            {
                doc.SaveAs(fileName);
            }
            catch (UnauthorizedAccessException)
            {
                throw;
            }
        }

        private DocX MakeDocx(string fileName, int year, List<Resources> listRes, int typeReportInt)
        {
            string typeReport = "";
            string headLine = "Реестр суммарного учета сетевых удаленных документов" + "\n";
            string institution = "Учреждение: " + "Библиотека МГТУ им. Баумана";
            if (typeReportInt == 0)
                typeReport = "\t\t\t\t\tПоступление";
            else
                typeReport = "\t\t\t\t\tВыбытие";
                                   
            var headLineFormat = new Formatting();
            headLineFormat.FontFamily = new System.Drawing.FontFamily("Arial");
            headLineFormat.Size = 16D;
            var institutionFormat = new Formatting();
            institutionFormat.FontFamily = new System.Drawing.FontFamily("Arial");
            institutionFormat.Size = 12D;
            var typeReportFormat = new Formatting();
            typeReportFormat.FontFamily = new System.Drawing.FontFamily("Arial");
            typeReportFormat.Size = 14D;

            DocX doc = DocX.Create(fileName);
            Table table = doc.AddTable(3 + listRes.Count, 6);
            table.Alignment = Alignment.center;
            table.Design = TableDesign.TableGrid;

            table.Rows[0].Cells[0].Paragraphs.First().Append("№ записи");
            if (typeReportInt == 0)
                table.Rows[0].Cells[1].Paragraphs.First().Append("Дата записи");
            else
                table.Rows[0].Cells[1].Paragraphs.First().Append("Дата исключения");
            table.Rows[0].Cells[2].Paragraphs.First().Append("Исполнитель");
            table.Rows[0].Cells[3].Paragraphs.First().Append("Количество БД (пакетов)");
            table.Rows[0].Cells[4].Paragraphs.First().Append("Количество назв./экз. в БД (пакетах)");
            table.Rows[0].Cells[5].Paragraphs.First().Append("Примечания");
            table.Rows[1].Cells[0].Paragraphs.First().Append("1");
            table.Rows[1].Cells[1].Paragraphs.First().Append("2");
            table.Rows[1].Cells[2].Paragraphs.First().Append("3");
            table.Rows[1].Cells[3].Paragraphs.First().Append("4");
            table.Rows[1].Cells[4].Paragraphs.First().Append("5");
            table.Rows[1].Cells[5].Paragraphs.First().Append("6");

            int row = 2;
            int i = 1;
            int amountRes = 0;
            foreach (Resources item in listRes)
            {
                table.Rows[row].Cells[0].Paragraphs.First().Append(year.ToString() + "-" + i.ToString());
                if (typeReportInt == 0)
                    table.Rows[row].Cells[1].Paragraphs.First().Append(item.create_date.ToString());
                else
                    table.Rows[row].Cells[1].Paragraphs.First().Append(item.reserve_date.ToString());
                table.Rows[row].Cells[2].Paragraphs.First().Append(item.resource_author);
                table.Rows[row].Cells[3].Paragraphs.First().Append("1");
                table.Rows[row].Cells[4].Paragraphs.First().Append(item.amount_resource.ToString());
                table.Rows[row].Cells[5].Paragraphs.First().Append("Нет");
                row++;
                i++;
                amountRes += item.amount_resource.GetValueOrDefault();
            }

            table.Rows[row].Cells[0].Paragraphs.First().Append("Итого за " + year.ToString() + "г:");
            table.Rows[row].Cells[4].Paragraphs.First().Append(amountRes.ToString());
            doc.InsertParagraph(headLine, false, headLineFormat);
            doc.InsertParagraph(typeReport, false, typeReportFormat);
            doc.InsertParagraph();
            doc.InsertParagraph(institution, false, institutionFormat);
            doc.InsertParagraph();
            doc.InsertTable(table);
            return doc;
        }

        public void GetIncomingReport(int year)
        {
            DateTime dateStart = new DateTime(year, 1, 1);
            DateTime dateEnd = new DateTime(year, 12, 31);
            List<Resources> incomingList = GetIncomingResourse(dateStart, dateEnd);
            /*var authorList = new Dictionary<string, List<Resources>>(); 

            foreach (Resources item in incomingList)
            {
                if (!authorList.ContainsKey(item.resource_author))
                {
                    authorList.Add(item.resource_author, new List<Resources>());
                    authorList[item.resource_author].Add(item);
                }
                else
                    authorList[item.resource_author].Add(item);
            }*/
            string fileName = Path.Combine(TEMP_REPORT_PATH, INCOMING_REPORT);
            DocX doc = MakeDocx(fileName, year, incomingList, 0);
            try
            {
                doc.SaveAs(fileName);
            }
            catch (UnauthorizedAccessException)
            {
                throw;
            }
        }

        public void GetRetirementReport(int year)
        {
            DateTime dateStart = new DateTime(year, 1, 1);
            DateTime dateEnd = new DateTime(year, 12, 31);
            List<Resources> retirementList = GetQuittingResourses(dateStart, dateEnd);
            /*var authorList = new Dictionary<string, List<Resources>>(); 

            foreach (Resources item in incomingList)
            {
                if (!authorList.ContainsKey(item.resource_author))
                {
                    authorList.Add(item.resource_author, new List<Resources>());
                    authorList[item.resource_author].Add(item);
                }
                else
                    authorList[item.resource_author].Add(item);
            }*/
            string fileName = Path.Combine(TEMP_REPORT_PATH, RETIREMENT_REPORT);
            DocX doc = MakeDocx(fileName, year, retirementList, 1);
            try
            {
                doc.SaveAs(fileName);
            }
            catch (UnauthorizedAccessException)
            {
                throw;
            }
        }

        private int GetAmountValidResource(DateTime dateFrom, DateTime dateTo)
        {
            int result = 0;
            ResourcesLibModel db = new ResourcesLibModel();
            var resourses = db.Resources;

            foreach (Resources r in resourses)
            {
                if (r.reserve_date != null)
                {
                    if (DateTime.Compare(dateTo, r.reserve_date.GetValueOrDefault()) < 0 &&
                                DateTime.Compare(r.create_date, dateTo) <= 0)
                        result += r.amount_resource.GetValueOrDefault();
                    }
                else
                    if (DateTime.Compare(r.create_date, dateTo) <= 0)
                        result += r.amount_resource.GetValueOrDefault();
            }
            return result;
        }

        private int GetAmountNotValidResource(DateTime dateFrom, DateTime dateTo)
        {
            int result = 0;
            ResourcesLibModel db = new ResourcesLibModel();
            var resourses = db.Resources;

            foreach (Resources r in resourses)
            {
                if (r.reserve_date != null)
                    if (DateTime.Compare(dateFrom, r.reserve_date.GetValueOrDefault()) < 0 &&
                                DateTime.Compare(dateTo, r.reserve_date.GetValueOrDefault()) > 0)
                    {
                        ResourcesLibModel db1 = new ResourcesLibModel();
                        var temp = db1.Validations.Where(p => p.resource_id == r.id);
                        Validations val = temp.First();
                        result += r.amount_resource.GetValueOrDefault();
                    }
            }
            return result;
        }

        public void GetMotionReport(int year)
        {
            string fileName = Path.Combine(TEMP_REPORT_PATH, MOTION_REPORT);
            DateTime dateStart = new DateTime(year, 1, 1);
            DateTime dateEnd = new DateTime(year, 12, 31);
            int yearPrev = year - 1;
            DateTime datePrivStart = new DateTime(yearPrev, 12, 30);
            DateTime datePrivEnd = new DateTime(yearPrev, 12, 31);

            int amountRetirement = 0;
            int amountIncoming = 0;
            var temp1 = GetQuittingResourses(dateStart, dateEnd);
            foreach (Resources item in temp1)
            {
                amountRetirement += item.amount_resource.GetValueOrDefault();
            }

            var temp2 = GetIncomingResourse(dateStart, dateEnd);
            foreach (Resources item in temp2)
            {
                amountIncoming += item.amount_resource.GetValueOrDefault();
            }

            int amountValidStart = GetAmountValidResource(datePrivStart, datePrivEnd);
            int amountValidEnd = GetAmountValidResource(new DateTime(year, 12, 30), dateEnd);

            string typeReport = "\t\t\t\tИтоги движения ресурсов";
            string headLine = "Реестр суммарного учета сетевых удаленных документов" + "\n";
            string institution = "Учреждение: " + "Библиотека МГТУ им. Баумана";
 
            var headLineFormat = new Formatting();
            headLineFormat.FontFamily = new System.Drawing.FontFamily("Arial");
            headLineFormat.Size = 16D;
            var institutionFormat = new Formatting();
            institutionFormat.FontFamily = new System.Drawing.FontFamily("Arial");
            institutionFormat.Size = 12D;
            var typeReportFormat = new Formatting();
            typeReportFormat.FontFamily = new System.Drawing.FontFamily("Arial");
            typeReportFormat.Size = 14D;

            DocX doc = DocX.Create(fileName);
            Table tableHead = doc.AddTable(1, 10);
            Table table = doc.AddTable(3, 10);
            table.Alignment = Alignment.center;
            table.Design = TableDesign.TableGrid;
            tableHead.Alignment = Alignment.center;
            table.Design = TableDesign.TableGrid;

            tableHead.Rows[0].Cells[1].SetBorder(TableCellBorderType.Right, 
                    new Border(BorderStyle.Tcbs_none, BorderSize.one, 1, System.Drawing.Color.White));
            tableHead.Rows[0].Cells[2].SetBorder(TableCellBorderType.Left,
                    new Border(BorderStyle.Tcbs_none, BorderSize.one, 1, System.Drawing.Color.White));
            tableHead.Rows[0].Cells[3].SetBorder(TableCellBorderType.Right,
                    new Border(BorderStyle.Tcbs_none, BorderSize.one, 1, System.Drawing.Color.White));
            tableHead.Rows[0].Cells[4].SetBorder(TableCellBorderType.Left,
                    new Border(BorderStyle.Tcbs_none, BorderSize.one, 1, System.Drawing.Color.White));
            tableHead.Rows[0].Cells[5].SetBorder(TableCellBorderType.Right,
                    new Border(BorderStyle.Tcbs_none, BorderSize.one, 1, System.Drawing.Color.White));
            tableHead.Rows[0].Cells[6].SetBorder(TableCellBorderType.Left,
                    new Border(BorderStyle.Tcbs_none, BorderSize.one, 1, System.Drawing.Color.White));
            tableHead.Rows[0].Cells[8].SetBorder(TableCellBorderType.Right,
                    new Border(BorderStyle.Tcbs_none, BorderSize.one, 1, System.Drawing.Color.White));
            tableHead.Rows[0].Cells[9].SetBorder(TableCellBorderType.Left,
                    new Border(BorderStyle.Tcbs_none, BorderSize.one, 1, System.Drawing.Color.White));
            tableHead.Rows[0].Cells[0].Paragraphs.First().Append("Сроки отчетного периода");
            tableHead.Rows[0].Cells[1].Paragraphs.First().Append("Состояло на начало отчетного периода");
            tableHead.Rows[0].Cells[2].Paragraphs.First().Append("");
            tableHead.Rows[0].Cells[3].Paragraphs.First().Append("Оформлено в доступ");
            tableHead.Rows[0].Cells[4].Paragraphs.First().Append("");
            tableHead.Rows[0].Cells[5].Paragraphs.First().Append("Доступ прекращен");
            tableHead.Rows[0].Cells[6].Paragraphs.First().Append("");
            tableHead.Rows[0].Cells[7].Paragraphs.First().Append("Изменения в составе БД (пакетов)");
            tableHead.Rows[0].Cells[8].Paragraphs.First().Append("Состоит на конец отчетного периода");
            tableHead.Rows[0].Cells[9].Paragraphs.First().Append("");

            table.Rows[0].Cells[0].Paragraphs.First().Append("");
            table.Rows[0].Cells[1].Paragraphs.First().Append("Кол-во БД (пакетов)");
            table.Rows[0].Cells[2].Paragraphs.First().Append("Кол-во назв./.экз.");
            table.Rows[0].Cells[3].Paragraphs.First().Append("Количество БД (пакетов)");
            table.Rows[0].Cells[4].Paragraphs.First().Append("Кол-во назв./.экз.");
            table.Rows[0].Cells[5].Paragraphs.First().Append("Кол-во БД (пакетов)");
            table.Rows[0].Cells[6].Paragraphs.First().Append("Кол-во назв./.экз.");
            table.Rows[0].Cells[7].Paragraphs.First().Append("Кол-во БД (пакетов)");
            table.Rows[0].Cells[8].Paragraphs.First().Append("Кол-во БД (пакетов)");
            table.Rows[0].Cells[9].Paragraphs.First().Append("Кол-во назв./.экз.");
            table.Rows[1].Cells[0].Paragraphs.First().Append("1");
            table.Rows[1].Cells[1].Paragraphs.First().Append("2");
            table.Rows[1].Cells[2].Paragraphs.First().Append("3");
            table.Rows[1].Cells[3].Paragraphs.First().Append("4");
            table.Rows[1].Cells[4].Paragraphs.First().Append("5");
            table.Rows[1].Cells[5].Paragraphs.First().Append("6");
            table.Rows[1].Cells[6].Paragraphs.First().Append("7");
            table.Rows[1].Cells[7].Paragraphs.First().Append("8");
            table.Rows[1].Cells[8].Paragraphs.First().Append("10");
            table.Rows[1].Cells[9].Paragraphs.First().Append("11");

            table.Rows[2].Cells[0].Paragraphs.First().Append(dateStart.ToString() + "-" + dateEnd.ToString());
            table.Rows[2].Cells[2].Paragraphs.First().Append(amountValidStart.ToString());
            table.Rows[2].Cells[4].Paragraphs.First().Append(amountIncoming.ToString());
            table.Rows[2].Cells[6].Paragraphs.First().Append(amountRetirement.ToString());
            table.Rows[2].Cells[9].Paragraphs.First().Append(amountValidEnd.ToString()); 

            doc.InsertParagraph(headLine, false, headLineFormat);
            doc.InsertParagraph(typeReport, false, typeReportFormat);
            doc.InsertParagraph();
            doc.InsertParagraph(institution, false, institutionFormat);
            doc.InsertParagraph();
            doc.InsertTable(tableHead);
            doc.InsertTable(table);
            try
            {
                doc.SaveAs(fileName);
            }
            catch (UnauthorizedAccessException)
            {
                throw;
            }
        }
    }
}