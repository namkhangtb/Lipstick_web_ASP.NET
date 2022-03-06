namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Colour")]
    public partial class Colour
    {
        public int Id { get; set; }

        [Column("colour")]
        [StringLength(50)]
        public string colour1 { get; set; }
    }
}
