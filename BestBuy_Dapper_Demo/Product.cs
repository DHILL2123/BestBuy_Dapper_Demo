using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuy_Dapper_Demo
{
    public class Product
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int ProductID { get; set; }
        public int OnSale { get; set; }
        public int StockLevel { get; set; }
    }

    
}