namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Size")]
    public partial class Size
    {
        public int Id { get; set; }

        [Column("_size")]
        [StringLength(50)]
        public string C_size { get; set; }
    }
}
