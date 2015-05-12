using System;
class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        foreach (var chr in input)
        {
            Console.Write("\\U{0:x4}", (int)chr);
        }
        Console.WriteLine();
    }
}