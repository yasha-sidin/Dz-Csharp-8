// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

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

// Заполнение двумерного массива спирально
int[,] GetSpiralTableArray(int[,] tableArray, int n)
{
    int i = 0;
    int j = 0;
    int value = 1;
    for (int e = 0; e < n * n; e++)
    {
        int k = 0;
        do { tableArray[i, j++] = value++; } while (++k < n - 1);
        for (k = 0; k < n - 1; k++) tableArray[i++, j] = value++;
        for (k = 0; k < n - 1; k++) tableArray[i, j--] = value++;
        for (k = 0; k < n - 1; k++) tableArray[i--, j] = value++;
        ++i; ++j;
        n = n < 2 ? 0 : n - 2;
    }
    return tableArray;
}

int[,] tableArray = CreateAndFillIntTableArray(4, 4, 0, 1);
tableArray = GetSpiralTableArray(tableArray, 4);
PrintIntTableArray(tableArray);