using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BmstuLibResources.Models;

namespace BmstuLibResources.Core.UrlClickStats
{
    /**
     * Регистрирует ссылки в БД, группируя их по месяцам.
     */
    public class PerMonthUrlClickHandler : IUrlClickDataHandler
    {
        public void RegisterUrlClick(int resourceId, DateTime registredDateTime)
        {
            ResourcesLibModel db = new ResourcesLibModel();

            var urlStat = db.Stats.Where(p => p.resource_id == resourceId);

            // Если еще нет статистики для ссылки
            if (!urlStat.Any())
            {
                Stats stats = CreateStatsForMonth(resourceId, registredDateTime);
                db.Stats.Add(stats);
                db.SaveChanges();
                return;
            }

            var lastUrlStat = urlStat.First();

            // Если еще нет данных по статистике для текущего месяца
            if (DateTime.Compare(lastUrlStat.finish_period_datetime, registredDateTime) < 0)
            {
                Stats stats = CreateStatsForMonth(resourceId, registredDateTime);
                db.Stats.Add(stats);
            }
            else
            {
                lastUrlStat.visitors_count += 1;
            }

            db.SaveChanges();
        }

        private Stats CreateStatsForMonth(int resourceId, DateTime registredDateTime)
        {
            Stats stats = new Stats();
            stats.resource_id = resourceId;
            int year = registredDateTime.Year;
            int month = registredDateTime.Month;
            stats.start_period_datetime = new DateTime(year, month, 1);
            stats.finish_period_datetime =
                new DateTime(year, month, DateTime.DaysInMonth(year, month));

            stats.visitors_count = 1;
            return stats;
        }

    }
}