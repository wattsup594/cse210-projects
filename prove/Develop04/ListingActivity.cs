using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;

    public ListingActivity()
        :base( 
            "Listing Activity",
            "This activity will help you to list the good things that are in your life."
        )
    {
        _prompts = new List<string>
        {
              "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }   

    public override void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("List as many responses as you can to the following prompt: ");
        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomItem(_prompts)} ---");
        Console.WriteLine();

        Console.WriteLine("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        List<string> responses = new List<string>();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(response))
            {
                responses.Add(response);
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {responses.Count} items.");
        ShowSpinner(3);

        DisplayEndingMessage();

    } 
}