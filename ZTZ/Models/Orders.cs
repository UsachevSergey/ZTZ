namespace ZTZ.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders
    {
        public Guid Id { get; set; }

        public DateTime? Date { get; set; }

        public int? Number { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public Guid? Account_Id { get; set; }
    }
}
