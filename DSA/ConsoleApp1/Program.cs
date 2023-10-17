/*// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, World!");
Stopwatch stopwatch = Stopwatch.StartNew();
for(int i = 0; i < 99999; i++)
{
    var a = File.AppendText("B:\\Grid.Test.txt");
    a.WriteLine($"Line: {i}");
    
    a.Close();
    

}
stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);

stopwatch.Reset();
stopwatch.Start();
FileInfo s = new FileInfo("B:\\Grid.Test1.txt");
for (int i = 0; i < 99999; i++)
{
    var t = s.AppendText();
    t.WriteLine($"Line {i}"); 
    t.Close();
}
stopwatch.Stop();
Console.WriteLine($"FileInfo {stopwatch.ElapsedMilliseconds}");

*/
using System.Data;
using System.Text;

string firstString = "SomethingTime";
string secondString = "TimeSomething";

IsPangram(secondString, firstString);
static bool IsPangram(string string1, string string2)
{
    if (string1.Length != string2.Length)
        return false;
    
   

    //variable with the total letters 
    StringBuilder stringBuilder1 = new StringBuilder();
    Dictionary<int, char> map = new Dictionary<int, char>();
    for(int x = 0; x<string1.Length;x++)
        map.Add(x, string1[x]);

    Console.WriteLine(stringBuilder1.ToString());
    Console.WriteLine(map.Count);
    
   
    



       
            



    return string1.CompareTo(string2) > 0;
}

