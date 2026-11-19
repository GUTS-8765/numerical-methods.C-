using System;
using System.Diagnostics;
using System.Text;

class Program
{
    

    static string ConcatReport(int lines)
    {
        string report = "";
        for (int i = 0; i < lines; i++)
            report = report + "строка " + i + ": заказ обработан" + Environment.NewLine;
        return report;
    }

    static string BuilderReport(int lines)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < lines; i++)
            sb.AppendLine("строка " + i + ": заказ обработан");
        return sb.ToString();
    }

    static double Measure(Func<int, string> method, int n)
    {
        
        method(n);
        method(n);

        double best = double.MaxValue;
        for (int run = 0; run < 5; run++)
        {
            var sw = Stopwatch.StartNew();
            method(n);
            sw.Stop();

            if (sw.Elapsed.TotalMilliseconds < best)
                best = sw.Elapsed.TotalMilliseconds;
        }
        return best;
    }

    static void RunPerformanceTest()
    {
        Console.WriteLine("=== ЧАСТЬ 1. ЗАМЕР СКЛЕЙКИ СТРОК ===");
        Console.WriteLine("Строк\tСклейка, мс\tStringBuilder, мс\tРост склейки\tРост SB");

        int[] sizes = { 10_000, 20_000, 40_000 };
        double prevConcat = 0;
        double prevBuilder = 0;

        foreach (int n in sizes)
        {
            double concat = Measure(ConcatReport, n);
            double builder = Measure(BuilderReport, n);

            double concatGrowth = prevConcat > 0 ? concat / prevConcat : 0;
            double builderGrowth = prevBuilder > 0 ? builder / prevBuilder : 0;

            Console.WriteLine($"{n}\t{concat:F1}\t\t{builder:F1}\t\t{concatGrowth:F2}\t\t{builderGrowth:F2}");

            prevConcat = concat;
            prevBuilder = builder;
        }

        Console.WriteLine();
        Console.WriteLine("Вывод: при удвоении данных склейка строкой замедляется примерно в 4 раза —");
        Console.WriteLine("квадратичный рост O(n²); StringBuilder растёт примерно в 2 раза — линейный O(n).");
        Console.WriteLine();
    }

    
    static decimal CalcDelivery(double weight)
    {
        const decimal baseTariff = 250m;   
        const decimal pricePerKg = 10m;

        decimal total = baseTariff + (decimal)weight * pricePerKg;

        if (weight > 20)
            total *= 0.95m;   

        return total;
    }

    static void Check(string name, decimal expected, decimal actual)
    {
        if (expected == actual)
            Console.WriteLine($"OK: {name}");
        else
            Console.WriteLine($"FAIL: {name}; ожидалось {expected}, получено {actual}");
    }

    static void RunRegressionTest()
    {
        Console.WriteLine("=== ЧАСТЬ 2. РЕГРЕССИЯ CalcDelivery ===");
        Console.WriteLine("--- Старый проверщик (не меняем) ---");

        
        Check("вес 0 — старый базовый тариф", 200m, CalcDelivery(0));
        Check("вес 3 — без скидки", 230m, CalcDelivery(3));
        Check("вес 10 — без скидки", 300m, CalcDelivery(10));
        Check("вес 20 — граница без скидки", 400m, CalcDelivery(20));
        Check("вес 25 — без скидки, старое поведение", 450m, CalcDelivery(25));

        Console.WriteLine();
        Console.WriteLine("--- Обновлённый проверщик (новый тариф + скидка) ---");

       
        Check("вес 0 — новый базовый тариф", 250m, CalcDelivery(0));
        Check("вес 3 — без скидки", 280m, CalcDelivery(3));
        Check("вес 10 — без скидки", 350m, CalcDelivery(10));
        Check("вес 20 — граница, скидки нет", 450m, CalcDelivery(20));

        
        Check("вес 25 — скидка 5% применена", 475m, CalcDelivery(25));
        Check("вес 3 — скидки нет", 280m, CalcDelivery(3));
        Check("вес 20 — граница, скидки нет", 450m, CalcDelivery(20));

        
        Check("вес 21 — скидка 5% применена", 437m, CalcDelivery(21));
    }

    

    static void Main()
    {
        RunPerformanceTest();
        RunRegressionTest();
    }
}