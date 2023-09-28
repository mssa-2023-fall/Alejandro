using Dapper;
using Microsoft.Data.SqlClient;
using SQLConnection;
using System.Collections.Generic;



//List<EmployeeDTO> empList = CreateListOfEmployee(ConnectionString);
//List<EmployeeDTO> empList2 = CreateListOfEmployeeUsingDapper(ConnectionString);
//Console.WriteLine($"we have {empList2.Count} employees");
//ReadACustomer(ConnectionString);

//DapperDynamicQuerySingle(ConnectionString);

DapperDynamicQueryRows(ConnectionString);

void DapperDynamicQueryRows(string connectionString)
{
    string sql = @"SELECT sum(o.[Total Excluding Tax]) as Total,
                    d.[calendar year] as FiscalYear
                    from Fact.[Order] o join Dimension.Date d on o.[Order Date Key] = d.Date
                   group by d.[calendar year]";
    SqlConnection conn = new SqlConnection(ConnectionString);
    dynamic result = conn.Query(sql);
    Console.WriteLine($"{"Fiscal Year",20}|{"Total Excluding Tax",20}");
    foreach (var item in result)
    {
        Console.WriteLine($"{item.FiscalYear,20}|{item.Total,20:C0}");
    }


}
CreateListOfEmployeeUsingDapper(ConnectionString);
List<Employee> CreateListOfEmployeeUsingDapper(string connectionString)
{
    string sql = @"SELECT 
        [Employee Key] as a
      ,[WWI Employee ID] as b
      ,[Employee] as Employee
      ,[Preferred Name] as Preferred_Name
      ,[Is Salesperson] as Is_Salesperson
      ,[Photo] as Photo
      ,[Valid From] as Valid_From
      ,[Valid To] as Valid_To
      ,[Lineage Key] as Lineage_Key
  FROM [Dimension].[Employee]";

    List<Employee> empListTwo = new List<Employee>();

    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        empListTwo = conn.Query<Employee>(sql).ToList();
    }
    foreach(Employee emp in empListTwo)
    {
        Console.WriteLine(emp.Preferred_Name);
    }
    return empListTwo;
}
List<Employee> CreateListOfEmployee(string connectionString)
{
    List<Employee> empList = new List<Employee>();
    string sql = @"SELECT [Employee Key]
      ,[WWI Employee ID]
      ,[Employee]
      ,[Preferred Name]
      ,[Is Salesperson]
      ,[Photo]
      ,[Valid From]
      ,[Valid To]
      ,[Lineage Key]
      FROM [Dimension].[Employee]";

    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand(sql, conn);
        var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            var mem = new MemoryStream();
            reader.GetStream(5).CopyTo(mem);

            empList.Add(
                new Employee(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetString(2),
                    reader.GetString(reader.GetOrdinal("Preferred Name")),
                    reader.GetBoolean(reader.GetOrdinal("Is Salesperson")),
                    mem.ToArray(),//see code above to deal with stream(varbinary,varchar(max), json, xml)
                    reader.GetDateTime(reader.GetOrdinal("Valid From")),
                    reader.GetDateTime(reader.GetOrdinal("Valid To")),
                    reader.GetInt32(reader.GetOrdinal("Lineage Key"))
                    )
                );
        }
    }
    return empList;
}


static void ReadACustomer(string ConnectionString)
{
    Console.WriteLine("Please enter a postal code like 90005, 5 digits, followed by enter");
    string postalCode = Console.ReadLine();

    //quick check to confirm database access is possible
    using (var conn = new SqlConnection(ConnectionString))
    {
        conn.Open();
        string sql = "select [Customer Key], Customer, [Valid From] from Dimension.Customer where [postal code] = @postalcode";//@postalcode declares a parameter
                                                                                                                               //create an instance of SqlCommand Object, constructor of SqlCommand accepts sql and connection object-conn
        var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(new SqlParameter("@postalcode", postalCode));

        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            int custKey = reader.GetInt32(0);
            string custName = reader.GetString(1);
            DateTime custValidFrom = reader.GetDateTime(2);

            Console.WriteLine($"{custName} has id:{custKey}. Active since {custValidFrom}");
            //for (int i = 0; i < reader.FieldCount; i++) {
            //    Console.Write(reader.GetName(i) + ":");
            //    Console.Write(reader.GetValue(i) + "\t");
            //}

            Console.WriteLine("");
            Console.WriteLine("----------------------------------");
        }

        conn.Close();
    }
}

static void DapperDynamicQuerySingle(string ConnectionString)
{
    string sql = "select * from dimension.city where [City Key] = 1";

    dynamic aCity = (new SqlConnection(ConnectionString)).QuerySingle(sql);

    Console.WriteLine($"{aCity.City} {aCity.Country} {aCity.Continent}");
}