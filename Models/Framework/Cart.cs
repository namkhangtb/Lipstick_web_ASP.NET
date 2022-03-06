namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cart")]
    public partial class Cart
    {
        public int? Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Alias { get; set; }

        public int? CategoryId { get; set; }

        [StringLength(50)]
        public string Images { get; set; }

        public DateTime? Createdate { get; set; }

        public decimal? Price { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public bool? Status { get; set; }

        [StringLength(10)]
        public string Size { get; set; }

        [StringLength(50)]
        public string Colour { get; set; }

        public int? CartID { get; set; }

        [Key]
        public int Prime { get; set; }

        public int? Quanity { get; set; }

        public decimal? QuanityPice { get; set; }
    }
}
