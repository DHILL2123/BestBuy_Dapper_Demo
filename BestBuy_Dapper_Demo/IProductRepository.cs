using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuy_Dapper_Demo
{
    interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();

        void CreateProduct(string name, double price, int categoryID);

       


       

    }
}