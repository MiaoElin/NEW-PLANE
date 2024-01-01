using System.Numerics;
using Raylib_cs;
public static class PLog {
    public static void LogError(String msg) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(msg);
        Console.ResetColor();
    }
    public static void LogWarning(String msg) {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(msg);
        Console.ResetColor();
    }
    public static void Log(String msg) {
        Console.WriteLine(msg);
    }
}