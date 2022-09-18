// Созадаем и заполняем список случайными номерами
var numbers = FillListInt();

// Вывводим содержимое списка на экран
Console.WriteLine("Список: ");
Print(numbers);
Console.WriteLine();

//Удаляем из списка все номер, которые больше 25 и меньше 50
RemoveNumbersGreater25AndLess50(ref numbers);
Console.WriteLine("Новый список: ");
Print(numbers);


List<int> FillListInt()
{
    var list = new List<int>();
    var random = new Random();
    for (var i = 0; i < 100; i++)
        list.Add(random.Next(1, 100));

    return list;
}

void Print(List<int> numbers)
{
    foreach (var i in numbers)
        Console.Write($"{i} ");
}

void RemoveNumbersGreater25AndLess50(ref List<int> numbers) =>
    numbers = numbers.Where(i => i < 25 || i > 50).ToList();

