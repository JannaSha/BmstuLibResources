namespace BmstuLibResources
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Udc")]
    public partial class Udc
    {
        public Udc()
        {
            Resources = new HashSet<Resources>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string udc_index { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string description { get; set; }

        public virtual ICollection<Resources> Resources { get; set; }
    }
}
