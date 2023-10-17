// See https://aka.ms/new-console-template for more information

using MortgageLib;
using Spectre.Console;
using System.Text.Json;
Console.WriteLine("Show Me The Money!");

//Collect the Principle
AnsiConsole.MarkupLine(("Enter the principal amount: "));
double principal = double.Parse(Console.ReadLine());
//Collect the interest rate
Console.WriteLine("Enter the interest rate: ");
double interestRate = double.Parse(Console.ReadLine());

//Collect the duration of the loan
Console.WriteLine("Enter the years of the loan: ");
int years = int.Parse(Console.ReadLine());

//Collect the down payment 
Console.WriteLine("Enter the down payment: ");
double downPayment = double.Parse(Console.ReadLine());

//Collect the start Date of the Loan

DateTime dateTime = AnsiConsole.Ask<DateTime>(Console.ReadLine());
Mortgage newMortgage = new(principal, interestRate, years, dateTime, downPayment);

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

        if (key.ToUpper() == "J")
        {
            string json = JsonSerializer.Serialize(newMortgage, new JsonSerializerOptions
            { WriteIndented = true });

            File.WriteAllText("mortgage_result.json", json);
            Console.WriteLine(json);
        }
        if (key.ToUpper() == "I")
        {
            Console.WriteLine("Enter target date: ");
            DateTime dateTime = DateTime.Parse(Console.ReadLine());
            newMortgage.GetInterestPaidToDate(dateTime);
        }
    } while (key.ToUpper() != "Q");
}


var favorites = AnsiConsole.Prompt(
    new MultiSelectionPrompt<string>()
        .PageSize(10)
        .Title("What are your [green]favorite fruits[/]?")
        .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
        .InstructionsText("[grey](Press [blue][/] to toggle a fruit, [green][/] to accept)[/]")
        .AddChoiceGroup("Berries", new[]
        {
            "Blackcurrant", "Blueberry", "Cloudberry",
            "Elderberry", "Honeyberry", "Mulberry"
        })
        .AddChoices(new[]
        {
            "Apple", "Apricot", "Avocado", "Banana",
            "Cherry", "Cocunut", "Date", "Dragonfruit", "Durian",
            "Egg plant",  "Fig", "Grape", "Guava",
            "Jackfruit", "Jambul", "Kiwano", "Kiwifruit", "Lime", "Lylo",
            "Lychee", "Melon", "Nectarine", "Orange", "Olive"
        }));

var fruit = favorites.Count == 1 ? favorites[0] : null;
if (string.IsNullOrWhiteSpace(fruit))
{
    fruit = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Ok, but if you could only choose [green]one[/]?")
            .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
            .AddChoices(favorites));
}

AnsiConsole.MarkupLine("You selected: [yellow]{0}[/]", fruit);

