using System;

namespace ClassTime
{
    class InputDataWithCheck
    {
        static public int InputIntegerWithValidation(string s, int left, int right) // Ввод целого числа с проверкой правильности ввода, в том числе принадлежности к указанному диапазону.
        {
            bool ok;
            int a;
            do
            {
                Console.Write(s);
                ok = int.TryParse(Console.ReadLine(), out a);
                if (ok)
                    if (a < left || a > right)
                        ok = false;
                if (!ok)
                {
                    ConsoleColor tmp = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nВведенные данные имеют неверный формат или не принадлежат диапазону [{left}; {right}]");
                    Console.WriteLine("Повторите ввод\n");
                    Console.ForegroundColor = tmp;
                }
            } while (!ok);
            return a;
        }

        static public uint InputUintWithValidation(string s, uint left, uint right) // Ввод целого числа с проверкой правильности ввода, в том числе принадлежности к указанному диапазону.
        {
            bool ok;
            uint a;
            do
            {
                Console.Write(s);
                ok = uint.TryParse(Console.ReadLine(), out a);
                if (ok)
                    if (a < left || a > right)
                        ok = false;
                if (!ok)
                {
                    ConsoleColor tmp = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nВведенные данные имеют неверный формат или не принадлежат диапазону [{left}; {right}]");
                    Console.WriteLine("Повторите ввод\n");
                    Console.ForegroundColor = tmp;
                }
            } while (!ok);
            return a;
        }
    }
}