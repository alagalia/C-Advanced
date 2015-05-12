using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Threading;
class LettersChangeNumbers
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        string[] input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        double sum = 0;
        for (int i = 0; i < input.Length; i++)
        {
            string fromInput = input[i];
            char before = fromInput[0];
            char after = fromInput[fromInput.Length - 1];
            double num = double.Parse(fromInput.Substring(1, fromInput.Length - 2));

            if (char.IsUpper(before))
            {
                int beforePossition = before - 'A' + 1;
                num /= beforePossition;
            }
            else
            {
                int beforePossition = before - 'a' + 1;
                num *= beforePossition;
            }
            if (char.IsUpper(after))
            {
                int afrerPossition = after - 'A' + 1;
                num -= afrerPossition;
            }
            else
            {
                int afrerPossition = after - 'a' + 1;
                num += afrerPossition;
            }
            sum += num;
        }
        Console.WriteLine("{0:f2}", sum);
    }
}