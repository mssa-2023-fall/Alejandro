// See https://aka.ms/new-console-template for more information

using MiniProject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security.AccessControl;


int[] list3 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
BinaryTree tree = new BinaryTree();
tree.createBST(list3);


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

int[] list5 = { 2, 4, 6, 8, 1, 2, 5, 4, 3 };
static int[] DropWhileShort(int[] input)
{
    int x = 0;
    if (input.Length == 0) { return new int[0]; }
    
    if (input[x % 2] == 1)
    { Console.WriteLine(input[x..]);
     return input[x..]; }
    else { return new int[0]; }

}

//DropWhileShort(list5);

string input = @"1, 1928, 44, ""Emil Jannings"", ""The Last Command, The Way of All Flesh""";
int index = input.IndexOf(',', 12);
string[] separator = { ", "  };
//Console.WriteLine(index);
/*public static int[] DropWhileShort(int[] input)
{
    var emptyArray = new int[] { };
    int x = 0;
    if (input.Length == 0) { return new int[0]; }
    if (input[x % 2] == 1)



            }
            else { return new int[0]; }
             
        }*/

 static int CountDeafRats(string town)
{
    town.Replace(" ", "");
    town.Split('P');
    int count = 0;
    int index = town.IndexOf('P');
    if(town.IndexOf('~')%2==1 && count < index )
    {   
        count++; }


    return indextail;
}

Console.WriteLine(CountDeafRats("~O~O~OO~O~O~P~OO~~O~O~O~OO~"));

static bool IsPangram(string sentence)
 {
    var distinctLetters = sentence.ToLower().Where(char.IsLetter).Distinct();
    int distinctLetterCount = distinctLetters.Count();

    if (distinctLetterCount == 26)  
        return true; 
    return false;
    
}

Console.WriteLine(IsPangram("The quick brown fox jumps over the lazy dog."));

