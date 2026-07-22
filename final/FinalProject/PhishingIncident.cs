using System;

public class PhishingIncident : SecurityIncident
{
    private int _correctResponse;

    public PhishingIncident(string description, int pointValue, int correctResponse)
        : base(description, pointValue)
    {
        _correctResponse = correctResponse;
    }

    public override void DisplayOptions()
    {
        Console.WriteLine("1. Ignore the report");
        Console.WriteLine("2. Reset the employee's password and investigate");
        Console.WriteLine("3. Delete the employee's account");
        Console.WriteLine("4. Shut down the entire company network");
    }

    public override bool CheckResponse(int response)
    {
        return response == _correctResponse;
    }

    public override string GetIncidentType()
    {
        return "Phishing Incident";
    }

    public override string GetExplanation()
    {
        return "The employee's password should be reset because it may have been stolen. The suspicious message should also be investigated.";
    }
}