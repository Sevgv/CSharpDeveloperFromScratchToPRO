namespace PracticalWork07
{
    /// <summary>
    /// Содержит методы для проверки ввода с клавиатуры для разных типов данных
    /// </summary>
    public static class InputValidation
    {
        /// <summary>
        /// Считывает строку и проверяет формат целого числа
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool ReadInt(out int number)
        {
            var str = Console.ReadLine();
            if (int.TryParse(str, out number))
                return true;

            Console.WriteLine("Неправильное число");
            return false;
        }

        /// <summary>
        /// Считывает строку и проверяет формат числа с плавающей запятой
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool ReadDouble(out double number)
        {
            Console.WriteLine("Введите число c плавающей точкой");
            var str = Console.ReadLine();
            if (double.TryParse(str, out number))
                return true;

            Console.WriteLine("Неправильное число");
            return false;
        }

        /// <summary>
        /// Считывает строку и проверяет формат даты
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool ReadDateOnly(out DateOnly date)
        {
            Console.WriteLine("Введите дату в формате dd.MM.yyyy");
            var str = Console.ReadLine();
            if (DateOnly.TryParse(str, out date))
                return true;

            Console.WriteLine("Неправильная дата");
            return false;
        }

        /// <summary>
        /// Считывает строку и проверяет формат даты и времени
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static bool ReadDateTime(out DateTime time)
        {
            Console.WriteLine("Введите время в формате dd.MM.yyyy HH:mm:ss");
            var str = Console.ReadLine();
            if (DateTime.TryParse(str, out time))
                return true;

            Console.WriteLine("Неправильное время");
            return false;
        }

        /// <summary>
        /// Считывает строку и проверяет строку что не пустая
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool ReadString(out string str)
        {
            str = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(str) && !string.IsNullOrEmpty(str))
                return true;

            Console.WriteLine("Пустая строка");
            return false;
        }
    }
}
