using System;
using System.Collections.Generic;

public class IncidentManager
{
    private List<SecurityIncident> _incidents;
    private List<ResponseResult> _results;
    private SecurityAnalyst _analyst;

    public IncidentManager()
    {
        _incidents = new List<SecurityIncident>();
        _results = new List<ResponseResult>();
        _analyst = new SecurityAnalyst("Unknown");

        CreateIncidents();
    }

    private void CreateIncidents()
    {
        PhishingIncident phishingIncident = new PhishingIncident(
            "An employee entered their password into a suspicious login page.",
            100,
            2
        );

        MalwareIncident malwareIncident = new MalwareIncident(
            "An employee reports that their computer is opening unknown programs and running very slowly.",
            100,
            3
        );

        BruteForceIncident bruteForceIncident = new BruteForceIncident(
            "The login system reports hundreds of failed login attempts against an administrator account.",
            100,
            3
        );

        _incidents.Add(phishingIncident);
        _incidents.Add(malwareIncident);
        _incidents.Add(bruteForceIncident);
    }

    public void Run()
    {
        DisplayWelcome();

        Console.Write("Enter your analyst name: ");
        string name = Console.ReadLine() ?? "Unknown Analyst";

        _analyst = new SecurityAnalyst(name);

        Console.WriteLine();
        Console.WriteLine($"Welcome, {_analyst.GetName()}!");
        Console.WriteLine("You will respond to three cybersecurity incidents.");
        Console.WriteLine();

        foreach (SecurityIncident incident in _incidents)
        {
            RunIncident(incident);
        }

        PerformanceReport report = new PerformanceReport();
        report.DisplayReport(_analyst, _results);
    }

    private void DisplayWelcome()
    {
        Console.WriteLine("==================================");
        Console.WriteLine(" CYBERSECURITY INCIDENT SIMULATOR");
        Console.WriteLine("==================================");
        Console.WriteLine();
    }

    private void RunIncident(SecurityIncident incident)
    {
        Console.WriteLine("----------------------------------");
        Console.WriteLine(incident.GetIncidentType());
        Console.WriteLine("----------------------------------");

        Console.WriteLine(incident.GetDescription());
        Console.WriteLine();

        incident.DisplayOptions();

        int response = GetValidResponse();

        bool wasCorrect = incident.CheckResponse(response);
        int pointsEarned = 0;

        Console.WriteLine();

        if (wasCorrect)
        {
            pointsEarned = incident.GetPointValue();
            _analyst.AddPoints(pointsEarned);

            Console.WriteLine("Correct response!");
            Console.WriteLine($"You earned {pointsEarned} points.");
        }
        else
        {
            Console.WriteLine("Incorrect response.");
            Console.WriteLine("You earned 0 points.");
        }

        Console.WriteLine();
        Console.WriteLine($"Explanation: {incident.GetExplanation()}");
        Console.WriteLine();

        ResponseResult result = new ResponseResult(
            incident.GetIncidentType(),
            wasCorrect,
            pointsEarned,
            incident.GetExplanation()
        );

        _results.Add(result);
    }

    private int GetValidResponse()
    {
        int response;
        bool validResponse = false;

        do
        {
            Console.Write("Enter your response (1-4): ");
            string input = Console.ReadLine() ?? "";

            bool isNumber = int.TryParse(input, out response);

            if (isNumber && response >= 1 && response <= 4)
            {
                validResponse = true;
            }
            else
            {
                Console.WriteLine("Please enter a number from 1 through 4.");
            }

        } while (!validResponse);

        return response;
    }
}