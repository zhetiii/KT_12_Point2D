using System;

namespace KT_12_Point2D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Контрольная точка 12: Точка на плоскости ");
            Console.WriteLine();

            Point2D userPoint = default;
            bool isCreated = false;

            while (!isCreated)
            {
                try
                {
                    Console.Write("--------Введите координату X (целое число, не 0):--------");
                    int x = int.Parse(Console.ReadLine()!);

                    Console.Write("Введите координату Y (целое число, не 0): ");
                    int y = int.Parse(Console.ReadLine()!);

                    userPoint = new Point2D(x, y);
                    isCreated = true;

                    Console.WriteLine("\n[Успешно создана точка]");
                    Console.WriteLine(userPoint);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка ввода: Введено не корректное целое число! Попробуйте снова.\n");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Ошибка валидации: {ex.Message}\n");
                }
            }

            Console.WriteLine("\n=== Демонстрация копирования структуры (Value Type) ===");
            Point2D originalPoint = userPoint;
            Point2D copyPoint = originalPoint;

            Console.WriteLine($"Оригинал до изменений: {originalPoint}");

            copyPoint.X = -originalPoint.X;
            copyPoint.Y = -originalPoint.Y;

            Console.WriteLine($"Измененная копия:       {copyPoint}");
            Console.WriteLine($"Оригинал после:         {originalPoint} (Оригинал не изменился!)");

            Console.WriteLine("\n Демонстрация Enum.TryParse ");

            string validString = "First";
            if (Enum.TryParse<Quadrant>(validString, out var parsedQuadrant))
            {
                Console.WriteLine($"Разбор корректной строки '{validString}': Успешно -> {parsedQuadrant}");
            }

            string invalidString = "Fifth";
            if (!Enum.TryParse<Quadrant>(invalidString, out _))
            {
                Console.WriteLine($"Разбор некорректной строки '{invalidString}': Не распознано (вернуло false, исключение не выброшено)");
            }
        }
    }
}