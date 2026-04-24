using System;

namespace MixedLangDemo.Utils;

public static class Logger
{
    public static void Info(string message) => Write("INFO", message);
    public static void Warn(string message) => Write("WARN", message);
    public static void Error(string message) => Write("ERROR", message);

    private static void Write(string level, string message)
    {
        Console.WriteLine($"[{DateTime.UtcNow:O}] [{level}] {message}");
    }
}
