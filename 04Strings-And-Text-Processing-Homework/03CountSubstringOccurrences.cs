using System;
using System.Text;
class CountSubstringOccurrences
{
    static void Main()
    {
        string input = Console.ReadLine().ToLower();
        string forSearch = Console.ReadLine();
        int poss = input.IndexOf(forSearch);
        int counter = 0;
        while (poss >= 0 && poss <= input.Length)
        {
            counter++;
            poss = input.IndexOf(forSearch, poss + 1);

        }
        Console.WriteLine(counter);
    }
}