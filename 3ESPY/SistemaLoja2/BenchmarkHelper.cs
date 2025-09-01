using System.Diagnostics;

namespace LinqAdvancedLab;

public static class BenchmarkHelper
{
    public static void MedirTempo(string operacao, Action action, int execucoes = 1000)
    {
        // Warm-up
        action();
            
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < execucoes; i++)
        {
            action();
        }
        sw.Stop();
            
        Console.WriteLine($"{operacao}: {sw.ElapsedMilliseconds}ms ({execucoes} execuções)");
    }
}