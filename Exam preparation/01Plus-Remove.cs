using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        string line = Console.ReadLine();
        List<string> matrixOriginal = new List<string>();
        int maxLineLenght = 0;
        //fill array
        while (line != "END")
        {
            matrixOriginal.Add(line);
            if (line.Length > maxLineLenght)
            {
                maxLineLenght = line.Length;
            }
            line = Console.ReadLine();
        }

        List<char[]> matrixForRemove = new List<char[]>();
        List<char[]> matrixForCheck = new List<char[]>();

        //fill two matrix with equal lenght=maxLineLenght -> one for check and onother for remove
        for (int i = 0; i < matrixOriginal.Count; i++)
        {
            char[] temp = (matrixOriginal[i] + new string(' ', maxLineLenght - matrixOriginal[i].Length)).ToArray();
            char[] temp1 = (matrixOriginal[i].ToLower() + new string(' ', maxLineLenght - matrixOriginal[i].Length)).ToArray();

            matrixForRemove.Add(temp);
            matrixForCheck.Add(temp1);
        }

        //remove "+"es
        for (int row = 1; row < matrixForRemove.Count - 1; row++)
        {
            for (int col = 1; col < maxLineLenght - 1; col++)
            {

                if (matrixForCheck[row][col] == matrixForCheck[row - 1][col] &&
                    matrixForCheck[row][col] == matrixForCheck[row + 1][col] &&
                    matrixForCheck[row][col] == matrixForCheck[row][col + 1] &&
                    matrixForCheck[row][col] == matrixForCheck[row][col + 1])
                {
                    matrixForRemove[row][col] = '\0';
                    matrixForRemove[row - 1][col] = '\0';
                    matrixForRemove[row + 1][col] = '\0';
                    matrixForRemove[row][col + 1] = '\0';
                    matrixForRemove[row][col -1] = '\0';
                }
            }
        }
        foreach (var item in matrixForRemove)
        {
            foreach (var item1 in item)
            {
                if (item1 != '\0')
                {
                    Console.Write(item1);
                }
            } Console.WriteLine();
        }
    }
}
