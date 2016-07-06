using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZTZ.Models
{
    public class AddItemModel
    {
        public int Numb { get; set; }
        public Guid Id_prod { get; set; }
        public int Count_item { get; set; }
    }
}