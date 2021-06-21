using System;

namespace Task1
{
    // Задание 1.
    // Воспользовавшись решением задания 3 четвертого модуля
    // 1.1. Создать метод, принимающий число и матрицу, возвращающий матрицу умноженную на число
    // 1.2. Создать метод, принимающий две матрицу, возвращающий их сумму
    // 1.3. Создать метод, принимающий две матрицу, возвращающий их произведение

    class Program
    {
        private static uint LinesNumber { get; set; }
        private static uint ColumnsNumber { get; set; }

        static void Reset()
        {
            LinesNumber = 0;
            ColumnsNumber = 0;
        }

        static int[,] FillMatrix(uint linesNumber, uint columnsNumber)
        {
            var random = new Random();
            var matrix = new int[linesNumber, columnsNumber];

            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(-5, 5);
                }
            }

            return matrix;
        }

        static void PrintMatrix(int[,] matrix)
        {  
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],3} ");
                }
                Console.WriteLine();
            }
        }

        static uint InputValidValue()
        {
            uint value = 0;
            while (value <= 0)
            {
                if (!uint.TryParse(Console.ReadLine(), out value))
                    Console.WriteLine("Вы ввели не правильное число");
            }
            return value;
        }

        static int[,] MatrixMultiplicationByNumber(int[,] matrix1, int value)
        {
            var matrix = new int[LinesNumber, ColumnsNumber];
            for (var i = 0; i < matrix1.GetLength(0); i++)
            {
                for (var j = 0; j < matrix1.GetLength(1); j++)
                {
                    matrix[i, j] = matrix1[i, j] * value;
                }
            }
            return matrix;
        }

        static int[,] MatrixAddition(int[,] matrix1, int[,] matrix2)
        {
            var matrix = new int[LinesNumber, ColumnsNumber];
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            return matrix;
        }

        static int[,] MatrixSubtraction(int[,] matrix1, int[,] matrix2)
        {
            var matrix = new int[LinesNumber, ColumnsNumber];
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }
            return matrix;
        }

        static int[,] MatrixMultiplication(int[,] matrix1, int[,] matrix2)
        {
            var matrix = new int[LinesNumber, LinesNumber];
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = 0;
                    for (var k = 0; k < matrix1.GetLength(1); k++)
                    {
                        matrix[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            return matrix;
        }


        static void Main(string[] args)
        {
            // 1.1. Создать метод, принимающий число и матрицу, возвращающий матрицу умноженную на число
            Reset();

            Console.WriteLine("Введите количесвтво строк");
            LinesNumber = InputValidValue();

            Console.WriteLine("Введите количесвтво столбцов");
            ColumnsNumber = InputValidValue();

            var matrix1 = FillMatrix(LinesNumber, ColumnsNumber);

            Console.WriteLine("Наша матрица");
            PrintMatrix(matrix1);

            var value = int.MaxValue;
            Console.WriteLine("Введите коэффициент");
            while (value == int.MaxValue)
            {
                if (!int.TryParse(Console.ReadLine(), out value))
                {
                    Console.WriteLine("Вы ввели не правильный коэффициент");
                    value = int.MaxValue;
                }
            }

            Console.WriteLine($"Результат умножения матрицы на число {value}:");
            PrintMatrix(MatrixMultiplicationByNumber(matrix1, value));

            // 1.2. Создать метод, принимающий две матрицу, возвращающий их сумму
            Reset();

            Console.WriteLine("Введите количесвтво строк");
            LinesNumber = InputValidValue();

            Console.WriteLine("Введите количесвтво столбцов");
            ColumnsNumber = InputValidValue();

            var matrix2 = FillMatrix(LinesNumber, ColumnsNumber);
            var matrix3 = FillMatrix(LinesNumber, ColumnsNumber);

            Console.WriteLine("Наша первая матрица");
            PrintMatrix(matrix2);

            Console.WriteLine("Наша вторая матрица");
            PrintMatrix(matrix3);

            Console.WriteLine("Результат сложение матриц:");
            PrintMatrix(MatrixAddition(matrix2, matrix3));

            Console.WriteLine("Результат вычитание матриц:");
            PrintMatrix(MatrixSubtraction(matrix2, matrix3));

            // 1.3. Создать метод, принимающий две матрицу, возвращающий их произведение
            Reset();

            Console.WriteLine("Введите количесвтво строк");
            LinesNumber = InputValidValue();

            Console.WriteLine("Введите количесвтво столбцов");
            ColumnsNumber = InputValidValue();

            var matrix4 = FillMatrix(LinesNumber, ColumnsNumber);
            var matrix5 = FillMatrix(ColumnsNumber, LinesNumber);

            Console.WriteLine("Наша первая матрица");
            PrintMatrix(matrix4);

            Console.WriteLine("Наша вторая матрица");
            PrintMatrix(matrix5);

            Console.WriteLine("Результат умножения матриц:");
            PrintMatrix(MatrixMultiplication(matrix4, matrix5));
        }
    }
}
