using System.Collections.Generic;

public class BruteForceIncident : SecurityIncident
{
    public BruteForceIncident(
        string description,
        int pointValue,
        List<string> options,
        int correctResponse,
        string explanation)
        : base(
            description,
            pointValue,
            options,
            correctResponse,
            explanation)
    {
    }

    public override string GetIncidentType()
    {
        return "Brute-Force Incident";
    }
}