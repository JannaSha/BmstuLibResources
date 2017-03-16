namespace BmstuLibResources
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Resources
    {
        public Resources()
        {
            Stats = new HashSet<Stats>();
            Validations = new HashSet<Validations>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string resource_author { get; set; }

        [Required]
        public string url { get; set; }

        public int udc_id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string html_code { get; set; }

        [Column(TypeName = "date")]
        public DateTime create_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? reserve_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? license_date { get; set; }

        [Required]
        [StringLength(100)]
        public string resource_type { get; set; }

        [Required]
        [StringLength(50)]
        public string resource_form { get; set; }

        public Boolean is_editing { get; set; }

        public int? amount_resource { get; set; }

        public virtual Udc Udc { get; set; }

        public virtual ICollection<Stats> Stats { get; set; }

        public virtual ICollection<Validations> Validations { get; set; }
    }
}
