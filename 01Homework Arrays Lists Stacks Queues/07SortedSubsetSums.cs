using System;
using System.Collections.Generic;
using System.Linq;

namespace _07SortedSubsetSums
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] num = Console.ReadLine().Split().Select(int.Parse).ToArray();
            num = num.Distinct().ToArray(); // Remove duplicates from array
            double combin = Math.Pow(2, num.Length); //find how many combination are possible
            bool matchCheck = false; //check if there is sum==n

            List<int> forAdd = new List<int>();//collector for nummbers that sum==n
            List<List<int>> allSums = new List<List<int>>();//collect all  sum == n


            for (int i = 1; i < combin; i++) // rotate all binnary combination
            {
                int sum = 0;
                for (int z = 0; z < num.Length; z++)
                {
                    int mask = i & (1 << z);
                    if (mask != 0)
                    {
                        sum += num[num.Length - 1 - z];
                        forAdd.Add(num[num.Length - 1 - z]);
                    }
                }

                if (sum == n)
                {
                    allSums.Add(forAdd);
                    matchCheck = true;
                }
                forAdd = new List<int>();//clear list
            }
            if (!matchCheck)
            {
                Console.WriteLine("No matching subsets.");
            }
            else
            {   //sort all lists by lenght 
                List<List<int>> allsums = new List<List<int>> ( allSums.OrderBy(x => x.Count));

                //sort each list from small to big number
                foreach (var item in allsums) 
                {
                    item.Sort();
                }

                //sort allnums<> by size of the first number in all lists (from small to bigger)
                for (int i = 0; i < allsums.Count - 1; i++)
                {
                    int first = allsums[i].First();
                    for (int j = i + 1; j < allsums.Count; j++)
                    {
                        int second = allsums[j].First();
                        if (allsums[i].Count == allsums[j].Count && first > second)
                        {
                            List<int> temp = allsums[i];
                            allsums[i] = allsums[j];
                            allsums[j] = temp;
                        }
                    }
                }
                foreach (var item in allsums)
                {
                    Print(item,n);
                }
                
            }


        }
                

        static void Print(List<int> nums, int sum)
        {

            foreach (var item in nums)
            {
                Console.Write(item + " + ");
            }
            Console.WriteLine("\b\b\b = " + sum);
        }
    }
}
