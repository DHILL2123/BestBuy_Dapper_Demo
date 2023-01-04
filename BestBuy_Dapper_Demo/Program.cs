using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using Microsoft.Extensions.Configuration;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data;



namespace BestBuy_Dapper_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);

            var repo = new DapperDepartmentRepository(conn);

            var departments = repo.GetAllDepartments();

            foreach (var dept in departments)
            {
                Console.WriteLine($"Department: {dept.DepartmentID}");
                Console.WriteLine($"Name: {dept.Name}");
            }

            //repo.InsertDepartment("Test Department");
            repo.UpdateDepartment("Appliances", 5);
            repo.DeleteDepartment("Test Department");

            var product = new DapperProductRepository(conn);

            var products = product.GetAllProducts();
            foreach (var prod in products)
            {
                Console.WriteLine($" Product: {prod.ProductID}");
                Console.WriteLine($"Name: {prod.Name}");
            }

            product.CreateProduct("Test Product", 29.99, 20);

        }

    }
}