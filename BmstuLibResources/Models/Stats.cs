namespace BmstuLibResources
{
    using System;

    public partial class Stats
    {
        public int id { get; set; }

        public int id_resource { get; set; }

        public DateTime start_period { get; set; }

        public DateTime finish_period { get; set; }

        public int visitors_count { get; set; }

        public virtual Resources Resources { get; set; }
    }
}
