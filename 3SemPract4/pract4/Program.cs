using System.Globalization;

namespace pract4;

public class Program
{
    static void Main(string[] args)
    {
        Part1();
        Console.WriteLine("\nЧасть 2");
        Part2Circle();
    }

    static void Part1()
    {
        string[] months = { "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December" };

        int n;
        while (true)
        {
            Console.WriteLine("Введите длину названия месяца (целое число):\n");
            if (int.TryParse(Console.ReadLine(), out n) && n > 0) break;
            Console.WriteLine("Ошибка: введите положительное целое число!");
        }

        var lenghtNQuery = from m in months
                           where m.Length == n
                           select m;

        var lengthNExtension = months.Where(m => m.Length == n);

        Console.WriteLine("Найдены месяцы:");
        foreach (var m in lenghtNQuery)
            Console.WriteLine(m);

        var summerAndWinterQ = from m in months
                               where m == "December" || m == "January" || m == "February"
                                     || m == "June" || m == "July" || m == "August"
                               select m;

        var summerAndWinterExt = months.Where(m => m == "December" || m == "January" || m == "February"
                                                    || m == "June" || m == "July" || m == "August");

        var sortedMonthsQ = from m in months
                            orderby m
                            select m;

        var sortedMonthsExt = months.OrderBy(m => m);

        Console.WriteLine("\nМесяцы в алфавитном порядке:");
        foreach (var m in sortedMonthsQ)
            Console.WriteLine(m);

        var countQ = (from m in months
                      where m.Contains('u') && m.Length >= 4
                      select m).Count();

        var countExt = (months.Where(m => m.Contains('u') && m.Length >= 4)).Count();
        Console.WriteLine($"Количество месяцев с буквой 'u' и длиной >= 4: {countExt}");
    }

    static void Part2Circle()
    {
        List<Circle> listCircle = new List<Circle>()
    {
        new Circle(0, 0, 5), new Circle(2, 3, 4),
        new Circle(-1, 1, 6), new Circle(3, -2, 2),
        new Circle(5, 5, 3), new Circle(-3, -4, 7),
        new Circle(1, 1, 1), new Circle(2, 2, 2),
        new Circle(3, 3, 3), new Circle(4, 4, 4),
        new Circle(5, 5, 5), new Circle(6, 6, 6),
        new Circle(7, 7, 7), new Circle(-5, 4, 8),
        new Circle(0, 5, 9), new Circle(5, 0, 10),
        new Circle(-2, -2, 3.5), new Circle(1.5, 2.5, 4.5),
        new Circle(-4, 3, 2.5), new Circle(3, -3, 1.5)
    };

        double k = ReadDouble("Задайте прямую. Введите коэффициент k: ");
        double b = ReadDouble("Введите коэффициент b: ");

        var onLine = from c in listCircle
                     where Math.Abs(c.CenterY - (k * c.CenterX + b)) < 0.0001
                     select c;

        Console.WriteLine($"Окружности, центры которых лежат на прямой y = {k}x + {b}:");
        PrintResults(onLine);

        var minCircle = (from c in listCircle
                         orderby c.Perimeter
                         select c).First();

        var maxCircle = (listCircle.OrderByDescending(c => c.Perimeter)).First();

        Console.WriteLine($"\nНаименьший периметр: {minCircle.Perimeter:F3} ({minCircle})");
        Console.WriteLine($"Наибольший периметр: {maxCircle.Perimeter:F3} ({maxCircle})");

        double rad = ReadDouble("\nЗадайте радиус искомой окружности:");
        var circleDesiredRadius = from c in listCircle
                                  where Math.Abs(c.Radius - rad) < 0.0001
                                  select c;

        Console.WriteLine($"Окружности с радиусом {rad}: ");
        PrintResults(circleDesiredRadius);
        
        var inFirstQuarter = (from c in listCircle
                              where c.CenterX > 0 && c.CenterY > 0
                              select c).FirstOrDefault();

        Console.WriteLine(inFirstQuarter != null ?
            $"\nПервая окружность в первой координатной четверти: {inFirstQuarter}" :
            "\nОкружностей в первой четверти нет.");

        Console.WriteLine("Как упорядочить список (по площади окружности): 1 - по возрастанию, 0 - по убыванию: ");
        int organize;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out organize) && (organize == 0 || organize == 1))
                break;
            Console.WriteLine("Ошибка: введите либо 0, либо 1!");
        }

        var sortedCircle = organize == 1 ? listCircle.OrderBy(c => c.Area)
            : listCircle.OrderByDescending(c => c.Area);

        Console.WriteLine("Отсортированный список:");
        foreach (var c in sortedCircle)
            Console.WriteLine(c + $", Площадь = {c.Area:F3}");
    }

    static void PrintResults(IEnumerable<Circle> circles)
    {
        if (!circles.Any())
        {
            Console.WriteLine("Совпадений нет.");
            return;
        }

        foreach (var c in circles)
            Console.WriteLine(c);
    }

    static double ReadDouble(string message)
    {
        double value;
        while (true)
        {
            Console.WriteLine(message);
            if (double.TryParse(Console.ReadLine(), out value))
                return value;

            Console.WriteLine("Ошибка: введите корректное число (через запятую, если дробное)!");
        }
    }
}
