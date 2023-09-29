// See https://aka.ms/new-console-template for more information
using MortgageLib;
using System.Text.Json;
Console.WriteLine("Hello, World!");

//Collect the Principle
Console.WriteLine("Enter the principal amount: ");
double principal = double.Parse(Console.ReadLine());
//Collect the interest rate
Console.WriteLine("Enter the interest rate: ");
double interestRate = double.Parse(Console.ReadLine());

//Collect the duration of the loan
Console.WriteLine("Enter the years of the loan: ");
int years = int.Parse(Console.ReadLine());

//Collect the downpayment 
Console.WriteLine("Enter the down payment: ");
double downPayment = double.Parse(Console.ReadLine());

//Collect the start Date of the Loan
Console.WriteLine("Enter the start date of the loan: ");
DateTime dateTime = DateTime.Parse(Console.ReadLine());

Mortgage newMortgage = new Mortgage(principal, interestRate, years, dateTime, downPayment);

Console.WriteLine($"The monthly mortgage payment is ${newMortgage.MonthlyPayment:F2}.");
Console.WriteLine($"The principle amount is ${newMortgage.Principal}.");
Console.WriteLine($"The interest rate is {newMortgage.InterestRate*12*100}%.");
Console.WriteLine($"The down payment on the mortgage is ${newMortgage.DownPayment}.");
Console.WriteLine($"The start date of the loan is {newMortgage.StartDate}.");
Console.WriteLine($"The end date of the loan is {newMortgage.StartDate.AddYears(years)}");




PrintMenuOptions(newMortgage);
static void PrintMenuOptions(Mortgage newMortgage)
{
    string key = Console.ReadLine();
    do
    {
        Console.WriteLine($"To make a payment press 8: e.g 2023, 10, 1");
        Console.WriteLine($"To make a JSON file from the mortgage press J: ");
        Console.WriteLine($"To review the interest paid at a give a target date press I: ");
        Console.WriteLine($"To quit press Q: ");
        key = Console.ReadLine();
        if (key == "8")
        {
            
            
            
            newMortgage.MakeMonthlyPayment();
        }

        if (key == "J")
        {
            string json = JsonSerializer.Serialize(newMortgage, new JsonSerializerOptions
            { WriteIndented = true });

            File.WriteAllText("mortgage_result.json", json);
            Console.WriteLine(json);
        }
        if (key == "I")
        {
            Console.WriteLine("Enter target date: ");
            DateTime dateTime = DateTime.Parse(Console.ReadLine());
            newMortgage.GetInterestPaidToDate(dateTime);
        }
    } while (key.ToUpper() != "Q");
}



