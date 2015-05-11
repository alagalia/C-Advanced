using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        List <string> input = new List<string> (Console.ReadLine().Split());
        for (int i = 0; i < input.Count; i++)
        {
            if (i<input.Count-1)
            {
                for (int j = i+1; j < input.Count; j++)
                {
                    if (input[i]== input[j])
                    {
                        Console.Write(input[j]+ " ");
                        input.RemoveAt(j); 
                        j--;
                    }
                }
            }
            Console.Write(input[i]); 
            Console.WriteLine();
        }
    }
}