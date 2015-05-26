using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
class TextGravity
{
    static void Main(string[] args)
    {
        int col = int.Parse(Console.ReadLine());
        string input = Console.ReadLine();
        int row =(int) Math.Ceiling((decimal)input.Length/col);
        char[,] matrix = FillMatrix(input,row,col);

        for (int i = 0; i < row; i++)
        {
            for (int r= row-1; r > 0; r--)
            {
            	for (int c = col-1; c >= 0; c--)
                {
                    if (matrix[r,c]==' ' )
                    {
                        matrix[r, c] = matrix[r - 1, c];
                        matrix[r - 1, c] = ' ';
                    }
                }
            	
            }
        }
        NewPrint(matrix);
    }

    private static void NewPrint(char[,] matrix)
    {
        StringBuilder sb = new StringBuilder();

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            if (row == 0)
            {
                sb.Append("<table>");
            }
            sb.Append("<tr>");
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                sb.Append("<td>");
                sb.Append(SecurityElement.Escape(matrix[row, col].ToString()));
                sb.Append("</td>");
            }
            sb.Append(row == matrix.GetLength(0) - 1 ? "</tr></table>" : "</tr>");
        }
        Console.WriteLine(sb.ToString());
    }


    static private char[,] FillMatrix(string input, int row, int col)
    {
        char[,] matrix = new char[row,col];
        int index=0;
        for (int r = 0; r < row; r++)
		{
			    for (int c = 0; c < col; c++)
			{
                if (index<input.Length)
                {                        
                    matrix[r,c] = input[index];
                }
                else
                {
                    matrix[r, c] = ' ';
                }
                index++;    
			}
		}
        return matrix;
    }
}
