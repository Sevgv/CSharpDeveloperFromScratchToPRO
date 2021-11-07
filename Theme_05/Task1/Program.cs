using System;

namespace Task1
{
    // Задание 1.
    // Метод разделения строки на слова

    // Что нужно сделать
    // Пользователь вводит в консольном приложении длинное предложение.
    // Каждое слово в этом предложении отделено одним пробелом.
    // Необходимо создать метод, который в качестве входного параметра принимает строковую переменную, а в качестве возвращаемого значения — массив слов.
    // После вызова данного метода программа вызывает второй метод, который выводит каждое слово в отдельной строке.

    class Program
    {
        static string[] SplitSentenceIntoWords(string line) => line.Split(' ');
        static void PrintEachWordFromArray(string[] array)
        {
            foreach (var word in array)
            {
                if (!string.IsNullOrWhiteSpace(word))
                    Console.WriteLine(word);
            }
                
        }

        static void Main(string[] args)
        {
            var line = Console.ReadLine();
            if (!string.IsNullOrEmpty(line))
                PrintEachWordFromArray(
                    SplitSentenceIntoWords(line)
                    );
        }
    }
}