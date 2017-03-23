using System;
using System.Collections.Generic;
using System.Linq;

namespace BmstuLibResources.Core.Valitadion
{
    public class HtmlAgilityPackContentAnalyzer : IHtmlContentAnalyzer
    {
        /** 
         * Максимальное количество символов при получении контента. 
         * Если число меньше или равно 0, то размер получаемого контента не ограничен. 
         */
        private int maxDocLength = 2000;

        /* Минимальный допустимый коэффициент схожести. */
        private double equalRate = 0.65;

        public HtmlAgilityPackContentAnalyzer() { }

        public HtmlAgilityPackContentAnalyzer(int maxDocLength, double equalRate)
        {
            if (equalRate < 0.0 || equalRate > 1.0)
                throw new ArgumentException("The given value of the equal rate " +
                    "must be more then 0 and less then 1.");
            this.maxDocLength = maxDocLength;
            this.equalRate = equalRate;
        }

        public bool IsEqual(string[] trueContentWords, string[] otherContentWords)
        {
            HashSet<string> trueContentWordsSet = new HashSet<string>(trueContentWords);
            HashSet<string> otherContentWordsSet = new HashSet<string>(otherContentWords);

            int trueLength = trueContentWordsSet.Count;
            trueContentWordsSet.ExceptWith(otherContentWordsSet);
            double error = trueContentWordsSet.Count / (double)trueLength;

            return 1.0 - error > equalRate;
        }

        public bool IsEqual(string trueContent, string htmlPage)
        {
            string[] htmlWords = GetWordsArrayFromHtml(htmlPage);
            string[] trueWords = GetWordsArrayFromText(trueContent);
            return IsEqual(trueWords, htmlWords);
        }


        private string[] GetWordsArrayFromText(string text)
        {
            string[] substrings = text.Split(' ');

            int currentLength = 0;
            LinkedList<string> words = new LinkedList<string>();
            foreach (string s in substrings)
            {
                if (maxDocLength >= 0)
                {
                    currentLength += s.Length;
                    if (s.Length + currentLength > maxDocLength) break;
                }

                if (!String.IsNullOrWhiteSpace(s))
                {
                    words.AddLast(s.Trim());
                }
            }
            return words.ToArray();
        }

        public string[] GetWordsArrayFromHtml(string html)
        {
            string content = GetContentFromHtml(html);
            content = StripTagsFromString(content);
            return GetWordsArrayFromText(content);
        }

        public string GetContentTextFromHtml(string html)
        {
            string content = GetContentFromHtml(html);
            content = StripTagsFromString(content);
            string[] substrings = content.Split(' ');
            LinkedList<string> words = new LinkedList<string>();

            string res = "";
            int currentLength = 0;
            foreach (string s in substrings)
            {
                if (maxDocLength >= 0)
                {
                    currentLength += s.Length;
                    if (s.Length + currentLength > maxDocLength) break;
                }

                if (!String.IsNullOrWhiteSpace(s))
                {
                    res += s.Trim() + " ";
                }
            }

            return res;
        }

        private string StripTagsFromString(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }


        private string GetContentFromHtml(string html)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            doc.DocumentNode.Descendants()
                .Where(n => n.Name == "script" || n.Name == "style")
                .ToList()
                .ForEach(n => n.Remove());

            string docFileString = doc.DocumentNode.InnerText;

            return docFileString;
        }
    }
}