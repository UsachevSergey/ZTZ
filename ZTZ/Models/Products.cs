namespace ZTZ.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Products
    {
        public Guid ID { get; set; }

        public Guid? Account_ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
    }
}
