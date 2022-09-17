using System.Drawing;
using System.Text;

namespace PracticalWork07
{
    /// <summary>
    /// Класс описывает сотрудника
    /// </summary>
    struct Worker
    {
        public Worker(int id, DateTime timeAdding, string fio, int age, double growth, DateOnly birthdayDate, string city)
        {
            Id = id;
            TimeAdding = timeAdding;
            FIO = fio;
            Age = age;
            Growth = growth;
            BirthdayDate = birthdayDate;
            City = city;
        }

        public override bool Equals(object? obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Worker worker = (Worker)obj;
                return (Id == worker.Id);
            }
        }

        public override int GetHashCode() => Id;

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
        /// Получает Worker из отдельных полей
        /// </summary>
        /// <param name="fio"></param>
        /// <param name="growth"></param>
        /// <param name="birthdayDate"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        public static Worker GetWorker(string fio, double growth, DateOnly birthdayDate, string city)
        {
            return new Worker
            {
                FIO = fio,
                Growth = growth,
                BirthdayDate = birthdayDate,
                City = city
            };          
        }

        /// <summary>
        /// Получает Worker из строки
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        public static Worker GetWorker(string worker)
        {
            var slices = worker.Split('#');
            try
            {
                return new Worker
                {
                    Id = int.TryParse(slices[0], out var id) ? id : throw new FormatException(),
                    TimeAdding = DateTime.TryParse(slices[1], out var timeAdding) ? timeAdding : throw new FormatException(),
                    FIO = !string.IsNullOrEmpty(slices[2]) ? slices[2] : throw new FormatException(),
                    Age = int.TryParse(slices[3], out var age) ? age : throw new FormatException(),
                    Growth = double.TryParse(slices[4], out var growth) ? growth : throw new FormatException(),
                    BirthdayDate = DateOnly.TryParse(slices[5], out var birthdayDate) ? birthdayDate : throw new FormatException(),
                    City = !string.IsNullOrEmpty(slices[6]) ? slices[6] : throw new FormatException()
                };
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Неверный формат данных");
                Console.WriteLine(fe.Message);
                return new Worker();
            }
        }

        /// <summary>
        /// Получает строку нужного формата
        /// </summary>
        /// <returns>Строка для записи в файл</returns>
        public string BuildLine() => 
            string.Join("#", Id, TimeAdding, FIO, Age, Growth, BirthdayDate, City) + "\n";

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
