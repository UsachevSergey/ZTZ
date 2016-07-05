namespace ZTZ.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LinesOrder")]
    public partial class LinesOrder
    {
        public Guid ID { get; set; }

        public Guid? Product { get; set; }

        public int? Count { get; set; }

        public Guid? Orders_ID { get; set; }
    }
}
