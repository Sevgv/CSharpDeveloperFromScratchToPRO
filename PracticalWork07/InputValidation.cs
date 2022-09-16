namespace PracticalWork07
{
    public static class InputValidation
    {
        public static bool ReadInt(out int number)
        {
            var str = Console.ReadLine();
            if (int.TryParse(str, out number))
                return true;

            Console.WriteLine("Неправильное число");
            return false;
        }

        public static bool ReadDouble(out double number)
        {
            Console.WriteLine("Введите число c плавающей точкой");
            var str = Console.ReadLine();
            if (double.TryParse(str, out number))
                return true;

            Console.WriteLine("Неправильное число");
            return false;
        }

        public static bool ReadDateOnly(out DateOnly date)
        {
            Console.WriteLine("Введите дату в формате dd.MM.yyyy");
            var str = Console.ReadLine();
            if (DateOnly.TryParse(str, out date))
                return true;

            Console.WriteLine("Неправильная дата");
            return false;
        }

        public static bool ReadDateTime(out DateTime time)
        {
            Console.WriteLine("Введите время в формате dd.MM.yyyy HH:mm:ss");
            var str = Console.ReadLine();
            if (DateTime.TryParse(str, out time))
                return true;

            Console.WriteLine("Неправильное время");
            return false;
        }

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
