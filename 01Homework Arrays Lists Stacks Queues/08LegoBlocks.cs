using System;
using System.Collections.Generic;
using System.Linq;
class LegoBlocks
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[][] first = new string[n][];
        string[][] second = new string[n][];

        char[] emptySpace = new char[] { ' ', '\t' };

        for (int i = 0; i < n; i++)//fill first array
        {
            string firstRaw = Console.ReadLine().Trim();
            first[i] = firstRaw.Split(emptySpace, StringSplitOptions.RemoveEmptyEntries).ToArray().ToArray();         
        }

        for (int i = 0; i < n; i++)// fill second array
        {
            string secondRaw = Console.ReadLine().Trim();
            second[i] = secondRaw.Split(emptySpace,StringSplitOptions.RemoveEmptyEntries).ToArray().ToArray();
            Array.Reverse(second[i]);//reversed array
        }

        bool check = true;// for check if arrays are fit

        //check for null string


        int legoRowLenght = first[0].Length + second[0].Length;
        int counterAllBlocks = legoRowLenght;//counter for blocks in all lego if arrays not are fit

        for (int i = 1; i < n; i++)//check if array fit each other
        {
            int leftSide = first[i].Length;
            int rightSide=second[i].Length;
            counterAllBlocks += leftSide+rightSide;
            if (first[i].Length + second[i].Length != legoRowLenght)
            {
                check = false;
            }
        }


        if (check) 
        {
            string[][] legoFit = new string[n][];

            for (int i = 0; i < n; i++)//combine two array in one not jagged array
            {
                legoFit[i] = first[i].Concat(second[i]).ToArray();
            }            

            for (int i = 0; i < n; i++)//print lego
            {
                Console.Write("[");
                Console.Write(string.Join(", ", legoFit[i]));
                Console.Write("]");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("The total number of cells is: " + counterAllBlocks);
        }
    }

    
}