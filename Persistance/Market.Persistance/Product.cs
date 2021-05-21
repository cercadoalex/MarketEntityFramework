using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Market.Persistance
{
    public partial class Product
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }

        public  Category Category { get; set; }
        public  List<OrderDetail> OrderDetails { get; set; }
    }
}
