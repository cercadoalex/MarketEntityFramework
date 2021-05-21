using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Market.Persistance
{
    public partial class Category
    {

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public  List<Product> Products { get; set; }
    }
}
