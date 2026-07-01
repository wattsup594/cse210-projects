using System;
using System.Collections.Generic;
using System.Threading;


public abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    private static Random _random = new Random();

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    public abstract void Run();

    public string GetName()
    {
        return _name;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();

        Console.WriteLine($"Welcome to the {_name}");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        bool validDuration = false;

        while (!validDuration)
        {
            Console.Write("How long in seconds would you like for your session?");
            string input = Console.ReadLine();

            if (int.TryParse(input, out _duration) && _duration > 0)
            {
                validDuration = true;
            }
            else
            {
                Console.WriteLine("Write A Positive Number");
            }
        }
        Console.Clear();

        Console.WriteLine("Get Ready...");
        ShowSpinner(3);
        Console.WriteLine();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Great Job!");
        ShowSpinner(3);

        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        List<string> animationStrings = new List<string>
        {
            "|",
            "/",
            "-",
            "\\"
        };

        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        int i = 0;

        while (DateTime.Now < endTime)
        {
            string symbol = animationStrings[i];

            Console.Write(symbol);
            Thread.Sleep(250);
            Console.Write("\b \b");

            i++;

            if (i >= animationStrings.Count)
            {
                i=0;
            }
        }
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            string number = i.ToString();
            
            Console.Write(number);
            Thread.Sleep(1000);

            for (int j = 0; j < number.Length; j++)
            {
                Console.Write("\b \b");
            }
        }
    }

    protected string GetRandomItem(List<string> items)
    {
        int index = _random.Next(items.Count);
        return items[index];
    }
}