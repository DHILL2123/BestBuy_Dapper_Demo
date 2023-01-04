using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dapper;
using MySql.Data;


namespace BestBuy_Dapper_Demo
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;
        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Department> GetAllDepartments()
        {
            return _connection.Query<Department>("Select * From departments;");
        }


        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
                new { departmentName = newDepartmentName });
        }

        public void UpdateDepartment(string name, int id)
        {
            _connection.Execute("UPDATE departments SET Name = @name WHERE DepartmentID = @id;",
                new { name = name, id = id });
        }

        public void DeleteDepartment(string name)
        {
            _connection.Execute("DELETE FROM departments WHERE Name = 'Test Department'");
        }
      
    }
}