// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.

// Создание трехмерного массива
int [,,] Get3DIntArray(int length = 5, int latitude = 2, int height = 9)
{
    int temp = 10;
    int[,,] array3D = new int[length, latitude, height];
    for (int i = 0; i < length; i++)
    {
        for (int j = 0; j < latitude; j++)
        {
            for (int k = 0; k < height; k++)
            {
                array3D[i, j, k] = temp;
                temp++;
            }
        }
    }

    return array3D;
}

// -----------------------------------------------------------------------------------------

// Вывод трехмерного массива с указанием индексов
void Print3DIntArray(int [,,] array3D)
{
    int length = array3D.GetLength(0);
    int latitude = array3D.GetLength(1);
    int height = array3D.GetLength(2);
    for (int i = 0; i < length; i++)
    {
        for (int j = 0; j < latitude; j++)
        {
            for (int k = 0; k < height; k++)
            {
                Console.Write($"{array3D[i, j, k]}({i},{j},{k}) ");
            }
            Console.WriteLine();
        }
    }
}


// -----------------------------------------------------------------------------------------


int[,,] array3D = Get3DIntArray();
Print3DIntArray(array3D);