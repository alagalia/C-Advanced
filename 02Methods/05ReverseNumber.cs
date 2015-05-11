using System;
using System.Linq;
class ReverseNumber
{
    static void Main()
    {
        double num = double.Parse(Console.ReadLine());
        ReversedNum(Math.Abs(num));
    }

    private static void ReversedNum(double num)
    {
        string numStr = new string(num.ToString().Reverse().ToArray());
        double reversedNum = double.Parse(numStr);
        Console.WriteLine(reversedNum);
    }
}