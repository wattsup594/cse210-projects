using System;
using System.IO;

public class ActivityLog
{
    private string _fileName;

    public ActivityLog(string fileName)
    {
        _fileName = fileName;

        if (!File.Exists(_fileName))
        {
            File.WriteAllText(_fileName, "Mindfulness Activity Log\n");
            File.AppendAllText(_fileName, "========================\n");
        }
    }

    public void RecordActivity(string activityName, int duration)
    {
        string logEntry = $"{DateTime.Now}: Completed {activityName} for {duration} seconds";
        File.AppendAllText(_fileName, logEntry + Environment.NewLine);
    }

    public void DisplayLog()
    {
        Console.Clear();

        Console.WriteLine("Activity Log");
        Console.WriteLine("============");
        Console.WriteLine();

        if (File.Exists(_fileName))
        {
            string logText = File.ReadAllText(_fileName);
            Console.WriteLine(logText);
        }
        else
        {
            Console.WriteLine("No log file found.");
        }

        Console.WriteLine();
        Console.WriteLine("Press enter to return to the menu.");
        Console.ReadLine();
    }
}