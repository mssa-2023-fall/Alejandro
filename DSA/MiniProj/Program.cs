// See https://aka.ms/new-console-template for more information
using BinaryTreeLib;
using MiniProject;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;

Console.WriteLine("Hello, World!");


static int[] DivideArray(int[] input, int left, int right)
{
    int mid = left + (right - left) / 2;
    if(left == right) { return new int[] { input[left] }; }
    return MergeTwoArraysAndSort( DivideArray(input, left, right), DivideArray(input, mid+1, right));

}

//binary search

int[] list3 = { 1,2,3,4,5,6,7,8,9,10,11,12,13 };

int startindex = 0;
int endindex = list3.Length - 1;
int midindex = (startindex+endindex) / (2);

TreeNode A = new TreeNode(list3[midindex]);

int midleft = (startindex + (midindex-1)) / 2;
int midright = (midindex + 1 + endindex) / 2;

     



	
	    
    
                   int[] array = { 3, 6, 8, 23, 48, 76, 89 };
                   TreeNode treeRoot = createBST(array);
                   
               	    
	     










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


