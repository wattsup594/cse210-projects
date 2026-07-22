using System.Collections.Generic;

public class PhishingIncident : SecurityIncident
{
    public PhishingIncident(
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
        return "Phishing Incident";
    }
}