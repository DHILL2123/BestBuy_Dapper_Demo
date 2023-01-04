using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BestBuy_Dapper_Demo
{
    class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("Select * From products;");
        }

        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO PRODUCTS (Name, Price, CategoryID) VALUES (@productName, @productPrice, @productCategoryID);",
                new { productName = name, productPrice = price, productCategoryID = categoryID, });
            Console.WriteLine($"{name}, {price}, {categoryID}");
        }
        

    }
}