using System;
using System.Linq;
class NumberCalculations
{
    static void Main()
    {
        double[] input = Console.ReadLine().Split().Select(double.Parse).ToArray();
        Min(input);
        Max(input);
        Average(input);
        Sum(input);
        Product(input);
    }

    private static void Product(double[] input)
    {
        double product = 1;
        foreach (var num in input)
        {
            product *= num;
        }
        Console.WriteLine(product);
    }
    private static void Product(int[] input)
    {
        int product = 1;
        foreach (var num in input)
        {
            product *= num;
        }
        Console.WriteLine(product);
    }
    private static void Sum(double[] input)
    {
        double sum = 0;
        foreach (var num in input)
        {
            sum += num;
        }
        Console.WriteLine(sum);
    }
    private static void Sum(int[] input)
    {
        int sum = 0;
        foreach (var num in input)
        {
            sum += num;
        }
        Console.WriteLine(sum);
    }

    private static void Average(double[] input)
    {
        double avg = 0;
        foreach (var num in input)
        {
            avg += num;
        }
        avg /= input.Length;
        Console.WriteLine(avg);
    }
    private static void Average(int[] input)
    {
        int avg = 0;
        foreach (var num in input)
        {
            avg += num;
        }
        avg /= input.Length;
        Console.WriteLine(avg);
    }

    private static void Max(double[] input)
    {
        double max = double.MinValue;
        foreach (var num in input)
        {
            if (num > max)
            {
                max = num;
            }
        }
        Console.WriteLine(max);
    }
    private static void Max(int[] input)
    {
        int max = int.MinValue;
        foreach (var num in input)
        {
            if (num > max)
            {
                max = num;
            }
        }
        Console.WriteLine(max);
    }
    private static void Min(double[] input)
    {
        double min = double.MaxValue;
        foreach (var num in input)
        {
            if (num < min)
            {
                min = num;
            }
        }
        Console.WriteLine(min);
    }
    private static void Min(int[] input)
    {
        int min = int.MaxValue;
        foreach (var num in input)
        {
            if (num < min)
            {
                min = num;
            }
        }
        Console.WriteLine(min);
    }
}