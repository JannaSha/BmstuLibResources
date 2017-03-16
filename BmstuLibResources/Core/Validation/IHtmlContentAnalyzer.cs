using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BmstuLibResources.Core.Valitadion
{
    /**
     * Интрфейс для получения контента HTML страницы и для сравнения
     * контента на схожесть.
     */
    interface IHtmlContentAnalyzer
    {
        /** Сравненивает на схожесть оригинального массива слов и нового. */
        bool IsEqual(string[] trueContentWords, string[] otherContentWords);

        /** Сравненивает на схожесть оригинального контента с новым контентом, 
         * заданным в HTML. 
         */
        bool IsEqual(string trueContent, string htmlPage);

        /** Возвращает массив слов из контента HTML страницы. */
        string[] GetWordsArrayFromHtml(string html);

        /** Возвращает контент HTML страницы. */
        string GetContentTextFromHtml(string html);
    }
}
