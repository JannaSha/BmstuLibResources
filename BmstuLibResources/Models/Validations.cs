namespace BmstuLibResources
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Validations
    {
        public int id { get; set; }

        public int id_resource { get; set; }

        public DateTime check_date { get; set; }

        public bool is_valid { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        public virtual Resources Resources { get; set; }
    }
}
