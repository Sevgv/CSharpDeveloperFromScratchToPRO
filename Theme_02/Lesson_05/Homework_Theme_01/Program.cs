using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework_Theme_01
{
    /// <summary>
    /// Класс для работы с экзаменами
    /// </summary>
    public class Exam
    {
        /// <summary>
        /// Имя экзамена, берется из справочника предметов
        /// </summary>
        public Subjects Name { get; set; }
        /// <summary>
        /// Балл за экзамен
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// Преобразование объекта в строку
        /// </summary>
        public override string ToString() => $"{Name,15}: {Score,3}";
    }
    /// <summary>
    /// Справочник названий предметов
    /// </summary>
    public enum Subjects
    {
        Математика,
        Русский_язык,
        История
    }
    /// <summary>
    /// Основной класс работы с пользователем
    /// </summary>
    public class User
    {
        /// <summary>
        /// Конструктор пользователя
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="age">Возраст</param>
        /// <param name="growth">Рост</param>
        /// <param name="scores">Балл за экзамен</param>
        public User(string name, int age, double growth, List<Exam> scores)
        {
            Name = name;
            Age = age;
            Growth = growth;
            Scores = scores;
        }
        /// <summary>
        /// Имя
        /// </summary>
        private string Name { get; }
        /// <summary>
        /// Возраст
        /// </summary>
        private int Age { get; }
        /// <summary>
        /// Рост
        /// </summary>
        private double Growth { get; }
        /// <summary>
        /// Балл за экзамен
        /// </summary>
        private List<Exam> Scores { get; }
        /// <summary>
        /// Добавление результата экзамена, проверка на существующие элементы
        /// </summary>
        /// <param name="exam">Экземпляр класса Exam</param>
        /// <returns>Возвращает логическое значение в зависимости от результата добавления</returns>
        public bool AddExam(Exam exam)
        {
            // Выполняется поиск одинаковых экзаменов
            if (Scores.Contains(exam) || Scores.Exists(s => s.Name == exam.Name))
                return false;
            // Добавляем в список новый элемент, если такого не было раньше
            Scores.Add(exam);
            return true;
        }
        /// <summary>
        /// Получает имя пользователя
        /// </summary>
        /// <returns>Имя пользователя</returns>
        public string GetName() => Name;
        /// <summary>
        /// Получает среднее арифметическое баллов пользователя
        /// </summary>
        /// <returns>Cреднее арифметическое баллов пользователя</returns>
        public double GetAverageExamScore() => Convert.ToDouble(Scores.Select(s => s.Score).Sum()) / Scores.Count;
        /// <summary>
        /// Обычный вывод на консоль
        /// </summary>
        /// <param name="users">Список пользователей</param>
        public static void Print(IEnumerable<User> users)
        {
            // Запускаем цикл перечисления пользователей
            foreach (var user in users)
            {
                // Выводим информацию о пользователе
                PrintOnCenter("Имя: " + user.Name + " Возраст: " + user.Age + " Рост: " + user.Growth);

                // Выводим информацию о баллах
                foreach (var score in user.Scores)
                    PrintOnCenter(score.ToString());
            }
        }
        /// <summary>
        /// Форматированный вывод на консоль
        /// </summary>
        /// <param name="users">Список пользователей</param>
        public static void PrintFormatted(IEnumerable<User> users)
        {
            // Запускаем цикл перечисления пользователей
            foreach (var user in users)
            {
                // Изменяем цвет шрифта для печати в консоли на DarkRed
                Console.ForegroundColor = ConsoleColor.DarkRed;

                // Выводим информацию о пользователе
                PrintOnCenter("Имя: " + user.Name + " Возраст: " + user.Age + " Рост: " + user.Growth);

                // Изменяем цвет шрифта для печати в консоли на Gray
                Console.ForegroundColor = ConsoleColor.Gray;

                // Выводим информацию о баллах
                foreach (var score in user.Scores)
                    PrintOnCenter(score.ToString());
            }
        }
        /// <summary>
        /// Вывод с использованием интерполяции строк
        /// </summary>
        /// <param name="users">Список пользователей</param>
        public static void PrintInterpolated(IEnumerable<User> users)
        {
            // Изменяем цвет шрифта для печати в консоли на DarkRed
            Console.ForegroundColor = ConsoleColor.DarkRed;

            // Выводим шапку
            PrintOnCenter($"{"Имя",15} {"Возраст",10} {"Рост",10}");

            // Запускаем цикл перечисления пользователей
            foreach (var user in users)
            {
                // Изменяем цвет шрифта для печати в консоли на Gray
                Console.ForegroundColor = ConsoleColor.Gray;

                // Выводим информацию о пользователе
                PrintOnCenter(
                    $"{user.Name,15} {user.Age,10} {user.Growth,10}");

                // Выводим информацию о баллах
                foreach (var score in user.Scores)
                    PrintOnCenter(score.ToString());
            }
        }

        /// <summary>
        /// Установить консоль в режим вывода по центру ширины консоли
        /// </summary>
        /// <param name="str">Выводимая строка</param>
        /// <param name="firstString">Параметр указывает, что выводится первая строка</param>
        public static void PrintOnCenter(string str, bool firstString = false)
        {
            // Устанавливаем курсор в позицию по центру консоли
            if (firstString)
                Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2,
                    Console.WindowHeight / 2);
            else
                Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2,
                    Console.CursorTop);

            // Выволим на консоль выводимую строку
            Console.WriteLine(str);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Заказчик просит написать программу «Записная книжка». Оплата фиксированная - $ 120.

            // В данной программе, должна быть возможность изменения значений нескольких переменных для того,
            // чтобы персонифецировать вывод данных, под конкретного пользователя.

            // Для этого нужно: 
            // 1. Создать несколько переменных разных типов, в которых могут храниться данные
            //    - имя;
            //    - возраст;
            //    - рост;
            //    - баллы по трем предметам: история, математика, русский язык;

            // 2. Реализовать в системе автоматический подсчёт среднего балла по трем предметам, 
            //    указанным в пункте 1.

            // 3. Реализовать возможность печатки информации на консоли при помощи 
            //    - обычного вывода;
            //    - форматированного вывода;
            //    - использования интерполяции строк;

            // 4. Весь код должен быть откомментирован с использованием обычных и хml-комментариев

            // **
            // 5. В качестве бонусной части, за дополнительную оплату $50, заказчик просит реализовать 
            //    возможность вывода данных в центре консоли.


            // Создаем первого пользователя, через конструктор вводим данные о нем
            var user = new User("Вася Пупкин", 18, 194.5, new List<Exam>());

            // В пустой список экзаменов добавляем результаты через конструктор
            user.AddExam(new Exam { Name = Subjects.Математика, Score = 80 });
            user.AddExam(new Exam { Name = Subjects.Русский_язык, Score = 91 });
            user.AddExam(new Exam { Name = Subjects.История, Score = 67 });

            // Выводим первую строку по центру консоли
            User.PrintOnCenter("", true);

            // Проверка, что нельзя добавить экзамены повторно
            if (!user.AddExam(new Exam { Name = Subjects.Русский_язык, Score = 91 }))
                User.PrintOnCenter("Такой экзамен уже существует");
            Console.WriteLine();
            if (!user.AddExam(new Exam { Name = Subjects.Русский_язык, Score = 0 }))
                User.PrintOnCenter("Такой экзамен уже существует");
            Console.WriteLine();

            // Создаем еще одного пользователя
            var user2 = new User("Петя Васичкин", 21, 170.8, new List<Exam>());

            // Также добавляем ему экзамены
            user2.AddExam(new Exam { Name = Subjects.Математика, Score = 94 });
            user2.AddExam(new Exam { Name = Subjects.Русский_язык, Score = 100 });
            user2.AddExam(new Exam { Name = Subjects.История, Score = 88 });

            // Всех пользователей засовываем в список
            var allUsers = new List<User> { user, user2 };

            // Обычный вывод на консоль
            User.Print(allUsers);
            Console.WriteLine();

            // Форматированный вывод на консоль
            User.PrintFormatted(allUsers);
            Console.WriteLine();

            // Вывод с использованием интерполяции строк
            User.PrintInterpolated(allUsers);
            Console.WriteLine();

            // Вывод среднего балла обоих пользователей ( можно было не выводить отдельно, а добавить в общие принты, но я не сразу об этом подумал, а переделывать лень :) )
            User.PrintOnCenter($"Средний балл {user.GetName()}: {user.GetAverageExamScore()}");
            Console.WriteLine();
            User.PrintOnCenter($"Средний балл {user2.GetName()}: {user2.GetAverageExamScore()}");
            Console.ReadLine();

            // Как же устал комментировать очевидные строки кода :D
        }
    }
}
