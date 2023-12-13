// See https://aka.ms/new-console-template for more information

class Program
{
    private delegate void LogDel(string text);
    private static void Main(string[] args)
    {
        var log = new Log();
        
        
        
        var logDel = new LogDel(log.LogTextToScreen);
        
        Console.WriteLine("Please enter your name: ");
        var name = Console.ReadLine();
        // logDel.Invoke(name!);

        var logText = new LogDel(log.LogTextToFile);
        // logText.Invoke(name!);

        var multiLogDel = logDel + logText;
        // multiLogDel(name!); 
        LogText(logText, name!);
    }

    static void LogText(LogDel logDel, string text)
    {
        logDel(text);
    }

   
}

public class Log
{
    public void LogTextToScreen(string text)
    {
        Console.WriteLine($"{DateTime.Now}: {text}");
    }


    public void LogTextToFile(string text)
    {
        using var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true);
        sw.WriteLine($"{DateTime.Now}: {text}");
    }
}