using System.Xml.Linq;

// Путь до файла, куда сохранятся контакты
var path = "notebook.xml";

// В списке будут храниться контакты до записи в файл
List<XElement> contacts = new List<XElement>();

// Запускается бесконечный цикл для записи контактов в файл
while (true)
{
    Console.WriteLine("Для прекращения работы введите пустую строку.");

    Console.WriteLine("Введите ФИО");
    if (!ReadString(out var fio)) break;

    Console.WriteLine("Введите улицу");
    if (!ReadString(out var street)) break;

    Console.WriteLine("Введите номер дома");
    if (!ReadString(out var housNumber)) break;

    Console.WriteLine("Введите номер квартиры");
    if (!ReadString(out var flatNumber)) break;

    Console.WriteLine("Введите мобильный телефон");
    if (!ReadString(out var mobilePhone)) break;

    Console.WriteLine("Введите домашний телефон");
    if (!ReadString(out var flatPhone)) break;

    contacts.Add(CreateNote(fio, street, housNumber, flatNumber, mobilePhone, flatPhone));
}

await SaveContacts(path, contacts);

// Создает XElement из входных параметров
XElement CreateNote(string fio, string street, string housNumber, string flatNumber, string mobilePhone, string flatPhone)
{
    return new XElement("Person",
            new XAttribute("name", fio),
            new XElement("Address",
                new XElement("Street", street),
                new XElement("HouseNumber", housNumber),
                new XElement("FlatNumber", flatNumber)
                ),
            new XElement("Phones",
                new XElement("MobilePhone", mobilePhone),
                new XElement("FlatPhone", flatPhone)
                )
           );
}

// Считывает строку и проверяет что она не пустая
bool ReadString(out string str)
{
    str = Console.ReadLine() ?? string.Empty;
    if (!string.IsNullOrWhiteSpace(str) && !string.IsNullOrEmpty(str))
        return true;

    Console.WriteLine("Пустая строка");
    return false;
}

async Task SaveContacts(string path, List<XElement> contacts)
{
    foreach (var person in contacts)
        await File.AppendAllTextAsync(path, person.ToString() + "\n");
}
