using System;
using System.Collections.Generic;


public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity()
        :base (
            "Reflecting Activity",
            "This activity will help you to reflect on aspects of your life using prompts and follow up questions."
        )
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
             "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("Consider The Following Prompt: ");
        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomItem(_prompts)} ---");
        Console.WriteLine();


        Console.WriteLine("When you've written something, press Enter to continue");
        Console.ReadLine();

        Console.WriteLine("Now ponder each of the following questions as they appear.");
        ShowSpinner(3);
        Console.Clear();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        List<string> availableQuestions = new List<string>(_questions);

        while (DateTime.Now < endTime)
        {
            if (availableQuestions.Count == 0)
            {
                availableQuestions = new List<string>(_questions);
            }

            string question = GetRandomItem(availableQuestions);
            availableQuestions.Remove(question);

            Console.Write($"> {question} ");
            ShowSpinner(6);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}