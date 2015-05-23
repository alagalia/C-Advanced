using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        List<List<char>> matrix = new List<List<char>>(); 

        FillTheMatrix(matrix);

        bool[][] availablePluses = new bool[matrix.Count][];

        FillAvailablePlusesMatrix(matrix, availablePluses);

        RepleacePlusesWithSpaces(matrix, availablePluses);

        PrintResultMatrix(matrix);
    }

    private static void PrintResultMatrix(List<List<char>> matrix)
    {
        foreach (var row in matrix)
        {
            foreach (var col in row)
            {
                if (col != ' ')
                {
                    Console.Write(col);
                }
            }
            Console.WriteLine();
        }
    }

    private static void RepleacePlusesWithSpaces(List<List<char>> matrix, bool[][] availablePluses)
    {
        for (int row = 0; row < availablePluses.Length; row++)
        {
            for (int col = 0; col < availablePluses[row].Length; col++)
            {
                if (availablePluses[row][col])
                {
                    matrix[row][col] = ' ';
                    matrix[row][col - 1] = ' ';
                    matrix[row][col + 1] = ' ';
                    matrix[row - 1][col] = ' ';
                    matrix[row + 1][col] = ' ';
                }
            }
        }
    }

    private static void FillAvailablePlusesMatrix(List<List<char>> matrix, bool[][] availablePluses)
    {
        for (int row = 0; row < matrix.Count; row++)
        {
            int lenghtRow = matrix[row].Count;
            availablePluses[row] = new bool[lenghtRow];
            for (int col = 0; col < lenghtRow; col++)
            {
                availablePluses[row][col] = IfFormedPluse(matrix, row, col);
            }
        }
    }

    private static void FillTheMatrix(List<List<char>> matrix)
    {
        while (true)
        {
            string inputLine = Console.ReadLine();
            if (inputLine == "END")
            {
                break;
            }
            List<char> line = inputLine.ToLower().ToList();
            matrix.Add(line);
        }
    }

    private static bool IfFormedPluse(List<List<char>> matrix, int row, int col)
    {
        if (row < 1 ||
            row > matrix.Count - 2 ||
            col < 1 ||
            col > matrix[row].Count - 2)
        {
            return false;
        }
        char current = matrix[row][col];

        if (current == matrix[row][col - 1] &&
            current == matrix[row][col + 1] &&
            current == matrix[row - 1][col] &&
            current == matrix[row + 1][col])
        {
            return true;
        }
        return false;
    }
}