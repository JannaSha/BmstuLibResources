using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BmstuLibResources.Core.UrlClickStats
{
    /**
     * Интрфейс для регистрации перехода по ссылке в базе данных.
     */
    interface IUrlClickDataHandler
    {
        /** Регистрирует переход по ссылке в указанное время в базе данных. */
        void RegisterUrlClick(int resourceId, DateTime registredDateTime);
    }
}
