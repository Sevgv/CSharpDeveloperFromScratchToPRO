//Что нужно сделать
//Создайте справочник «Сотрудники».

//Разработайте для предполагаемой компании программу, которая будет добавлять записи новых сотрудников в файл. Файл должен содержать следующие данные:

//ID
//Дату и время добавления записи
//Ф. И. О.
//Возраст
//Рост
//Дату рождения
//Место рождения
//Для этого необходим ввод данных с клавиатуры. После ввода данных:

//если файла не существует, его необходимо создать;
//если файл существует, то необходимо записать данные сотрудника в конец файла. 
//При запуске программы должен быть выбор:

//введём 1 — вывести данные на экран;
//введём 2 — заполнить данные и добавить новую запись в конец файла.

//Файл должен иметь следующую структуру:

//1#20.12.2021 00:12#Иванов Иван Иванович#25#176#05.05.1992#город Москва
//2#15.12.2021 03:12#Алексеев Алексей Иванович#24#176#05.11.1980#город Томск
//…


//Советы и рекомендации
//Обратите внимание, что в строке есть символ # — разделитель в строке. При чтении файла необходимо убрать символ #.
//Разбить строку на массив элементов поможет разделение строк с помощью метода String.Split.
//Разбейте программу на методы (чтение, запись).
//Новую запись внесите в конец файла.
//Проверьте, создан файл или нет.


//Что оценивается
//Структура файла после добавления сотрудника идентична.
//Каждый метод выполняет одну задачу.
//Запись корректно выводится в консоль.
//Файл корректно закрывается после записи и чтения.

using System.Globalization;
using System.Text;

async Task<string[]> ReadFile(string path)
{
    return await File.ReadAllLinesAsync(path);
}

async void WriteLineToEndFile(string path, string line)
{
    await File.AppendAllTextAsync(path, line);
}

string BuildLine(int id, DateTime time, string fio, int age, double growth, DateOnly date, string city)
{
    return new StringBuilder($"{id}#")
        .Append($"{time}#")
        .Append($"{fio}#")
        .Append($"{age}#")
        .Append($"{growth}#")
        .Append($"{date}#")
        .Append($"{city}")
        .AppendLine().ToString();
}

void OutputAllData(string[]? lines)
{
    if (lines != null && lines.Any())
    {
        foreach (var l in lines)
        {
            foreach (var i in l.Split('#'))
                Console.Write($"{i} ");
            Console.WriteLine();
        }
    } else
    {
        Console.WriteLine("Данные отсуствуют");
    }
}

async Task<int> LastId(string path)
{
    var lines = await ReadFile(path);
    return int.Parse(lines.Last().Split('#').First());
}

Console.WriteLine("введём 1 — вывести данные на экран;");
Console.WriteLine("введём 2 — заполнить данные и добавить новую запись в конец файла.");

var path = "db.csv";

var input = Console.ReadLine();
int.TryParse(input, out var key);

switch (key)
{
    case 1:
        var lines = await ReadFile(path);
        OutputAllData(lines);
        break;
    case 2:
        Console.WriteLine("Введите ФИО");
        var fio = Console.ReadLine();
        Console.WriteLine("Введите возраст");
        var age = Console.ReadLine();
        Console.WriteLine("Введите рост");
        var growth = Console.ReadLine();
        Console.WriteLine("Введите дату рождения");
        var date = Console.ReadLine();
        Console.WriteLine("Введите город");
        var city = Console.ReadLine();

        var line = BuildLine(await LastId(path) + 1, DateTime.Now, fio, int.Parse(age), double.Parse(growth), DateOnly.Parse(date, new CultureInfo("ru-RU")), city);
        WriteLineToEndFile(path, line);
        break;
    default:
        break;
}

