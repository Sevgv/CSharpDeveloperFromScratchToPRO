HashSet<int> collection = new HashSet<int>();

while (true)
{
    Console.WriteLine("Введите число");
    if (!ReadInt(out var number)) break;

    if (collection.Add(number)) 
        Console.WriteLine("Число успешно сохранено");
    else
        Console.WriteLine("Такое число уже присутствует в коллекции");
}

foreach(var item in collection)
    Console.Write($"{item} ");


// Считывает строку и проверяет формат целого числа
bool ReadInt(out int number)
{
    var str = Console.ReadLine();
    if (int.TryParse(str, out number))
        return true;

    Console.WriteLine("Неправильное число");
    return false;
}
