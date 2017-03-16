using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BmstuLibResources.Core.Reports
{
    public class DocResourceDescription
    {
        private string resorseName;
        private string authorName;
        private bool valid;
        private string validDescription;
        private DateTime createDate;
        private DateTime? deleteDate;
        private int statistic;
        private int id;

        public DocResourceDescription(string recName, string authorName, bool valid,
            string vlidDes, DateTime cr, DateTime? det, int stat, int id)
        {
            this.resorseName = recName;
            this.authorName = authorName;
            this.valid = valid;
            this.validDescription = vlidDes;
            this.createDate = cr;
            this.deleteDate = det;
            this.statistic = stat;
            this.id = id;
        }

        public string GetName()
        {
            return this.resorseName;
        }
        public string GetAuthor()
        {
            return this.authorName;
        }
        public string ValidDescrioption()
        {
            return this.validDescription;
        }

        public DateTime GetCreateDate()
        {
            return this.createDate;
        }
        public DateTime? GetRemoveDate()
        {
            return this.deleteDate;
        }

        public bool GetValidStatus()
        {
            return this.valid;
        }

        public string GetStringValid()
        {
            if (this.valid)
                return "Актуален";
            else
                return "Неактуален";
        }

        public int GetStatistic()
        {
            return this.statistic;
        }

        public int GetId()
        {
            return this.id;
        }
    }
}