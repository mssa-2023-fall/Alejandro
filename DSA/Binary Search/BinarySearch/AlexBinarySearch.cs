using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    public static class AlexBinarySearch
    {   //Binary Search Method. Given an array and target number. Return the target number
        //If the target number is in the array.
        public static int BinariesIndex(int[] arraySearch, int target)
        {
            //Arrange variables
            Sort(arraySearch);
            int startPoint = 0;
            int endPoint = arraySearch.Length - 1;
            int midPoint = ((endPoint - startPoint) / 2);
            int outOfLimits = -1;
            
            
            
            
            //Actions to find the target within the array

                //Target out of limits of the array will retrun negative 1
                if (arraySearch.Length == 0) { throw new ArgumentException("Array must be sorted and not empty"); }
                if(arraySearch.Length == 1 && target == arraySearch[0]) { return arraySearch[0]; }
                if (target < arraySearch[0] || target > arraySearch[^1]) { return -1; }

                //slice array in halves until target is found
                while (!(midPoint == startPoint) || midPoint == endPoint)
                {
                    if (arraySearch[midPoint] == target) { return (midPoint); }
                    if (arraySearch[startPoint] == target) { return startPoint; }
                    if (arraySearch[endPoint] == target) { return endPoint; }


                    if (midPoint > target)
                    {
                        endPoint = midPoint;
                        midPoint = (endPoint - startPoint) / 2;

                    }
                    else

                    {
                        startPoint = midPoint;
                        midPoint = (endPoint + startPoint) / 2;
                    }

                }
            
                return outOfLimits;

        }
        //Sort Array Method
        static void Sort(int[] arr)
        {
            int n = arr.Length;
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i < n; i++)
                {
                    if (arr[i - 1] > arr[i])
                    {
                        // Swap arr[i-1] and arr[i]
                        (arr[i], arr[i - 1]) = (arr[i - 1], arr[i]);
                        swapped = true;
                    }
                }
            } while (swapped);
        }
    }
}


/*using System.Drawing;
using BinarySearch;

namespace BinarySearchTest
{
    public static class AlexBinarySearch
    {

        
    }
   
}*/