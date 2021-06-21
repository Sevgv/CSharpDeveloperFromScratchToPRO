using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_03
{
    class Program
    {
        static void Main(string[] args)
        {
            // Просматривая сайты по поиску работы, у вас вызывает интерес следующая вакансия:

            // Требуемый опыт работы: без опыта
            // Частичная занятость, удалённая работа
            //
            // Описание 
            //
            // Стартап «Micarosppoftle» занимающийся разработкой
            // многопользовательских игр ищет разработчиков в свою команду.
            // Компания готова рассмотреть C#-программистов не имеющих опыта в разработке, 
            // но желающих развиваться в сфере разработки игр на платформе .NET.
            //
            // Должность Интерн C#/
            //
            // Основные требования:
            // C#, операторы ввода и вывода данных, управляющие конструкции 
            // 
            // Конкурентным преимуществом будет знание процедурного программирования.
            //
            // Не технические требования: 
            // английский на уровне понимания документации и справочных материалов
            //
            // В качестве тестового задания предлагается решить следующую задачу.
            //
            // Написать игру, в которою могут играть два игрока.
            // При старте, игрокам предлагается ввести свои никнеймы.
            // Никнеймы хранятся до конца игры.
            // Программа загадывает случайное число gameNumber от 12 до 120 сообщая это число игрокам.
            // Игроки ходят по очереди(игра сообщает о ходе текущего игрока)
            // Игрок, ход которого указан вводит число userTry, которое может принимать значения 1, 2, 3 или 4,
            // введенное число вычитается из gameNumber
            // Новое значение gameNumber показывается игрокам на экране.
            // Выигрывает тот игрок, после чьего хода gameNumber обратилась в ноль.
            // Игра поздравляет победителя, предлагая сыграть реванш
            // 
            // * Бонус:
            // Подумать над возможностью реализации разных уровней сложности.
            // В качестве уровней сложности может выступать настраиваемое, в начале игры,
            // значение userTry, изменение диапазона gameNumber, или указание большего количества игроков (3, 4, 5...)

            // *** Сложный бонус
            // Подумать над возможностью реализации однопользовательской игры
            // т е игрок должен играть с компьютером


            // Демонстрация
            // Число: 12,
            // Ход User1: 3
            //
            // Число: 9
            // Ход User2: 4
            //
            // Число: 5
            // Ход User1: 2
            //
            // Число: 3
            // Ход User2: 3
            //
            // User2 победил!

            Console.WriteLine("Игра на двоих");
            Console.WriteLine();

            Console.WriteLine("Правила игры:\n" +
                              "Программа загадывает случайное число gameNumber от 12 до 120 сообщая это число игрокам\n" +
                              "Игроки ходят по очереди(игра сообщает о ходе текущего игрока)\n" +
                              "Игрок, ход которого указан вводит число userTry, которое может принимать значения 1, 2, 3 или 4\n" +
                              "введенное число вычитается из gameNumber\n" +
                              "Новое значение gameNumber показывается игрокам на экране.\n" +
                              "Выигрывает тот игрок, после чьего хода gameNumber обратилась в ноль.\n" +
                              "Игра поздравляет победителя, предлагая сыграть реванш\n");

            // Запускаем бесконечный цикл игры

            while (true)
            {
                var gameNumber = new Random().Next(12, 20); // Получаем случайное игровое число
                var count = 0; // Счетчик, по нему определяем чей сейчас ход (четный - 1 игрок, нечетный - 2 игрок)

                Console.WriteLine("Выберите режим игры: \n" +
                                  "1. Однопользовательский\n" +
                                  "2. Многопользовательский\n");

                var gameMode = int.TryParse(Console.ReadLine(), out var inputInt) ? inputInt : 0;
                while (gameMode != 1 && gameMode != 2)
                {
                    Console.WriteLine("Вы ввели не правильное значение режима. Попробуйте еще раз.");
                    gameMode = int.TryParse(Console.ReadLine(), out inputInt) ? inputInt : 0;
                }

                string username1;
                string username2;

                if (gameMode == 1)
                {
                    // Вводим никнеймы игроков, они будут такими на протяжение всей игры
                    Console.WriteLine("Введите никнейм игрока");
                    username1 = Console.ReadLine();
                    username2 = "BMO";
                    Console.WriteLine("Привет, я BMO, я сыграю с тобой!))");
                }
                else
                {
                    // Вводим никнеймы игроков, они будут такими на протяжение всей игры
                    Console.WriteLine("Введите никнейм первого игрока");
                    username1 = Console.ReadLine();
                    Console.WriteLine("Введите никнейм второго игрока");
                    username2 = Console.ReadLine();
                }

                var command = "";
                if (username2 != "BMO")
                {
                    // Цикл хода одного игрока
                    while (gameNumber != 0)
                    {
                        command = "";
                        Console.WriteLine($"Число: {gameNumber}");

                        var username = count % 2 == 0 ? username1 : username2; // Определяем никнейм игрока

                        Console.Write($"Ход {username}: ");
                        var input = Console.ReadLine(); // Игрок вводит значение своего хода

                        var testInput = UserTryValidation(int.TryParse(input, out inputInt) ? inputInt : 0, gameNumber); // Проверяем значение
                        var userTry = testInput != null // Сохранем значение хода в зависимости от результата проверки
                            ? testInput.Value
                                ? inputInt
                                : (int?)null
                            : -1;

                        Console.WriteLine(userTry != -1
                            ? userTry != null
                                ? ""
                                : "Вы ввели не правильное число"
                            : "Результат не может быть меньше 0"); // Выводим текст ошибки, если значение хода введено не верно или результат вычитания меньше 0 

                        if (userTry != -1 && userTry != null) // Проверяем можно ли переходить к следующему игроку
                        {
                            count++; // Увеличиваем счетчик для следующего игрока
                            gameNumber -= userTry.Value; // Производим вычисление
                        }

                        if (gameNumber != 0) continue; // Если игрое число равно 0, то игра окончена
                        Console.WriteLine($"{username} победил!"); // Определяем победителя
                        break;
                    }

                }
                else
                {
                    // Цикл хода одного игрока
                    while (gameNumber != 0)
                    {
                        command = "";
                        Console.WriteLine($"Число: {gameNumber}");

                        var username = count % 2 == 0 ? username1 : username2; // Определяем никнейм игрока

                        Console.Write($"Ход {username}: ");

                        string input;
                        if (username == "BMO")
                        {
                            input = gameNumber < 5 ? gameNumber.ToString() : new Random().Next(1, 5).ToString(); // BMO выбирает хначение хода
                            Console.Write(input);
                            Console.WriteLine();
                        }
                        else
                        {
                            input = Console.ReadLine(); // Игрок вводит значение своего хода
                        }


                        var testInput = UserTryValidation(int.TryParse(input, out inputInt) ? inputInt : 0, gameNumber); // Проверяем значение
                        var userTry = testInput != null // Сохранем значение хода в зависимости от результата проверки
                            ? testInput.Value
                                ? inputInt
                                : (int?)null
                            : -1;

                        Console.WriteLine(userTry != -1
                            ? userTry != null
                                ? ""
                                : "Вы ввели не правильное число"
                            : "Результат не может быть меньше 0"); // Выводим текст ошибки, если значение хода введено не верно или результат вычитания меньше 0 

                        if (userTry != -1 && userTry != null) // Проверяем можно ли переходить к следующему игроку
                        {
                            count++; // Увеличиваем счетчик для следующего игрока
                            gameNumber -= userTry.Value; // Производим вычисление
                        }

                        if (gameNumber != 0) continue; // Если игрое число равно 0, то игра окончена
                        Console.WriteLine($"{username} победил!"); // Определяем победителя
                        break;
                    }
                }

                Console.WriteLine("Сыграем еще раз?"); // После окончания райнда, предлагаем сыграть еще
                Console.WriteLine("Нажмите \"Enter\", если хотите сыграть еще раз");
                Console.WriteLine("Введите \"Exit\" если хотите завершить работу программы.");
                Console.WriteLine();

                command = Console.ReadLine() ?? "";

                if (command.ToLower() == "exit")
                    Process.GetCurrentProcess().Kill();
            }
        }

        /// <summary>
        /// Функция проверяет правильность ввода игроков и то, что результат не уйдет в минусовое значение
        /// </summary>
        /// <param name="userTry">Вводимое число хода</param>
        /// <param name="gameNumber">Игровое число</param>
        /// <returns></returns>
        private static bool? UserTryValidation(int userTry, int gameNumber)
        {
            switch (userTry)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    return gameNumber - userTry >= 0 ? true : (bool?)null; // Проверяем, что результат больше 0, если меньше, то возвращаем null
                default:
                    return false;
            }
        }
    }
}
