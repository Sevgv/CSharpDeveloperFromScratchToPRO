using PracticalWork07;

var working = true;
while (working)
{
    var path = "db.csv";
    var rep = new Repository(path);

    Console.WriteLine("Выберите пункт меню:");

    Console.WriteLine("1 — Просмотр всех сотрудников;");
    Console.WriteLine("2 — Просмотр одного сотрудника по ID;");
    Console.WriteLine("3 — Создание сотрудника;");
    Console.WriteLine("4 — Редактирование сотрудника;");
    Console.WriteLine("5 — Удаление сотрудника;");
    Console.WriteLine("6 — Загрузка сотрудников в выбранном диапазоне дат;");
    Console.WriteLine("7 — Генерация запрашиваемого количества сотрудников и сохранение в файл;");
    Console.WriteLine("8 — Сортировка по полям.");
    Console.WriteLine("0 — Выход.");

    if (!InputValidation.ReadInt(out var key))
    {
        Console.WriteLine("Ошибка!");
        continue;
    };

    switch (key)
    {
        case 1:
            {
                var workers = await rep.GetAllWorkers();
                if (workers == null) break;                
                rep.Print(workers);
                break;
            }          
        case 2:
            {
                Console.WriteLine("Введите ID");
                if (!InputValidation.ReadInt(out var id)) break;
                Console.WriteLine((await rep.GetWorkerById(id))?.ToString());
                break;
            }                     
        case 3:
            {
                Console.WriteLine("Введите ФИО");
                if (!InputValidation.ReadString(out var fio)) break;

                Console.WriteLine("Введите рост");
                if (!InputValidation.ReadDouble(out var growth)) break;

                Console.WriteLine("Введите дату рождения");
                if (!InputValidation.ReadDateOnly(out var date)) break;

                Console.WriteLine("Введите город");
                if (!InputValidation.ReadString(out var city)) break;

                var worker = new Worker(fio, growth, date, city);
                await rep.AddWorker(worker);
                break;
            }           
        case 4:
            {
                Console.WriteLine("Введите ID");
                if (!InputValidation.ReadInt(out var id)) break;

                Console.WriteLine("Введите ФИО или пробел, если не хотите изменять");
                if (!InputValidation.ReadString(out var fio)) fio = string.Empty;

                Console.WriteLine("Введите рост или ноль, если не хотите изменять");
                if (!InputValidation.ReadDouble(out var growth)) growth = 0;

                Console.WriteLine("Введите дату рождения или ноль, если не хотите изменять");
                if (!InputValidation.ReadDateOnly(out var date)) date = DateOnly.MinValue;

                Console.WriteLine("Введите город или пробел, если не хотите изменять");
                if (!InputValidation.ReadString(out var city)) city = string.Empty;

                var worker = new Worker(fio, growth, date, city);
                await rep.EditWorker(id, worker);
                break;
            }
        case 5:
            {
                Console.WriteLine("Введите ID");
                if (!InputValidation.ReadInt(out var id)) break;
                await rep.DeleteWorker(id);
                break;
            }          
        case 6:
            {
                Console.WriteLine("Введите дату начала");
                if (!InputValidation.ReadDateTime(out var dateFrom)) break;
                Console.WriteLine("Введите дату конца");
                if (!InputValidation.ReadDateTime(out var dateTo)) break;

                var workers = await rep.GetWorkersBetweenTwoDates(dateFrom, dateTo);
                rep.Print(workers);
                break;
            }
        case 7:
            {
                Console.WriteLine("Введите число");
                if (!InputValidation.ReadInt(out var count)) break;
                var workers = rep.WorkersGeneration(count);
                foreach(var worker in workers)
                    await rep.AddWorker(worker);
                break;
            }
        case 8:
            {
                Console.WriteLine("Выбереите поле, по которому хотите отсортировать список:");
                Console.WriteLine("1 - ID");
                Console.WriteLine("2 - Время добавления");
                Console.WriteLine("3 - ФИО");
                Console.WriteLine("4 - Возраст");
                Console.WriteLine("5 - Рост");
                Console.WriteLine("6 - Дата рождения");
                Console.WriteLine("7 - Город");
                if (!InputValidation.ReadInt(out var keyFilter))
                {
                    Console.WriteLine("Ошибка!");
                    break;
                };
                var workers = await rep.GetAllWorkers();
                switch (keyFilter)
                {                  
                    case 1: 
                        rep.Print(workers.OrderBy(x => x.Id).ToArray());
                        break;
                    case 2:
                        rep.Print(workers.OrderBy(x => x.TimeAdding).ToArray());
                        break;
                    case 3:
                        rep.Print(workers.OrderBy(x => x.FIO).ToArray());
                        break;
                    case 4:
                        rep.Print(workers.OrderBy(x => x.Age).ToArray());
                        break;
                    case 5:
                        rep.Print(workers.OrderBy(x => x.Growth).ToArray());
                        break;
                    case 6:
                        rep.Print(workers.OrderBy(x => x.BirthdayDate).ToArray());
                        break;
                    case 7:
                        rep.Print(workers.OrderBy(x => x.City).ToArray());
                        break;
                }
                break;
            }
        case 0:
            working = false;
            break;
        default:
            working = false;
            break;
    }
}


