namespace BmstuLibResources
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Stats
    {
        public int id { get; set; }

        public int resource_id { get; set; }

        public DateTime start_period_datetime { get; set; }

        public DateTime finish_period_datetime { get; set; }

        public int visitors_count { get; set; }

        public virtual Resources Resources { get; set; }
    }
}
