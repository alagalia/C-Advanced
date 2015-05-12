using System;
using System.Text;
class StringLength
{
    static void Main()
    {
        string input = Console.ReadLine();
        string output = string.Empty;
        if (input.Length > 20)
        {
            output = input.Substring(0, 20);
        }
        else
        {
            StringBuilder outputSB = new StringBuilder();
            outputSB.Append(input);
            outputSB.Append('*', 20 - input.Length);
            output = outputSB.ToString();
        }
        Console.WriteLine(output);
    }
}