using System;
using System.Collections.Generic;

public class GratitudeActivity : Activity
{
     private List<string> _prompts;

    public GratitudeActivity()
        : base(
            "Gratitude Activity",
            "This activity will help you focus on the things you can be grateful for in your life."
        )
    {
        _prompts = new List<string>
        {
            "Name one person you are grateful for and why.",
            "Name one blessing you noticed recently.",
            "Name one challenge that helped you grow.",
            "Name one talent or ability you are thankful for.",
            "Name one small thing that made your day better."
        };

    }

     public override void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("During this activity, write short gratitude responses.");
        Console.WriteLine("Try to include why each thing matters to you.");
        Console.WriteLine();

        ShowSpinner(3);

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        List<string> availablePrompts = new List<string>(_prompts);
        List<string> responses = new List<string>();

        while (DateTime.Now < endTime)
        {
            if (availablePrompts.Count == 0)
            {
                availablePrompts = new List<string>(_prompts);
            }

            string prompt = GetRandomItem(availablePrompts);
            availablePrompts.Remove(prompt);

            Console.WriteLine();
            Console.WriteLine(prompt);
            Console.Write("> ");

            string response = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(response))
            {
                responses.Add(response);
            }

            if (DateTime.Now < endTime)
            {
                Console.WriteLine("Take a moment to think about that gratitude.");
                ShowSpinner(4);
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You recorded {responses.Count} gratitude responses.");
        ShowSpinner(3);

        DisplayEndingMessage();
    }

}