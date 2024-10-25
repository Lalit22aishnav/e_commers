public sealed class Logger
{
    // Lazy instance of the Logger class. It ensures thread-safety and lazy initialization.
    private static readonly Lazy<Logger> instance = new Lazy<Logger>(() => new Logger());

    private static readonly object lockObject = new object();
    private string logFilePath;

    // Private constructor to prevent external instantiation
    private Logger()
    {
        // Create a log file with a unique timestamp name
        // logFilePath = $"log_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.txt";
        logFilePath = "todayLog.txt";
    }

    // Public property to access the Singleton instance
    public static Logger Instance
    {
        get
        {
            return instance.Value;
        }
    }

    // Method to write a log message to the file
    public void Log(string message)
    {
        lock (lockObject) // Ensure thread safety when writing to the file
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }
    }
}