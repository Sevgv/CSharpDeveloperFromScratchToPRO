using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    // Задание 2. Перестановка слов в предложении
    // Пользователь вводит в программе длинное предложение. Каждое слово раздельно одним пробелом. После ввода пользователь нажимает клавишу Enter.
    // 
    // Необходимо создать два метода:
    //    первый метод разделяет слова в предложении;
    //    второй метод меняет эти слова местами(в обратной последовательности).
    //    
    // При этом важно учесть, что один метод вызывается внутри другого метода,
    // то есть в методе main вызывается метод cо следующей сигнатурой — ReversWords(string inputPhrase).
    // Внутри этого метода вызывается метод по разделению входной фразы на слова.
    class Program
    {
        /// <summary>
        /// Делит входную строку на массив строк по пробелам
        /// </summary>
        /// <param name="inputPhrase">Входная строка</param>
        /// <returns>Массив слова</returns>
        static string[] SplitSentenceIntoWords(string inputPhrase) => inputPhrase.Split(' ');

        /// <summary>
        /// Реверсирует порядок слов во сходной строке
        /// </summary>
        /// <param name="inputPhrase">Входная строка</param>
        /// <returns>Строка из входной с обратным порядком слов</returns>
        static string ReversWords(string inputPhrase)
        {
            var resultString = "";
            var words = SplitSentenceIntoWords(inputPhrase);
            Array.Reverse(words);

            foreach(var word in words)
                resultString += word + " ";
            
            return resultString;
        }

        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            if (text == null) return;

            Console.WriteLine("Исходный текст:");
            Console.WriteLine(text);
            Console.WriteLine();

            Console.WriteLine("Реверсированный текст:");
            Console.WriteLine(ReversWords(text));
        }
    }
}
