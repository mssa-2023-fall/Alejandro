// See https://aka.ms/new-console-template for more information
using MiniProject;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World!");


static int[] DivideArray(int[] input, int left, int right)
{
    int mid = left + (right - left) / 2;
    if(left == right) { return new int[] { input[left] }; }
    return MergeTwoArraysAndSort( DivideArray(input, left, right), DivideArray(input, mid+1, right));

}






int[] list1 = { 1, 2, 3, 4 };
int[] list2 = { 3, 4, 5, 6, 7 };


static int[] MergeTwoArraysAndSort(int[] array1, int[] array2)
{
    int[] list1 = { 1, 2, 3, 4 };
    int[] list2 = { 3, 4, 5, 6, 7 };
    int[] merge = new int[list1.Length + list2.Length];
    List<int> result = new List<int>(list1.Length + list2.Length);
    
    for(int x = 0; x < list1.Length; x++)
    {
        result.Add(list1[x]);
        merge[x] = (list1[x]);
        Console.Write(merge[x]);
    }
    
    for (int y = 0; y < list2.Length; y++)

    {
        result.Add(list2[y]);
        merge[y+list1.Length] = (list2[y]);
        Console.Write(merge[y]);
    }
    result.Sort();
    Array.Sort(merge);
    
    Console.WriteLine("HERE");
    for (int z = 0; z < merge.Length; z++)
        { Console.WriteLine($"{merge[z]} {z}"); }
    Console.WriteLine(" WE GO");
    Console.WriteLine(merge.Length);
    return merge;
}

Console.WriteLine(MergeTwoArraysAndSort(list1, list2));



public class ListNode
{
      public int val;
      public ListNode next;
      public ListNode(int val = 0, ListNode next = null)
    {
       this.val = val;
       this.next = next;
    }
}


