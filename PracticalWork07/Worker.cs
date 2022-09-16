using System.Text;

namespace PracticalWork07
{
    /// <summary>
    /// Класс описывает сотрудника
    /// </summary>
    class Worker
    {
        /// <summary>
        /// Конструктор Worker из отдельных полей
        /// </summary>
        /// <param name="fio"></param>
        /// <param name="growth"></param>
        /// <param name="birthdayDate"></param>
        /// <param name="city"></param>
        public Worker(string fio, double growth, DateOnly birthdayDate, string city)
        {
            FIO = fio;
            Growth = growth;
            BirthdayDate = birthdayDate;
            City = city;
        }

        /// <summary>
        /// Конструктор Worker из строки
        /// </summary>
        /// <param name="worker"></param>
        public Worker(string worker)
        {
            var slices = worker.Split('#');
            try
            {
                Id = int.TryParse(slices[0], out var id) ? id : throw new FormatException();
                TimeAdding = DateTime.TryParse(slices[1], out var timeAdding) ? timeAdding : throw new FormatException();
                FIO = !string.IsNullOrEmpty(slices[2]) ? slices[2] : throw new FormatException();
                Age = int.TryParse(slices[3], out var age) ? age : throw new FormatException();
                Growth = double.TryParse(slices[4], out var growth) ? growth : throw new FormatException();
                BirthdayDate = DateOnly.TryParse(slices[5], out var birthdayDate) ? birthdayDate : throw new FormatException();
                City = !string.IsNullOrEmpty(slices[6]) ? slices[6] : throw new FormatException();
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Неверный формат данных");
                Console.WriteLine(fe.Message);
            }
        }

        /// <summary>
        /// Получает строку нужного формата
        /// </summary>
        /// <returns>Строка для записи в файл</returns>
        public override string ToString()
        {
            return new StringBuilder($"{Id, -3}\t")
                .Append($"{TimeAdding, -20}\t")
                .Append($"{FIO, -30}\t")
                .Append($"{Age, -4}\t")
                .Append($"{Growth, -5}\t")
                .Append($"{BirthdayDate, -12}\t")
                .Append($"{City, -20}")
                .ToString();
        }

        /// <summary>
        /// Получает строку нужного формата
        /// </summary>
        /// <returns>Строка для записи в файл</returns>
        public string BuildLine()
        {
            return new StringBuilder($"{Id}#")
                .Append($"{TimeAdding}#")
                .Append($"{FIO}#")
                .Append($"{Age}#")
                .Append($"{Growth}#")
                .Append($"{BirthdayDate}#")
                .Append($"{City}")
                .AppendLine().ToString();
        }
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime TimeAdding { get; set; }
        /// <summary>
        /// Ф.И.О.
        /// </summary>
        public string FIO { get; set; } = string.Empty;
        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Рост
        /// </summary>
        public double Growth { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateOnly BirthdayDate { get; set; }
        /// <summary>
        /// Место рождения
        /// </summary>
        public string City { get; set; } = string.Empty;
    }
}
