using System;
using System.Linq;
class LargerThanNeighbours
{
    static void Main()
    {
        int[] nums = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        for (int i = 0; i < nums.Length; i++)
        {
            Console.WriteLine(IsLargerThanNeighbours(nums, i));
        }
    }

    private static bool IsLargerThanNeighbours(int[] nums, int i)
    {
        bool isLarger = false;
        if (i != 0 && i != nums.Length - 1 && nums[i - 1] < nums[i] && nums[i + 1] < nums[i])
        {
            isLarger = true;
        }
        else if ((i==0 && nums[i]>nums[i+1]) || (i==nums.Length-1 && nums[i]>nums[i-1]))
        {
            isLarger = true;
        }
        return isLarger;
    }
}