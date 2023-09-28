// See https://aka.ms/new-console-template for more information
using System.Linq;

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