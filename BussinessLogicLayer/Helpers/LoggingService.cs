namespace BusnisLogicLayer.Helpers;

public static class LoggingService
{
    public static void LogError(string message)
    {
        
        WriteToFile(message, "ERROR");
    }

    public static void LogInfo(string message)
    {
        WriteToFile(message, "INFO");
    }

    public static void LogWarning(string message)
    {
       WriteToFile(message, "WARNING");
    }

    private static void WriteToFile(string message, string type)
    {
        string directory = DateTime.Now.ToString("MMMM");
        string path = $"logs\\{directory}";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        string filePath = $"{path}\\{DateTime.Now.ToString()
                                                 .Split(" ")[0]
                                                 .Replace("/", "_")}.txt";
        FileInfo fileInfo = new FileInfo(filePath);
        using (StreamWriter streamWriter = fileInfo.AppendText())
        {
            streamWriter.Write($"[{type}] : ");
            streamWriter.WriteLine(message);
            streamWriter.Close();
        }
    }
}

