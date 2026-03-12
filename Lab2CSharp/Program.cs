namespace Lab2CSharp;

using System;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        Print("Виберiть завдання:");
        Print("1. Вивести номери непарних елементiв");
        Print("2. Знайти максимум з вiд’ємних елементiв");
        Print("3. Вивести елементи матрицi в стилi змiйки");
        Print("4. Пiдрахувати суму елементiв кожного рядка i знайти максимальний елемент нового масиву");

        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                PrintArray(Task1());
                break;
            case 2:
                Print(Task2().ToString());
                break;
            case 3:
                (int[] snakeElements, int n) result = Task3();
                PrintSnake(result.Item1, result.Item2);
                break;
            case 4:
                PrintTask4Results(Task4());
                break;
            default:
                Print("Невiрний вибiр.");
                break;
        }
    }

    static void Print(string message, bool write = false)
    {
        if (write) Console.Write(message);
        else Console.WriteLine(message);
    }

    static void PrintSnake(int[] snakeElements, int n)
    {
        Print("Елементи матрицi в стилi змiйки:");
        int index = 0;
        int rowCount = 0;

        while (index < snakeElements.Length)
        {
            for (int i = 0; i < n && index < snakeElements.Length; i++)
            {
                Console.Write(snakeElements[index] + " ");
                index++;
            }
            Console.WriteLine();

            if (index < snakeElements.Length)
            {
                if (rowCount % 2 == 0)
                {
                    for (int i = 0; i < n - 1; i++) Console.Write("  ");
                    Console.WriteLine(snakeElements[index]);
                }
                else
                {
                    Console.WriteLine(snakeElements[index]);
                }

                index++;
                rowCount++;
            }
        }
    }
    static void PrintArray(int[] array)
    {
        Print("Результат: " + string.Join(", ", array));
    }

    static void PrintTask4Results((int[] sums, int maxSum) results)
    {
        Print("Сума елементiв кожного рядка:");
        PrintArray(results.sums);
        Print($"Максимальна сума: {results.maxSum}");
    }

    public static int[] Task1()
    {
        Print("Введiть розмiр масиву: ", true);
        int n = Convert.ToInt32(Console.ReadLine());
        int[] array = new int[n];

        Print("Введiть елементи масиву:");
        for (int i = 0; i < n; i++)
        {
            array[i] = Convert.ToInt32(Console.ReadLine());
        }

        List<int> oddIndices = new List<int>();
        for (int i = 0; i < n; i++)
        {
            if (array[i] % 2 != 0)
            {
                oddIndices.Add(i);
            }
        }
        return oddIndices.ToArray();
    }

    public static int Task2()
    {
        Print("Введiть кiлькiсть рядкiв: ", true);
        int rows = Convert.ToInt32(Console.ReadLine());
        Print("Введiть кiлькiсть стовпцiв: ", true);
        int cols = Convert.ToInt32(Console.ReadLine());
        int[,] array = new int[rows, cols];

        Print("Введiть елементи масиву:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                array[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        int maxNegative = int.MinValue;
        bool hasNegative = false;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (array[i, j] < 0)
                {
                    hasNegative = true;
                    if (array[i, j] > maxNegative)
                    {
                        maxNegative = array[i, j];
                    }
                }
            }
        }

        if (hasNegative)
        {
            return maxNegative;
        }
        else
        {
            throw new InvalidOperationException("В масивi немає вiд’ємних елементiв.");
        }
    }

    public static (int[], int) Task3()
    {
        Print("Введiть розмiр матрицi (n x n): ", true);
        int n = Convert.ToInt32(Console.ReadLine());
        int[,] matrix = new int[n, n];

        Print("Введiть елементи матрицi:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        List<int> snakeElements = new List<int>();
        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0) // парний рядок
            {
                for (int j = 0; j < n; j++)
                {
                    snakeElements.Add(matrix[i, j]);
                }
            }
            else // непарний рядок
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    snakeElements.Add(matrix[i, j]);
                }
            }
        }
        return (snakeElements.ToArray(), n);
    }

    public static (int[] sums, int maxSum) Task4()
    {
        Print("Введiть кiлькiсть рядкiв: ", true);
        int n = Convert.ToInt32(Console.ReadLine());
        int[][] jaggedArray = new int[n][];
        int[] sums = new int[n];

        for (int i = 0; i < n; i++)
        {
            Print($"Введiть кiлькiсть елементiв в рядку {i + 1}: ", true);
            int m = Convert.ToInt32(Console.ReadLine());
            jaggedArray[i] = new int[m];

            Print($"Введiть елементи рядка {i + 1}:");
            for (int j = 0; j < m; j++)
            {
                jaggedArray[i][j] = Convert.ToInt32(Console.ReadLine());
                sums[i] += jaggedArray[i][j];
            }
        }

        int maxSum = sums[0];
        for (int i = 1; i < sums.Length; i++)
        {
            if (sums[i] > maxSum)
            {
                maxSum = sums[i];
            }
        }
        return (sums, maxSum);
    }
}
