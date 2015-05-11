using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Write a program to sort an array of numbers and then print them back on the console. 
 The numbers should be entered from the console on a single line, separated by a space. */

namespace _01SortArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < nums.Length-1; i++)
            {
                //int minPos = i ;
                for (int j = i+1; j < nums.Length; j++)
                {
                    if (nums[i]>nums[j])
                    {
                        int temp = nums[j];
                        nums[j] = nums[i];
                        nums[i] = temp;
                    }
                }
                
            }
            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
