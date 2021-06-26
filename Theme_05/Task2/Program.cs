using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class Program
    {
        static string GetLineContainingWordWithMinLength(string inputText)
        {
            var minLength = int.MaxValue;

            foreach (var word in inputText.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                var cleanWord = RemoveSpecialCharacters(word);
                if (minLength > cleanWord.Length && IsWord(cleanWord))
                    minLength = cleanWord.Length;
            }


            foreach (var line in inputText.Split('\n', StringSplitOptions.RemoveEmptyEntries))
            {
                foreach (var word in line.Split(' ', StringSplitOptions.TrimEntries))
                {
                    var cleanWord = RemoveSpecialCharacters(word);
                    if (minLength == cleanWord.Length && IsWord(cleanWord))
                        return line;
                }
            }

            return "Строка не найдена";
        }

        static bool IsWord(string word)
        {
            var c = word[0];
            return word.Length > 1 ||
                (c >= 'A' && c <= 'Z') ||
                (c >= 'a' && c <= 'z') ||
                (c >= 'А' && c <= 'Я') ||
                (c >= 'а' && c <= 'я');
        }

        static List<string> GetCollectionWordsWithMaxLenght(string inputText)
        {
            var allWords = new List<string>();
            var wordsWithMaxLengh = new List<string>();

            var maxLength = 0;

            foreach (var word in inputText.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                var cleanWord = RemoveSpecialCharacters(word);
                allWords.Add(cleanWord);
                if (maxLength < cleanWord.Length)
                    maxLength = cleanWord.Length;
            }


            allWords.ForEach(word =>
            {
                if (word.Length == maxLength)
                    wordsWithMaxLengh.Add(word);
            });


            return wordsWithMaxLengh;
        }

        static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new();
            foreach (char c in str)
            {
                if ((c >= 'A' && c <= 'Z') ||
                    (c >= 'a' && c <= 'z') ||
                    (c >= 'А' && c <= 'Я') ||
                    (c >= 'а' && c <= 'я') || c == '-' || c == '"')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            var text = "Lorem Ipsum - это текст-\"рыба\", часто используемый в печати\n" +
                "и вэб-дизайне. Lorem Ipsum является стандартной \"рыбой\"\n" +
                "для текстов на латинице с начала XVI века. В то время некий\n" +
                "безымянный печатник создал большую коллекцию размеров и\n" +
                "форм шрифтов, используя Lorem Ipsum для распечатки\n" +
                "образцов. Lorem Ipsum не только успешно пережил без\n" +
                "заметных изменений пять веков, но и перешагнул в\n" +
                "электронный дизайн. Его популяризации в новое время\n" +
                "послужили публикация листов Letraset с образцами Lorem\n" +
                "Ipsum в 60-х годах и, в более недавнее время, программы\n" +
                "электронной вёрстки типа Aldus PageMaker, в шаблонах\n" +
                "которых используется Lorem Ipsum.\n";

            Console.WriteLine("Исходный текст");
            Console.WriteLine(text);
            Console.WriteLine();

            Console.WriteLine(GetLineContainingWordWithMinLength(text));

            GetCollectionWordsWithMaxLenght(text).ForEach(word =>
            {
                Console.Write($"{word} ");
            });
        }
    }
}
