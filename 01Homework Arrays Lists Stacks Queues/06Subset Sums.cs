using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] num = Console.ReadLine().Split().Select(int.Parse).ToArray();
        num = num.Distinct().ToArray(); // Remove duplicates from array
        double combin = Math.Pow(2, num.Length); //find how many combination are possible
        List<int> forPrint = new List<int>();
        bool matchCheck = false;

        for (int i = 1; i < combin; i++) // rotate all binnary combination
        {
            int sum = 0;
            for (int z = 0; z < num.Length; z++)
            {
                int mask = i & (1 << z);
                if (mask != 0)
                {
                    sum += num[num.Length - 1 - z];
                    forPrint.Add(num[num.Length - 1 - z]);
                }
            }

            if (sum == n)
            {
                Print(forPrint, sum);
                matchCheck = true;
            }

            forPrint.Clear();
        }

        if (!matchCheck)
        {
            Console.WriteLine("No matching subsets.");
        }

    }


    static void Print(List<int> nums, int sum)
    {
        Console.WriteLine(string.Join(" + ",nums));
        Console.WriteLine(" = " + sum);
    }
}