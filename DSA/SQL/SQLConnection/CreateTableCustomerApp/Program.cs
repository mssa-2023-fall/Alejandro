using Dapper;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office.CustomUI;
using Microsoft.Data.SqlClient;
using SQLCustomerLib;
using System.Collections.Generic;

//connection string object created.


Tables tables = new Tables();
do
{
    PrintMenu();
  string input = Console.ReadLine();
    
    switch (input)
    {
        case "1":
            tables.CreateTables();
            break;
        case "2":
            tables.Create100Customers();
            break;
        case "3":
            tables.DisplayCustomers();
            break;
        case "4":
            break;
        case "5":
            
            break;
        case "Q":
            Console.WriteLine("Good Bye!");
                break;
        default:
            
            break;
    }
    if (input.ToUpper() == "Q") break;
          
} while (true);

static void PrintMenu()
{
    Console.WriteLine("-----------MAIN MENU---------");
    Console.WriteLine("Please type and enter your option: ");
    Console.WriteLine("1 - Create Table inside a specific Schema: ");
    Console.WriteLine("2 - Generate 100 Random Customers in table previously created: ");
    Console.WriteLine("3 - Display all Customers from tables created: ");
    Console.WriteLine("4 - Delete a customer base on CustomerID: ");
    Console.WriteLine("5 - Display number of customers inside a table: ");
    Console.WriteLine("Press Q to Quit");
}