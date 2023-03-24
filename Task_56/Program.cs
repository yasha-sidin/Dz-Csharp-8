// Задайте прямоугольный двумерный массив. Напишите программу, 
// которая будет находить строку с наименьшей суммой элементов.

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
int GetMinFromArray(int[] array)
{
    int countElementsInArray = array.Length;
    int min = array[0];
    for(int i = 1; i < countElementsInArray; i++)
    {
        if(array[i] < min) min = array[i];
    }

    return min;
}

// -----------------------------------------------------------------------------------------

// Упорядочить по убыванию строки двумерного массива
void GetNumberOfRowWhereMinSum(int[,] tableArray)
{
    int countRows = tableArray.GetLength(0);
    int countColumns = tableArray.GetLength(1);
    int[] temporary = new int[countRows];
    int sum = 0;
    int minRow;
    for(int j = 0; j < countColumns; j++)
    {
        sum += tableArray[0, j];
    }
    temporary[0] = sum;
    minRow = sum;
    for(int i = 1; i < countRows; i++)
    {
        sum = 0;
        for(int j = 0; j < countColumns; j++)
        {
            sum += tableArray[i, j];
        }
        temporary[i] = sum;
    }
    int result = Array.IndexOf(temporary, GetMinFromArray(temporary));
    Console.WriteLine($"{result + 1} строка");
}

// -----------------------------------------------------------------------------------------

Console.Clear();
Console.Write("Количество строк массива (m): ");
int m = int.Parse(Console.ReadLine());
Console.Write("Количество столбцов массива (m): ");
int n = int.Parse(Console.ReadLine());

int[,] tableArray = CreateAndFillIntTableArray(m, n, 0, 10);
PrintIntTableArray(tableArray);
Console.WriteLine();
GetNumberOfRowWhereMinSum(tableArray);
