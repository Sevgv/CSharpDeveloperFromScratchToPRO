using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_04
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задание 1.
            // Заказчик просит вас написать приложение по учёту финансов
            // и продемонстрировать его работу.
            // Суть задачи в следующем: 
            // Руководство фирмы по 12 месяцам ведет учет расходов и поступлений средств. 
            // За год получены два массива – расходов и поступлений.
            // Определить прибыли по месяцам
            // Количество месяцев с положительной прибылью.
            // Добавить возможность вывода трех худших показателей по месяцам, с худшей прибылью, 
            // если есть несколько месяцев, в некоторых худшая прибыль совпала - вывести их все.
            // Организовать дружелюбный интерфейс взаимодействия и вывода данных на экран

            // Пример
            //       
            // Месяц      Доход, тыс. руб.  Расход, тыс. руб.     Прибыль, тыс. руб.
            //     1              100 000             80 000                 20 000
            //     2              120 000             90 000                 30 000
            //     3               80 000             70 000                 10 000
            //     4               70 000             70 000                      0
            //     5              100 000             80 000                 20 000
            //     6              200 000            120 000                 80 000
            //     7              130 000            140 000                -10 000
            //     8              150 000             65 000                 85 000
            //     9              190 000             90 000                100 000
            //    10              110 000             70 000                 40 000
            //    11              150 000            120 000                 30 000
            //    12              100 000             80 000                 20 000
            // 
            // Худшая прибыль в месяцах: 7, 4, 1, 5, 12
            // Месяцев с положительной прибылью: 10


            // * Задание 2
            // Заказчику требуется приложение строящее первых N строк треугольника паскаля. N < 25
            // 
            // При N = 9. Треугольник выглядит следующим образом:
            //                                 1
            //                             1       1
            //                         1       2       1
            //                     1       3       3       1
            //                 1       4       6       4       1
            //             1       5      10      10       5       1
            //         1       6      15      20      15       6       1
            //     1       7      21      35      35       21      7       1
            //                                                              
            //                                                              
            // Простое решение:                                                             
            // 1
            // 1       1
            // 1       2       1
            // 1       3       3       1
            // 1       4       6       4       1
            // 1       5      10      10       5       1
            // 1       6      15      20      15       6       1
            // 1       7      21      35      35       21      7       1
            // 
            // Справка: https://ru.wikipedia.org/wiki/Треугольник_Паскаля


            // 
            // * Задание 3.1
            // Заказчику требуется приложение позволяющщее умножать математическую матрицу на число
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Умножение_матрицы_на_число
            // Добавить возможность ввода количество строк и столцов матрицы и число,
            // на которое будет производиться умножение.
            // Матрицы заполняются автоматически. 
            // Если по введённым пользователем данным действие произвести невозможно - сообщить об этом
            //
            // Пример
            //
            //      |  1  3  5  |   |  5  15  25  |
            //  5 х |  4  5  7  | = | 20  25  35  |
            //      |  5  3  1  |   | 25  15   5  |
            //
            //
            // ** Задание 3.2
            // Заказчику требуется приложение позволяющщее складывать и вычитать математические матрицы
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Сложение_матриц
            // Добавить возможность ввода количество строк и столцов матрицы.
            // Матрицы заполняются автоматически
            // Если по введённым пользователем данным действие произвести невозможно - сообщить об этом
            //
            // Пример
            //  |  1  3  5  |   |  1  3  4  |   |  2   6   9  |
            //  |  4  5  7  | + |  2  5  6  | = |  6  10  13  |
            //  |  5  3  1  |   |  3  6  7  |   |  8   9   8  |
            //  
            //  
            //  |  1  3  5  |   |  1  3  4  |   |  0   0   1  |
            //  |  4  5  7  | - |  2  5  6  | = |  2   0   1  |
            //  |  5  3  1  |   |  3  6  7  |   |  2  -3  -6  |
            //
            // *** Задание 3.3
            // Заказчику требуется приложение позволяющщее перемножать математические матрицы
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Умножение_матриц
            // Добавить возможность ввода количество строк и столцов матрицы.
            // Матрицы заполняются автоматически
            // Если по введённым пользователем данным действие произвести нельзя - сообщить об этом
            //  
            //  |  1  3  5  |   |  1  3  4  |   | 22  48  57  |
            //  |  4  5  7  | х |  2  5  6  | = | 35  79  95  |
            //  |  5  3  1  |   |  3  6  7  |   | 14  36  45  |
            //
            //  
            //                  | 4 |   
            //  |  1  2  3  | х | 5 | = | 32 |
            //                  | 6 |  
            //

            #region Задание 1

            Console.WriteLine("Задание 1");
            Console.WriteLine();

            var income = new int[12] { 100_000, 120_000, 90_000, 70_000, 100_000, 200_000, 130_000, 150_000, 190_000, 110_000, 150_000, 100_000 };
            var expenses = new int[12] { 80_000, 90_000, 70_000, 70_000, 80_000, 120_000, 140_000, 65_000, 90_000, 70_000, 120_000, 80_000 };

            // var income = new int[12];
            // var expenses = new int[12];
            var profit = new int[12];

            var positiveProfit = 0;

            var random = new Random();

            Console.WriteLine("Месяц      Доход, тыс. руб.  Расход, тыс. руб.     Прибыль, тыс. руб.");

            for (var i = 0; i < income.Length; i++)
            {
                // income[i] = random.Next(10000, 200000);
                // expenses[i] = random.Next(10000, 200000);
                profit[i] = income[i] - expenses[i];

                if (profit[i] > 0) positiveProfit++;

                Console.WriteLine($"{i + 1,5}      {income[i],15:N0}   {expenses[i],16:N0}      {profit[i],17:N0}");
            }

            int count = 0;
            int[] minMonthProfits = new int[12];

            for (var i = 0; i < minMonthProfits.Length; i++)
            {
                minMonthProfits[i] = Int32.MaxValue;
            }

            int[] copyData = new int[12];
            Array.Copy(profit, copyData, profit.Length);

            while (count < 3)
            {
                int min = copyData[0];

                foreach (var p in copyData)
                {
                    if (min > p)
                        min = p;
                }

                int res = 0;
                while (res != -1)
                {
                    res = Array.IndexOf(copyData, min);
                    if (res != -1)
                    {
                        copyData[res] = Int32.MaxValue;

                        int index = 0;
                        for (var i = 0; i < minMonthProfits.Length; i++)
                        {
                            if (minMonthProfits[i] == Int32.MaxValue)
                            {
                                index = i;
                                break;
                            }
                        }

                        minMonthProfits[index] = res + 1;
                    }
                }

                count++;
            }

            Console.WriteLine();

            Console.Write("Худшая прибыль в месяцах: ");
            foreach (var e in minMonthProfits)
            {
                if (e != Int32.MaxValue)
                    Console.Write($"{e} ");
            }

            Console.WriteLine();
            Console.WriteLine($"Месяцев с положительной прибылью: {positiveProfit}");

            // Console.ReadKey();
            #endregion

            #region Задание 2

            Console.WriteLine("Задание 2");
            Console.WriteLine();

            int N = 9;
            // N = int.TryParse(Console.ReadLine(), out N) ? N : 9;

            var pascalTriangle = new int[N + 1][];

            for (var i = 0; i < pascalTriangle.Length; i++)
            {
                pascalTriangle[i] = new int[i + 1];
                for (var j = 0; j < pascalTriangle[i].Length; j++)
                {
                    if (j == 0 || j == pascalTriangle[i].Length - 1)
                        pascalTriangle[i][j] = 1;
                    else if (j == 1 || j == pascalTriangle[i].Length - 2)
                        pascalTriangle[i][j] = i;
                    else
                        pascalTriangle[i][j] = pascalTriangle[i - 1][j - 1] + pascalTriangle[i - 1][j];
                }
            }

            foreach (var array in pascalTriangle)
            {
                foreach (var e in array)
                {
                    Console.Write($"{e,3}     ");
                }

                Console.WriteLine();
            }

            // Console.ReadKey();

            #endregion

            #region Задание 3

            Console.WriteLine("Задание 3");

            #region Задание 3.1

            Console.WriteLine("Задание 3.1");
            Console.WriteLine();

            uint linesNumber = 0;
            uint columnsNumber = 0;
            var value = int.MaxValue;

            Console.WriteLine("Введите количесвтво строк");
            while (linesNumber <= 0)
            {
                if (!uint.TryParse(Console.ReadLine(), out linesNumber))
                    Console.WriteLine("Вы ввели не правильное количество строк");
            }

            Console.WriteLine("Введите количесвтво столбцов");
            while (columnsNumber <= 0)
            {
                if (!uint.TryParse(Console.ReadLine(), out columnsNumber))
                    Console.WriteLine("Вы ввели не правильное количество столбцов");
            }

            var matrix1 = new int[linesNumber, columnsNumber];

            Console.WriteLine("Наша матрица");
            for (var i = 0; i < matrix1.GetLength(0); i++)
            {
                for (var j = 0; j < matrix1.GetLength(1); j++)
                {
                    matrix1[i, j] = random.Next(-5, 5);
                    Console.Write($"{matrix1[i, j],3} ");
                }

                Console.WriteLine();
            }

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
            for (var i = 0; i < matrix1.GetLength(0); i++)
            {
                for (var j = 0; j < matrix1.GetLength(1); j++)
                {
                    Console.Write($"{matrix1[i, j] * value,3} ");
                }

                Console.WriteLine();
            }

            #endregion

            #region Задание 3.2

            Console.WriteLine("Задание 3.2");
            Console.WriteLine();

            linesNumber = 0;
            columnsNumber = 0;

            Console.WriteLine("Введите количесвтво строк");
            while (linesNumber == 0)
            {
                if (!uint.TryParse(Console.ReadLine(), out linesNumber))
                    Console.WriteLine("Вы ввели не правильное количество строк");
            }

            Console.WriteLine("Введите количесвтво столбцов");
            while (columnsNumber == 0)
            {
                if (!uint.TryParse(Console.ReadLine(), out columnsNumber))
                    Console.WriteLine("Вы ввели не правильное количество столбцов");
            }

            var matrix2 = new int[linesNumber, columnsNumber];
            var matrix3 = new int[linesNumber, columnsNumber];

            for (var i = 0; i < matrix2.GetLength(0); i++)
            {
                for (var j = 0; j < matrix2.GetLength(1); j++)
                {
                    matrix2[i, j] = random.Next(-5, 5);
                    matrix3[i, j] = random.Next(-5, 5);
                }
            }

            Console.WriteLine("Наша первая матрица:");
            for (var i = 0; i < matrix2.GetLength(0); i++)
            {
                for (var j = 0; j < matrix2.GetLength(1); j++)
                {
                    Console.Write($"{matrix2[i, j],3} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine("Наша вторая матрица:");
            for (var i = 0; i < matrix3.GetLength(0); i++)
            {
                for (var j = 0; j < matrix3.GetLength(1); j++)
                {
                    Console.Write($"{matrix3[i, j],3} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine("Результат сложение матриц:");
            for (var i = 0; i < matrix2.GetLength(0); i++)
            {
                for (var j = 0; j < matrix2.GetLength(1); j++)
                {
                    Console.Write($"{matrix2[i, j] + matrix3[i, j],3} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine("Результат вычитание матриц:");
            for (var i = 0; i < matrix2.GetLength(0); i++)
            {
                for (var j = 0; j < matrix2.GetLength(1); j++)
                {
                    Console.Write($"{matrix2[i, j] - matrix3[i, j],3} ");
                }

                Console.WriteLine();
            }

            #endregion

            #region Задание 3.3

            Console.WriteLine("Задание 3.3");

            linesNumber = 0;
            columnsNumber = 0;

            Console.WriteLine("Введите количесвтво строк");
            while (linesNumber == 0)
            {
                if (!uint.TryParse(Console.ReadLine(), out linesNumber))
                    Console.WriteLine("Вы ввели не правильное количество строк");
            }

            Console.WriteLine("Введите количесвтво столбцов");
            while (columnsNumber == 0)
            {
                if (!uint.TryParse(Console.ReadLine(), out columnsNumber))
                    Console.WriteLine("Вы ввели не правильное количество столбцов");
            }

            var matrix4 = new int[linesNumber, columnsNumber];
            var matrix5 = new int[columnsNumber, linesNumber];

            for (var i = 0; i < matrix4.GetLength(0); i++)
            {
                for (var j = 0; j < matrix4.GetLength(1); j++)
                {
                    matrix4[i, j] = random.Next(-5, 5);
                }
            }

            for (var i = 0; i < matrix5.GetLength(0); i++)
            {
                for (var j = 0; j < matrix5.GetLength(1); j++)
                {
                    matrix5[i, j] = random.Next(-5, 5);
                }
            }

            Console.WriteLine("Наша первая матрица:");
            for (var i = 0; i < matrix4.GetLength(0); i++)
            {
                for (var j = 0; j < matrix4.GetLength(1); j++)
                {
                    Console.Write($"{matrix4[i, j],3} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine("Наша вторая матрица:");
            for (var i = 0; i < matrix5.GetLength(0); i++)
            {
                for (var j = 0; j < matrix5.GetLength(1); j++)
                {
                    Console.Write($"{matrix5[i, j],3} ");
                }

                Console.WriteLine();
            }

            var matrix6 = new int[linesNumber, linesNumber];

            Console.WriteLine("Результат умножения матриц:");
            for (var i = 0; i < matrix6.GetLength(0); i++)
            {
                for (var j = 0; j < matrix6.GetLength(1); j++)
                {
                    matrix6[i, j] = 0;
                    for (var k = 0; k < matrix4.GetLength(1); k++)
                    {
                        matrix6[i, j] += matrix4[i, k] * matrix5[k, j];
                    }
                    Console.Write($"{matrix6[i, j],3} ");
                }

                Console.WriteLine();
            }

            Console.ReadKey();

            #endregion

            #endregion
        }
    }
}
