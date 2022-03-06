namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Images { get; set; }

        public decimal? Price { get; set; }

        [StringLength(50)]
        public string Size { get; set; }

        [StringLength(50)]
        public string Colour { get; set; }

        [StringLength(225)]
        public string OrderID { get; set; }

        [StringLength(50)]
        public string ID { get; set; }

        public virtual Order Order { get; set; }
    }
}
