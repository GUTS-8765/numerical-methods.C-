using System;
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("=== Задача 1 ===");

        double a = 12.6;
        double da = 0.05;
        double b = 3.4;
        double db = 0.1;

        double sum = a + b;
        double absSum = da + db;
        double relSum = absSum / sum;

        Console.WriteLine($"a + b = {sum:F2}");
        Console.WriteLine($"Абсолютная погрешность = {absSum:F3}");
        Console.WriteLine($"Относительная погрешность = {relSum * 100:F3}%");

        double diff = a - b;
        double absDiff = da + db;
        double relDiff = absDiff / diff;

        Console.WriteLine($"a - b = {diff:F2}");
        Console.WriteLine($"Абсолютная погрешность = {absDiff:F3}");
        Console.WriteLine($"Относительная погрешность = {relDiff * 100:F3}%");

        double relA = da / a;
        double relB = db / b;

        double prod = a * b;
        double relProd = relA + relB;
        double absProd = prod * relProd;

        Console.WriteLine($"a * b = {prod:F2}");
        Console.WriteLine($"Абсолютная погрешность = {absProd:F3}");
        Console.WriteLine($"Относительная погрешность = {relProd * 100:F3}%");

        double quot = a / b;
        double relQuot = relA + relB;
        double absQuot = quot * relQuot;

        Console.WriteLine($"a / b = {quot:F3}");
        Console.WriteLine($"Абсолютная погрешность = {absQuot:F3}");
        Console.WriteLine($"Относительная погрешность = {relQuot * 100:F3}%");

        Console.WriteLine();
        Console.WriteLine("=== Задача 2 ===");

        decimal x = 4.321m;
        decimal y = 4.319m;
        decimal d = x - y;

        Console.WriteLine($"x - y = {d}");
        Console.WriteLine("Ручной ответ: 0.002");

        Console.WriteLine();
        Console.WriteLine("=== Задача 3 ===");

        double s = 0;

        for (int i = 1; i <= 1_000_000; i++)
        {
            s += 0.1;

            if (i == 10)
            {
                Console.WriteLine($"10 раз: sum = {s:F10}, разница = {s - 1.0:E6}");
            }

            if (i == 100)
            {
                Console.WriteLine($"100 раз: sum = {s:F10}, разница = {s - 10.0:E6}");
            }
        }

        Console.WriteLine($"1 000 000 раз: sum = {s:F10}, разница = {s - 100000.0:E6}");

        Console.WriteLine();
        Console.WriteLine("=== Задача 4 ===");

        double p = 0.1 + 0.2;

        Console.WriteLine($"0.1 + 0.2 = {p}");
        Console.WriteLine($"p == 0.3: {p == 0.3}");
        Console.WriteLine($"|p - 0.3| < 1e-9: {Math.Abs(p - 0.3) < 1e-9}");

        decimal pd = 0.1m + 0.2m;

        Console.WriteLine($"decimal: 0.1m + 0.2m = {pd}");
        Console.WriteLine($"decimal == 0.3m: {pd == 0.3m}");

        Console.WriteLine();
        Console.WriteLine("=== Задача 5 ===");

        double A = 1;
        double B = -50000;
        double C = 1;

        double D = B * B - 4 * A * C;
        double sq = Math.Sqrt(D);

        double x1 = (-B + sq) / (2 * A);
        double x2d = (-B - sq) / (2 * A);
        double x2v = C / x1;

        Console.WriteLine($"x1 = {x1}");
        Console.WriteLine($"x2 через дискриминант = {x2d}");
        Console.WriteLine($"x2 через c / x1 = {x2v}");
    }
}