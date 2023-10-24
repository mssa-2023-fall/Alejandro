using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections;
using System.ComponentModel.Design;
using System.Drawing;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

string string1 = "pales";
string string2 = "pale";

Console.WriteLine(IsOneEditOrZero(string1, string2));



static bool IsPermutation(string s1, string s2)
{
    if (s1.Length != s2.Length) { return false; };
    //arrange data structure lines 19 - 27
    List<char> stringList1 = new List<char>();
    List<char> stringList2 = new List<char>();
    int n = s1.Length;
    for (int y = 0; y < s2.Length; y++)
    { stringList2.Add(s2[y]); }

    for (int y = 0; y < s1.Length; y++)
    { stringList1.Add(s1[y]); }
    //sort the data
    stringList1.Sort();
    stringList2.Sort();

    for (int x = 0; x < stringList1.Count; x++)
    {
        if (stringList1[x].Equals(stringList2[x]))
            n--;
        else { return false; }
    }
    return n == 0;
    
}

//bake & pale or ple & pale
static bool IsOneEditOrZero(string s1, string s2)
{
    if (s1 == s2) return true; //zero edits
    //arranging word into position
    string longWord = "";
    string shortWord = "";
    if (s1.Length >= s2.Length)
    {
        longWord = s1;
        shortWord = s2;
    
    } else
    {
        longWord = s2;
        shortWord = s1; 
    }
    int shortLen = shortWord.Length;
    int longLen = longWord.Length;
    int counterIndex = 0;

    //if they different with two characters then return false
    if (longWord.Length == shortWord.Length - 2 || longWord.Length == shortWord.Length + 2)
    { return false; }
       //pales & pale // pale ple // apple aple
        
    for (int y = 0; y <= shortWord.Length; y++)
    {   
        

        //last letter different but everything else is the same return true
        if (y == longWord.Length-1 && y == shortWord.Length && counterIndex == shortWord.Length)
        {
            return true;
        }

        //if not equal we can insert by new var concat
        if (!longWord[y].Equals(shortWord[y])) 
        {
            string addChar = shortWord[..(y)] + longWord[y] + shortWord[y..];
            if (addChar.Equals(longWord))
            { return true; } else { return false; }
        }
        //if the char is equal add to the counter for use in line the next if statement
        if (longWord[y].Equals(shortWord[y]))
        { counterIndex++; }
    }
    return false;

}
string word1 = "bake";
string word2 = "bake";

Console.WriteLine(IsOneEditOrZero(word2, word1));