using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BmstuLibResources
{
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
        public string author { get; set; }

        [Required]
        public string url { get; set; }

        public int udc_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime create_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? reserve_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? license { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string html_code { get; set; }

        [Required]
        [StringLength(100)]
        public string type_res { get; set; }

        [Required]
        [StringLength(50)]
        public string form { get; set; }

        public Boolean is_editing { get; set; }

        public Boolean is_license { get; set; }

        public int? amount { get; set; }

        public virtual Udc Udc { get; set; }

        public virtual ICollection<Stats> Stats { get; set; }

        public virtual ICollection<Validations> Validations { get; set; }
    }
}