using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Your task is to remove all X shapes in the text. An X Shape is 3 by 3 symbols crossing each other on 3 lines. A single X shape can be part of multiple X shapes. If new X Shapes are formed after the first removal you don't have to remove them.*/
namespace X_Removal
{
    class Program
    {
        static void Main()
        {
            string line = Console.ReadLine();
            List<string> matrixOriginal = new List<string>();
            int maxLineLenght = 0;
            while (line!="END")
            {
                matrixOriginal.Add(line);
                if (line.Length>maxLineLenght)
                {
                    maxLineLenght = line.Length;
                }
                line = Console.ReadLine();
            }

            List<char[]> matrixForRemove = new List<char[]>();
            List<char[]> matrixForCheck = new List<char[]>();
            for (int i = 0; i < matrixOriginal.Count; i++)
            {
                char[] temp = (matrixOriginal[i] + new string(' ', maxLineLenght- matrixOriginal[i].Length)).ToArray();
                char[] temp1 = (matrixOriginal[i].ToLower() + new string(' ', maxLineLenght - matrixOriginal[i].Length)).ToArray();

                matrixForRemove.Add(temp);
                matrixForCheck.Add(temp1);
            }


            for (int row = 1; row <matrixForRemove.Count-1; row++)
            {
                for (int col = 1; col < maxLineLenght - 1; col++)
                {

                    if (matrixForCheck[row][col] == matrixForCheck[row-1][col-1] &&
                        matrixForCheck[row][col] == matrixForCheck[row+1][col-1] &&
                        matrixForCheck[row][col] == matrixForCheck[row+1][col+1] &&
                        matrixForCheck[row][col] == matrixForCheck[row-1][col+1])
                    {
                        matrixForRemove[row][col] = ' '; 
                        matrixForRemove[row - 1][col - 1] = ' ';
                        matrixForRemove[row + 1][col - 1] = ' ';
                        matrixForRemove[row + 1][col + 1] = ' ';
                        matrixForRemove[row - 1][col + 1] = ' ';
                    }
                }
            }
            foreach (var item in matrixForRemove)
            {
                foreach (var item1 in item)
                {
                    if (item1!=' ')
                    {
                        Console.Write(item1);
                    }
                } Console.WriteLine();
            }       
        }
    }
}
