using System;
using System.Linq;
class FirstLargerThanNeighbours
{
    private static bool IsLargerThanNeighbours(int[] nums, int i)
    {
        bool isLarger = false;
        if (i != 0 && i != nums.Length - 1 && nums[i - 1] < nums[i] && nums[i + 1] < nums[i])
        {
            isLarger = true;
        }
        else if ((i == 0 && nums[i] > nums[i + 1]) || (i == nums.Length - 1 && nums[i] > nums[i - 1]))
        {
            isLarger = true;
        }
        return isLarger;
    }

    static void Main()
    {
        int[] inputNums = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        for (int i = 0; i < inputNums.Length; i++)
        {
            if (IsLargerThanNeighbours(inputNums, i))
            {
                Console.WriteLine(i);
                return;
            }
        }
        Console.WriteLine("-1");

    }
}