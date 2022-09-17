namespace PracticalWork07
{
    /// <summary>
    /// Класс Repository, отвечает за работу с экземплярами Worker
    /// </summary>
    class Repository
    {
        /// <summary>
        /// Конструктор Repository с инициализацией пути файла
        /// </summary>
        /// <param name="path"></param>
        public Repository(string path) { this.path = path; }
        /// <summary>
        /// Путь файла
        /// </summary>
        private string path { get; set; } = string.Empty;

        /// <summary>
        /// Просмотр всех сотрудников
        /// </summary>
        /// <returns></returns>
        public async Task<Worker[]> GetAllWorkers()
        {
            var lines = await ReadFile();
            if (lines == null || !lines.Any())
            {
                Console.WriteLine("Данные отсуствуют");
                return Array.Empty<Worker>();
            }

            var workers = new Worker[lines.Length];
            for (var i = 0; i < lines.Length; i++)
                workers[i] = Worker.GetWorker(lines[i]);
            return workers.OrderBy(x => x.Id).ToArray();
        }

        /// <summary>
        /// Просмотр одного сотрудника по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Worker?> GetWorkerById(int id)
        {
            try
            {
                var worker = (await GetAllWorkers())?.FirstOrDefault(x => x.Id == id);
                if (worker == null) throw new Exception("Сотрудник не найден");
                return worker;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        public async Task AddWorker(Worker worker)
        {
            try
            {
                // присваиваем worker уникальный ID,
                worker.Id = await LastId() + 1;
                worker.TimeAdding = DateTime.Now;
                worker.Age = GetAgeByBirthdayDate(worker.BirthdayDate);
                // дописываем нового worker в файл
                await WriteLineToEndFile(worker.BuildLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Редактирование сотрудника
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        public async Task EditWorker(int id, Worker worker)
        {
            try
            {
                var getedWorker = await GetWorkerById(id);
                if (getedWorker == null)
                    throw new Exception("Сотрудник отсутствует");

                var editingWorker = (Worker)getedWorker;

                editingWorker.FIO = !string.IsNullOrEmpty(worker.FIO)
                    ? worker.FIO
                    : editingWorker.FIO;
                editingWorker.Age = worker.Age > 0
                    ? worker.Age
                    : editingWorker.Age;
                editingWorker.Growth = worker.Growth > 0
                    ? worker.Growth
                    : editingWorker.Growth;
                editingWorker.BirthdayDate = DateOnly.MinValue != worker.BirthdayDate
                    ? worker.BirthdayDate
                    : editingWorker.BirthdayDate;
                editingWorker.City = !string.IsNullOrEmpty(worker.City)
                    ? worker.City
                    : editingWorker.City;

                // считывается файл, находится нужный Worker
                var workers = await GetAllWorkers();

                var newWorkers = new Worker[workers.Length];
                for (var i = 0; i < newWorkers.Length; i++)
                {
                    if (workers[i].Id != id)
                        newWorkers[i] = workers[i];
                    else
                        newWorkers[i] = editingWorker;
                }

                // происходит запись в файл всех Worker,
                // кроме удаляемого
                await File.WriteAllTextAsync(path, string.Empty);
                foreach (var w in newWorkers)
                    await WriteLineToEndFile(w.BuildLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteWorker(int id)
        {
            // считывается файл, находится нужный Worker
            var workers = await GetAllWorkers();
            if (workers == null || !workers.Any()) return;

            var index = Array.IndexOf(workers, await GetWorkerById(id));

            for (var i = index; i < workers.Length - 1; i++)
                workers[i] = workers[i + 1];
            Array.Resize(ref workers, workers.Length - 1);

            // происходит запись в файл всех Worker,
            // кроме удаляемого
            await File.WriteAllTextAsync(path, string.Empty);
            foreach (var worker in workers)
                await WriteLineToEndFile(worker.BuildLine());
        }

        /// <summary>
        /// Загрузка сотрудников в выбранном диапазоне дат
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        public async Task<Worker[]> GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            // здесь происходит чтение из файла
            var workers = await GetAllWorkers();
            if (workers == null || !workers.Any()) return Array.Empty<Worker>();

            // фильтрация нужных сотрудников          
            // и возврат массива считанных экземпляров
            return workers.Where(x => x.TimeAdding >= dateFrom && x.TimeAdding <= dateTo)
                .ToArray();
        }

        /// <summary>
        /// Генерация запрашиваемого количества сотрудников
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public Worker[] WorkersGeneration(int count)
        {
            Worker[] workers = new Worker[count];
            for (var i = 0; i < workers.Length; i++)
            {
                workers[i] = Worker.GetWorker(
                    $"Name{i}",
                    new Random().Next(150, 200),
                    DateOnly.FromDateTime(DateTime.Now.AddYears(new Random().Next(-60, -18))),
                    $"City{i}");
            }
            return workers;
        }

        /// <summary>
        /// Выводит список сотрудников
        /// </summary>
        /// <param name="workers"></param>
        public void Print(Worker[] workers)
        {
            Console.WriteLine($"{"ID",-3}\t{"Время добавления",-20}\t{"ФИО",-30}\t{"Возраст",-4}\t{"Рост",-5}\t{"Дата рождения",-12}\t{"Город",-20}");
            foreach (var item in workers)
                Console.WriteLine(item.ToString());
        }

        /// <summary>
        /// Читаем все строки из файла
        /// </summary>
        /// <returns>Массив строк</returns>
        private async Task<string[]> ReadFile()
        {
            return File.Exists(path)
                ? await File.ReadAllLinesAsync(path)
                : Array.Empty<string>();
        }

        /// <summary>
        /// Записываем строку в конец файла
        /// </summary>
        /// <param name="line">Отформатированная строка</param>
        /// <returns></returns>
        private async Task WriteLineToEndFile(string line) => await File.AppendAllTextAsync(path, line);

        /// <summary>
        /// Получаем последний индекс в файле
        /// </summary>
        /// <returns></returns>
        private async Task<int> LastId()
        {
            var lines = await ReadFile();
            return lines != null && lines.Any()
                ? int.Parse(lines.Last().Split('#').First())
                : 0;
        }

        /// <summary>
        /// Получаем возраст по дате рождения
        /// </summary>
        /// <param name="birthdayDate"></param>
        /// <returns></returns>
        private int GetAgeByBirthdayDate(DateOnly birthdayDate)
        {
            var now = DateTime.Now;
            var age = DateOnly.FromDateTime(now).Year - birthdayDate.Year;
            if (birthdayDate.ToDateTime(new TimeOnly(0, 0)) > now.AddYears(-age)) age--;
            return age;
        }      
    }
}