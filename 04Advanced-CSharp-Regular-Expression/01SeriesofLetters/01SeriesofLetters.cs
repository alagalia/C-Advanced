using System;
using System.Text.RegularExpressions;
using System.Text;
class SeriesofLetters
{
    static void Main()
    {
        string input = Console.ReadLine();
        string patern = @"(\w)\1*";
        Regex reg = new Regex(patern);
        MatchCollection matches = reg.Matches(input);
        StringBuilder result = new StringBuilder();
        foreach (var mach in matches)
        {
            result.Append (mach.ToString()[0]);
        }
        Console.WriteLine(result);
    }
}