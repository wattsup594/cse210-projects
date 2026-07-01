using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        :base(
            "Breathing Activity",
            "This activity will walk you through breathing exercises, to help you relax."
        )
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe In...");
            ShowCountDown(4);
            Console.WriteLine();

            if (DateTime.Now >= endTime)
            {
                break;
            }

            Console.Write("Breathe Out...");
            ShowCountDown(6);
            Console.WriteLine();
        }
        DisplayEndingMessage();
    }
}