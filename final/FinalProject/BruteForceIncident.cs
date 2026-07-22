using System;

public class BruteForceIncident : SecurityIncident
{
    private int _correctResponse;

    public BruteForceIncident(string description, int pointValue, int correctResponse)
        : base(description, pointValue)
    {
        _correctResponse = correctResponse;
    }

    public override void DisplayOptions()
    {
        Console.WriteLine("1. Ignore the login attempts");
        Console.WriteLine("2. Post the account password online");
        Console.WriteLine("3. Disable the account temporarily and investigate");
        Console.WriteLine("4. Give the account administrator privileges");
    }

     public override bool CheckResponse(int response)
    {
        return response == _correctResponse;
    }

    public override string GetIncidentType()
    {
        return "Brute-Force Incident";
    }

    public override string GetExplanation()
    {
    return "Temporarily disabling the account can stop the attack while the source of the login attempts is investigated.";
    }

}