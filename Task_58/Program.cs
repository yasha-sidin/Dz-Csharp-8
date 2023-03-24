// Задача 58: Задайте две матрицы. 
// Напишите программу, которая будет находить произведение двух матриц.

// Напечатать матрицу целых чисел
void PrintIntMatrix(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    for(int i = 0; i < rows; i++)
    {
        for(int j = 0; j < columns; j++)
        {
            if(j == matrix.GetLength(1) - 1)
            {
                Console.WriteLine($"{matrix[i, j]}");
                break;
            }
            Console.Write($"{matrix[i, j]}\t");
        }
    }
}

// -----------------------------------------------------------------------------------------

// Заполнить двумерный массив случайными числами
int[,] CreateAndFillIntMatrix(int countRows, int countColumns, int startRange, int endRange)
{
    int[,] matrix = new int[countRows, countColumns];
    for(int i = 0; i < countRows; i++)
    {
        for(int j = 0; j < countColumns; j++)
        {
            matrix[i, j] = new Random().Next(startRange, endRange + 1);
        }
    }

    return matrix;
}

// -----------------------------------------------------------------------------------------

bool CheckMultiplicationMatrixes(int[,] matrixFirst, int[,] matrixSecond)
{
    if (matrixFirst.GetLength(1) == matrixSecond.GetLength(0)) return true;
    else return false;
}

// -----------------------------------------------------------------------------------------

void GetMultiplicationOfMatrixes(int[,] matrixFirst, int[,] matrixSecond)
{
    if (CheckMultiplicationMatrixes(matrixFirst, matrixSecond) == true)
    {
        int countRowsFirst = matrixFirst.GetLength(0);
        int countColumnsFirst = matrixFirst.GetLength(1);
        int countRowsSecond = matrixSecond.GetLength(0);
        int countColumnsSecond = matrixSecond.GetLength(1);
        int[,] resultMatrix = new int[countRowsFirst, countColumnsSecond];
        for (int i = 0; i < countRowsFirst; i++)
        {
            for (int j = 0; j < countColumnsSecond; j++)
            {
                resultMatrix[i, j] = 0;
                for (int k = 0; k < countColumnsFirst; k ++)
                {
                    resultMatrix[i, j] += matrixFirst[i, k] * matrixSecond[k, j];
                }
            }
        }

        PrintIntMatrix(resultMatrix);
    }
    else
    {
        Console.WriteLine("Нельзя перемножить данные матрицы");
    }
}

// -----------------------------------------------------------------------------------------

Console.Clear();
Console.Write("Количество строк первой матрицы (m1): ");
int m1 = int.Parse(Console.ReadLine());
Console.Write("Количество столбцов первой матрицы (n1): ");
int n1 = int.Parse(Console.ReadLine());

Console.Write("Количество строк второй матрицы (m2): ");
int m2 = int.Parse(Console.ReadLine());
Console.Write("Количество столбцов второй матрицы (n2): ");
int n2 = int.Parse(Console.ReadLine());

int[,] matrixFirst = CreateAndFillIntMatrix(m1, n1, 0, 10);
PrintIntMatrix(matrixFirst);

Console.WriteLine();

int[,] matrixSecond = CreateAndFillIntMatrix(m2, n2, 0, 10);
PrintIntMatrix(matrixSecond);

Console.WriteLine();

GetMultiplicationOfMatrixes(matrixFirst, matrixSecond);