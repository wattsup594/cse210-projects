using System;

public abstract class SecurityIncident
{
    private string _description;
    private int _pointValue;

    public SecurityIncident(string description, int pointValue)
    {
        _description = description;
        _pointValue = pointValue;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPointValue()
    {
        return _pointValue;
    }

    public abstract void DisplayOptions();
    public abstract bool CheckResponse(int response);
    public abstract string GetIncidentType();
    public abstract string GetExplanation();
}