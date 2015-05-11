using System;
class PythagoreanNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] nums = new int[n];
        bool check = false;
        if (n < 3)
        {
            Console.WriteLine("No");
            return;
        }
        for (int i = 0; i < n; i++)
        { 
            nums[i] = int.Parse(Console.ReadLine());
        }

        for (int a = 0; a < n; a++)
        {
            for (int b = a + 1; b < n; b++)
            {
                for (int c = 0; c < n; c++)
                {
                    int pythagor = (int)(Math.Pow(nums[a], 2) + Math.Pow(nums[b], 2));
                    if (pythagor == (int)Math.Pow(nums[c], 2))
                    {
                        Console.WriteLine("{0}*{0} + {1}*{1} = {2}*{2}", nums[a], nums[b], nums[c]);
                        check = true;
                    }

                }
            }
            if (nums[a] == 0)
            {
                Console.WriteLine("0*0 + 0*0 = 0*0");
                check = true;
            }
        }
        if (!check)
        {
            Console.WriteLine("No");
        }
    }
}