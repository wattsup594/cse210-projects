using System;
using System.Collections.Generic;

public class PerformanceReport
{
    public string DetermineRank(int score, int maximumScore)
    {
        double percentage =
            (double)score / maximumScore * 100;

        if (percentage >= 90)
        {
            return "Senior Security Analyst";
        }
        else if (percentage >= 75)
        {
            return "Security Analyst";
        }
        else if (percentage >= 50)
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
        List<ResponseResult> results,
        int maximumScore)
    {
        double percentage =
            (double)analyst.GetScore() / maximumScore * 100;

        Console.WriteLine();
        Console.WriteLine("======================================");
        Console.WriteLine("       FINAL PERFORMANCE REPORT");
        Console.WriteLine("======================================");

        Console.WriteLine($"Analyst: {analyst.GetName()}");
        Console.WriteLine(
            $"Final Score: {analyst.GetScore()} / {maximumScore}");
        Console.WriteLine(
            $"Percentage: {percentage:F1}%");
        Console.WriteLine(
            $"Rank: {DetermineRank(analyst.GetScore(), maximumScore)}");

        Console.WriteLine();
        Console.WriteLine("Incident Results:");

        foreach (ResponseResult result in results)
        {
            Console.WriteLine(result.GetSummary());
        }

        Console.WriteLine("======================================");
    }
}