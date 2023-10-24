// See https://aka.ms/new-console-template for more information
using System.Linq;
using System.Text;

Console.WriteLine("Hello, World!");
    static int[][] Merge()
    {
    int[][] intervals = [[1, 4], [2, 3]];
    if (intervals.Length == 0) { return null; }
    int n = intervals.Length;
    int startMin = 0;
    int startMax = 0;
    int resultCounter = 0;
    int[][] resultPairs = new int[intervals.Length][];

    Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

    for (int x = 0; x < n; x++)
    {
        var minPair = intervals[x][0];
        var maxPair = intervals[x][1];
        if (x == 0)
        {
            startMin = intervals[x][0];
            startMax = intervals[x][1];
        }
        if (x > 0 && startMin >= minPair && startMin <= maxPair|| minPair >= startMin && minPair <= startMax)
        {
            if(startMin > minPair)
            { startMin = minPair; }
           
        }
        
        if (x > 0 && minPair >= startMin && (minPair < startMax || minPair == startMax))
        {
            if (startMax < maxPair)
            { startMax = maxPair; }
        }
        else if (x > 0 && minPair > startMin && minPair > startMax)
        {
            resultPairs[resultCounter] = new int[2];
            resultPairs[resultCounter][0] = startMin;
            resultPairs[resultCounter][1] = startMax;
            resultCounter++;

            startMin = minPair;
            startMax = maxPair;
        }

        if (n - 1 == x)
        {
            resultPairs[resultCounter] = new int[2];
            resultPairs[resultCounter][0] = startMin;
            resultPairs[resultCounter][1] = startMax;
        }

    }

    resultPairs = resultPairs.Where(arr => arr != null).ToArray();
    return resultPairs;
}

   Merge();

int[] array = { -1, -1, 0, 1, 1 };

static void plusMinus(int[] arr)
{
    double negativeValues = 0;
    double zeroValues = 0;
    double positiveValues = 0;

    for (int x = 0; x <= arr.Length-1; x++)
    {
        if (arr[x] < 0)
        { negativeValues++; }
        if (arr[x] == 0)
        { zeroValues++; }
        if (arr[x] > 0)
        { positiveValues++; }

    }

    negativeValues = negativeValues / arr.Length;
    zeroValues = zeroValues / arr.Length;
    positiveValues = positiveValues / arr.Length;

    Console.WriteLine($"Positive Ratio: {positiveValues}");
    Console.WriteLine($"Zero Ratio: {zeroValues}");
    Console.WriteLine($"Negative Ratio: {negativeValues}");

}

plusMinus(array);
Console.WriteLine(Solution(20));

static int Solution(int value)
{

    int result = 0;
    for (int x = 3; x < value; x++)
    {
        if (x % 3 == 0)
            result+=x;
        if (x % 5 == 0)
            result+=x;
        if (x % 5 == 0 && x % 3 == 0)
            result-=x;
    }


    return result;
}

 static string print(int n)
{   StringBuilder sb = new StringBuilder();
    for(int x = 1; x < n; x++)
    {
        if (n % 2 == 1)
        {
            sb.Append(" ");
        }
    }
        
            
            
            


    return "*";
}