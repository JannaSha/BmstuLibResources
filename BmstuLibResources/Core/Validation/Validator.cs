using System;

namespace BmstuLibResources.Core.Valitadion
{
    public class Validator
    {
        private ResourcesLibModel db = new ResourcesLibModel();
        private DateTime currentDateTime;
        private IHtmlContentAnalyzer contentAnalyzer = new HtmlAgilityPackContentAnalyzer();


        private void ValidateResource(Resources res)
        {
            System.Net.WebResponse resp;
            System.Net.WebRequest reqGET = System.Net.WebRequest.Create(res.url);
            try
            {
                resp = reqGET.GetResponse();
            }
            catch (System.Net.WebException exc)
            {

                if (exc.Message.Contains("404"))
                {
                    AddResourceToValidationsTable(res, "Страница по заданому адресу не найдена");
                }
                else if (exc.Message.Contains("500"))
                {
                    AddResourceToValidationsTable(res, "Ошибка сервера");
                }
                else { throw exc; }
                return;
            }

            System.IO.Stream stream = resp.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            string html = sr.ReadToEnd();


            // Если поле html_code ресурса еще не заполнено
            if (String.IsNullOrWhiteSpace(res.html_code))
            {
                res.html_code = contentAnalyzer.GetContentTextFromHtml(html);
                AddResourceToValidationsTable(res);
                return;
            }

            // Иначе - проверяем
            if (contentAnalyzer.IsEqual(res.html_code, html))
            {
                AddResourceToValidationsTable(res);
            }
            else
            {
                AddResourceToValidationsTable(res, "Содержание ресурса не соответствует требованиям");
            }
        }

        private void AddResourceToValidationsTable(Resources resource, bool isValid, String msg)
        {
            Validations validation = new Validations();
            validation.id_resource = resource.id;
            validation.is_valid = isValid;
            validation.description = msg;
            validation.check_date = currentDateTime;
            db.Validations.Add(validation);
        }

        private void AddResourceToValidationsTable(Resources resource)
        {
            AddResourceToValidationsTable(resource, true, null);
        }

        private void AddResourceToValidationsTable(Resources resource, String msg)
        {
            AddResourceToValidationsTable(resource, false, msg);
        }

        public void Validate()
        {
            currentDateTime = DateTime.Now;
            var resourses = db.Resources;
            foreach (Resources r in resourses)
            {
                if (r.reserve_date.GetValueOrDefault() != null)
                {
                    ValidateResource(r);
                }
            }
            db.SaveChanges();
        }
    }
}