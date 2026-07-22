using System;
using System.Collections.Generic;

public class PerformanceReport
{
    public string DetermineRank(int score)
    {
        if (score >= 300)
        {
            return "Senior Security Analyst";
        }
        else if (score >= 200)
        {
            return "Security Analyst";
        }
        else if (score >= 100)
        {
            return "Junior Security Analyst";
        }
        else
        {
            return "Security Trainee";
        }
    }

    public void DisplayReport(
        SecurityAnalyst analyst,
        List<ResponseResult> results)
    {
        Console.WriteLine();
        Console.WriteLine("==================================");
        Console.WriteLine("       FINAL PERFORMANCE REPORT");
        Console.WriteLine("==================================");

        Console.WriteLine($"Analyst: {analyst.GetName()}");
        Console.WriteLine($"Final Score: {analyst.GetScore()}");
        Console.WriteLine($"Rank: {DetermineRank(analyst.GetScore())}");

        Console.WriteLine();
        Console.WriteLine("Incident Results:");

        foreach (ResponseResult result in results)
        {
            Console.WriteLine(result.GetSummary());
        }

        Console.WriteLine("==================================");
    }
}