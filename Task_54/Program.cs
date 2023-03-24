// Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы
// каждой строки двумерного массива.

using System.Linq;
// Напечатать двумерный массив
void PrintIntTableArray(int[,] tableArray)
{
    int rows = tableArray.GetLength(0);
    int columns = tableArray.GetLength(1);
    for(int i = 0; i < rows; i++)
    {
        for(int j = 0; j < columns; j++)
        {
            if(j == tableArray.GetLength(1) - 1)
            {
                Console.WriteLine($"{tableArray[i, j]}");
                break;
            }
            Console.Write($"{tableArray[i, j]}\t");
        }
    }
}

// -----------------------------------------------------------------------------------------

// Заполнить двумерный массив случайными числами
int[,] CreateAndFillIntTableArray(int countRows, int countColumns, int startRange, int endRange)
{
    int[,] tableArray = new int[countRows, countColumns];
    for(int i = 0; i < countRows; i++)
    {
        for(int j = 0; j < countColumns; j++)
        {
            tableArray[i, j] = new Random().Next(startRange, endRange + 1);
        }
    }

    return tableArray;
}

// -----------------------------------------------------------------------------------------

// Поиск max в массиве
int GetMaxFromArray(int[] array)
{
    int countElementsInArray = array.Length;
    int max = array[0];
    for(int i = 1; i < countElementsInArray; i++)
    {
        if(array[i] > max) max = array[i];
    }

    return max;
}

// -----------------------------------------------------------------------------------------

// Упорядочить по убыванию строки двумерного массива
int[,] SortLowRowsInIntTableArray(int[,] tableArray)
{
    int countRows = tableArray.GetLength(0);
    int countColumns = tableArray.GetLength(1);
    int temp;
    for(int i = 0; i < countRows; i++)
    {
        int[] temporary = new int[countColumns];
        for(int k = 0; k < countColumns; k++)
        {
            temp = tableArray[i, k];
            temporary[k] = temp;
        }
        for(int j = 0; j < countColumns; j++)
        {
            tableArray[i, j] = GetMaxFromArray(temporary);
            temporary = temporary.Where((sourse, index) =>index != Array.IndexOf(temporary, tableArray[i, j])).ToArray();
        }
    }

    return tableArray;
}

// -----------------------------------------------------------------------------------------

Console.Clear();
Console.Write("Количество строк массива (m): ");
int m = int.Parse(Console.ReadLine());
Console.Write("Количество столбцов массива (m): ");
int n = int.Parse(Console.ReadLine());

int[,] tableArray = CreateAndFillIntTableArray(m, n, 0, 1000);
PrintIntTableArray(tableArray);
Console.WriteLine();
SortLowRowsInIntTableArray(tableArray);
PrintIntTableArray(tableArray);

