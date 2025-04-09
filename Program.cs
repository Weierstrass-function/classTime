namespace ClassTime
{
    class Program
    {
        static void Main()
        {
            // Получение объекта демонстрации методов
            Time? time = GetTime();
            if (time is null)
            { return; }

            Console.Clear();
            while (true)
            {
                Console.WriteLine($"Объект: {time}");
                Console.WriteLine("Нажмите клавишу для выполнения действия:");
                Console.WriteLine("[1] Обнулить часы и минуты");
                Console.WriteLine("[2] Обнулить минуты");
                Console.WriteLine("[3] Кол-во часов");
                Console.WriteLine("[4] Часы и минуты не равны нулю?");
                Console.WriteLine("[5] Сравнить");
                Console.WriteLine("[6] Вычесть минуты");
                Console.WriteLine("[Esc] - Выход");

                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                Console.Clear();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.Escape:
                        Console.WriteLine("Выход из программы...");
                        return;
                    case ConsoleKey.D1:
                        time = -time;
                        break;
                    case ConsoleKey.D2:
                        time--;
                        break;
                    case ConsoleKey.D3:
                        byte byteInterpr = time;
                        Console.WriteLine(byteInterpr.ToString());
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine($"Часы и минуты не равны нулю: {(bool)time}");
                        break;
                    case ConsoleKey.D5:
                        Time? timeToCompare = GetTime();
                        if (timeToCompare is null)
                        { return; }

                        Console.Clear();
                        Console.WriteLine("[1] ==");
                        Console.WriteLine("[2] !=");
                        switch (Console.ReadKey(intercept: true).Key)
                        {
                            case ConsoleKey.D1:
                                Console.Write($"{time} == {timeToCompare} = ");
                                Console.WriteLine(time == timeToCompare);
                                break;
                            case ConsoleKey.D2:
                                Console.Write($"{time} != {timeToCompare} = ");
                                Console.WriteLine(time != timeToCompare);
                                break;
                        }
                        break;
                    case ConsoleKey.D6:
                        time -= InputDataWithCheck.InputUintWithValidation($"{time} - ", uint.MinValue, uint.MaxValue);
                        break;
                    default:
                        ConsoleColor tmp = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неизвестная команда. Пожалуйста, попробуйте снова.");
                        Console.ForegroundColor = tmp;
                        break;
                }
            }
        }

        private static Time? GetTime()
        {
            while (true)
            {
                Console.WriteLine("Нажмите клавишу для выполнения действия:");
                Console.WriteLine("[1] Ввод с клавиатуры");
                Console.WriteLine("[R] Случайная генерация");
                Console.WriteLine("[Esc] Выход");

                switch (Console.ReadKey(intercept: true).Key)
                {
                    case ConsoleKey.Escape:
                        Console.WriteLine("Выход из программы...");
                        return null;
                    case ConsoleKey.D1:
                        Console.Clear();
                        int hours = InputDataWithCheck.InputIntegerWithValidation("Введите часы [0-23] >> ", 0, 23);
                        int minutes = InputDataWithCheck.InputIntegerWithValidation("Введите минуты [0-59] >> ", 0, 59);
                        return new Time(hours, minutes);
                    case ConsoleKey.R:
                        return new(Rand.random.Next(), (Rand.random.Next()));
                    default:
                        ConsoleColor tmp = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неизвестная команда. Пожалуйста, попробуйте снова.");
                        Console.ForegroundColor = tmp;
                        break;
                }
            }
        }
    }
}
