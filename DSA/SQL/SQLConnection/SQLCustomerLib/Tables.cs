using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SQLCustomerLib
{
    public class Tables
    {

        public void CreateSchema()
        {
            
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Enter New Schema to Create: ");
                string schema = Console.ReadLine();
                string sqlSchema = $@"CREATE SCHEMA [{schema}];";
                connection.Execute(sqlSchema);
                connection.Close();
            }
        }

        public void CreateTables()
        {
            
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Enter the schema where table is created: ");
                string schema = Console.ReadLine();
                Console.WriteLine("Enter the table name: ");
                string tableName = Console.ReadLine();
                string sqlTable = $@"
                                Drop Table if exists {schema}.{tableName};
      
                                CREATE TABLE {schema}.{tableName}(
                                [CustomerID]   INT           IDENTITY (1, 1) NOT NULL,
                                [CustomerName] NVARCHAR (50) NOT NULL,
                                [DateOfBirth]  DATETIME2 (7) NOT NULL,
                                [Age]     AS            (datediff(year, [DateOfBirth], getdate())),
                                CONSTRAINT [PK_{tableName}] PRIMARY KEY CLUSTERED ([CustomerID] ASC)
                                );
                                ";
                connection.Execute(sqlTable);
                connection.Close();
                Console.WriteLine($"Table: {tableName} created on {DateTime.Now}");
            }
            
        }

        public void Create100Customers()
        { 
             
             using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = @"
                        insert into AG.NewCustomers(CustomerName, DateOfBirth) 
                        Values (@CustomerName, @DateOfBirth);
                        ";
                
                for (int x = 0; x < 100; x++)
                {
                    var parameters = new { CustomerName = $"Juanito Guero{x}", DateOfBirth = new DateTime(1990, 11, 11).AddDays(Random.Shared.Next(-1, 1000)) };
                    connection.Execute(sql, parameters);
                }
                
                Console.WriteLine($"Customers Added");
                connection.Close();
            }
        }

        public void DisplayCustomers()
        {
            Console.WriteLine("Enter Table Name: ");
            string table = Console.ReadLine();
            
            string sql = $"INSERT INTO {table} ([CUSTOMERID], [NAME], [BIRTH_DATE], [AGE] ) Values (@CustomerID, @Name, @Birth_Date, @Age);";
            using (var connection = new SqlConnection(connectionString))
            {
                var affectedRows = connection.Execute(sql, new { UserName = "Mark" });

                Console.WriteLine(affectedRows);
            }

        }

        public void DeleteCustomerID()
        {

        }

        public void DisplayCountCustomerTable(string tableName)
        {

        }
    }


    
}