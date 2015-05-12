using System;
using System.Runtime.ConstrainedExecution;
using System.Text;
class ReverseString
{
    static void Main()
    {
        string input = Console.ReadLine();
        StringBuilder reversedString = new StringBuilder();
        for (int i = input.Length - 1; i >= 0; i--)
        {
            reversedString.Append(input[i]);
        }
        Console.WriteLine(reversedString);
    }
}