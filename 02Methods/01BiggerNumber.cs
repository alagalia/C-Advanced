using System;
class GenericArraySort
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        GetMax(a, b);
    }

    static void GetMax(int a, int b)
    {
        Console.WriteLine(a > b ? a : b);
    }
}