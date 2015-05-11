using System;
using System.Collections.Generic;
using System.Linq;


namespace _03CategorizeNumbers
{
    class CategorizeNumbers
    {
        static void Main()
        {
            float[] nums = Console.ReadLine().Split().Select(float.Parse).ToArray();

            List<float> roundNum = new List<float>();
            List<float> floatNum = new List<float>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i]%1==0)
                {
                    roundNum.Add(nums[i]);
                }
                else
                {
                    floatNum.Add(nums[i]);
                }
            }

            Console.Write("[");
            foreach (var num in floatNum)
            {
                Console.Write(num + " ");
            }
            Console.Write("] -> min: {0}, max: {1}, sum: {2}, avg: {3}", floatNum.Min(),floatNum.Max(), floatNum.Sum(),floatNum.Average());
            Console.WriteLine();

            Console.Write("["); 
            foreach (var num in roundNum)
            {
                Console.Write(num+ " ");
            }
            Console.Write("] -> min: {0}, max: {1}, sum: {2}, avg: {3}", roundNum.Min(), roundNum.Max(), roundNum.Sum(), roundNum.Average());
            Console.WriteLine();
            
        }
    }
}
