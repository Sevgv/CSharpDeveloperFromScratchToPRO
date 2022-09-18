using System.Text.RegularExpressions;

var phoneBook = new Dictionary<string, string>();

var working = true;
while (working)
{
    Console.WriteLine("1 - Заполнение телефонной книжки");
    Console.WriteLine("2 - Найти пользователя по телефону");
    Console.WriteLine("0 - Выход");

    if (!ReadInt(out var key))
    {
        Console.WriteLine("Ошибка!");
        continue;
    };

    switch (key)
    {
        case 1:
            {   
                // Начинаем процесс ввода пользователей
                AddPhoneBookRecords();
                // Выводим содержимое на экран
                Print(phoneBook);
                break;
            }
        case 2:
            {
                // Получаем ФИО по номеру телефона и выводим на экран               
                Console.WriteLine(GetFIOByPhone());
                break;
            }
        case 0:
            working = false;
            break;
        default:
            working = false;
            break;
    }

    // Запускаем бесконечный  цикл для заполнения телефонной книги
    void AddPhoneBookRecords()
    {
        while (true)
        {
            string? number;
            bool endWorking = false;
            while (true)
            {
                Console.WriteLine("Введите номер телефона");
                if (!ReadString(out number))
                {
                    Console.WriteLine("Конец работы");
                    endWorking = true;
                    break;
                }

                if (IsPhoneNbr(number)) break;
                Console.WriteLine("Неверный формат телефона");
            }
            if (endWorking) break;

            Console.WriteLine("Введите ФИО");
            if (!ReadString(out string fio))
            {
                Console.WriteLine("Конец работы");
                break;
            }

            phoneBook[number] = fio;
        }
        return;
    }

    // Вывод на экран всей телефонной книги
    void Print(Dictionary<string, string> dict)
    {
        foreach (var kv in dict)
            Console.WriteLine($"{kv.Key}: {kv.Value}");
    }

    // Проверяет корректность формата номера телефона
    bool IsPhoneNbr(string number)
    {
        string motif = @"^\+\d{1}\(?\d{3}\)?[-. ]?\d{3}[-. ]?\d{2}[-. ]?\d{2}$";
        if (string.IsNullOrEmpty(number)) return false;

        return Regex.IsMatch(number, motif);
    }

    // Считывает строку и проверяет формат целого числа
    bool ReadInt(out int number)
    {
        var str = Console.ReadLine();
        if (int.TryParse(str, out number))
            return true;

        Console.WriteLine("Неправильное число");
        return false;
    }

    // Считывает строку и проверяет строку что не пустая
    bool ReadString(out string str)
    {
        str = Console.ReadLine() ?? string.Empty;
        if (!string.IsNullOrWhiteSpace(str) && !string.IsNullOrEmpty(str))
            return true;
        return false;
    }
  
    // Получает ФИО по номеру телефона
    string GetFIOByPhone()
    {
        if (!CheckPhoneBook()) return string.Empty;
        if (!CheckPhoneFormat(out var number)) return string.Empty;
               
        if (!phoneBook.TryGetValue(number, out var fio))
        {
            Console.WriteLine("Пользователь не найден");
            return string.Empty;
        }

        return fio;
    }

    // Получает телефон или пустую строку, если формат не верный
    bool CheckPhoneFormat(out string number)
    {
        Console.WriteLine("Введите номер телефона");
        if (!ReadString(out number) || !IsPhoneNbr(number))
        {
            Console.WriteLine("Неверный формат телефона");
            return false;
        }
        return true;
    }

    // Проверяем телефонную книгу
    bool CheckPhoneBook()
    {
        if (phoneBook == null || !phoneBook.Any())
        {
            Console.WriteLine("Телефонная книга пуста");
            return false;
        }
        return true;
    }
}