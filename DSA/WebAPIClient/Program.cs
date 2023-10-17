// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;
using System.Text.Json;
using WebAPIClient;

/*using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

var repositories = await ProcessRepositoriesAsync(client);

foreach(var repo in repositories)
{
    Console.WriteLine($"Name: {repo.Name}");
    Console.WriteLine($"Homepage: {repo.Homepage}");
    Console.WriteLine($"GitHub: {repo.GitHubHomeUrl}");
    Console.WriteLine($"Description: {repo.Description}");
    Console.WriteLine($"Watchers: {repo.Watchers:#,0}");
    Console.WriteLine($"Last push: {repo.LastPush}");
    Console.WriteLine();
}
*/


/*HttpClient clientNinja = new HttpClient();
clientNinja.DefaultRequestHeaders.Accept.Clear();
clientNinja.DefaultRequestHeaders.Add("X-Api-Key", Environment.GetEnvironmentVariable("apikey"));
string APIendpt = $"https://api.api-ninjas.com/v1/mortgagecalculator?loan_amount=200000&interest_rate=3.5&duration_years=30";
await using Stream stream = await clientNinja.GetStreamAsync(APIendpt);


var MortgageAmount = await ProcessMortgageAsync(clientNinja);

static async Task<MortgageRepsone> ProcessMortgageAsync(HttpClient client)
{
    await using Stream stream =
    await client.GetStreamAsync("https://api.api-ninjas.com/v1/mortgagecalculator");
    var Mortgage =
        await JsonSerializer.DeserializeAsync<MortgageRepsone>(stream);

    return Mortgage ?? new();

}

*/







HttpClient CarsNinja = new HttpClient();
CarsNinja.DefaultRequestHeaders.Accept.Clear();
string model = "WRX";

CarsNinja.DefaultRequestHeaders.Add("X-Api-Key", Environment.GetEnvironmentVariable("apikey"));
string APIendpt2 = $"https://api.api-ninjas.com/v1/cars?limit=2&model={model}";
await using Stream stream2 = await CarsNinja.GetStreamAsync(APIendpt2);
var cars = await JsonSerializer.DeserializeAsync<List<Cars>>(stream2);



foreach (var item in cars)
{
    Console.WriteLine(item.model);
    Console.WriteLine(item.year);
    Console.WriteLine(item.city_mpg);
    Console.WriteLine(item.year);
    Console.WriteLine(item.drive);
}
