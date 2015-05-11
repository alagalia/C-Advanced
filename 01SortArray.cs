using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
