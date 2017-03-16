namespace BmstuLibResources
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Validations
    {
        public int id { get; set; }

        public int resource_id { get; set; }

        public DateTime check_datetime { get; set; }

        public bool is_valid { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        public virtual Resources Resources { get; set; }
    }
}
