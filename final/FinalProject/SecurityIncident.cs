using System;
using System.Collections.Generic;

public abstract class SecurityIncident
{
    private string _description;
    private int _pointValue;
    private List<string> _options;
    private int _correctResponse;
    private string _explanation;

    public SecurityIncident(
        string description,
        int pointValue,
        List<string> options,
        int correctResponse,
        string explanation)
    {
        _description = description;
        _pointValue = pointValue;
        _options = options;
        _correctResponse = correctResponse;
        _explanation = explanation;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPointValue()
    {
        return _pointValue;
    }

    public string GetExplanation()
    {
        return _explanation;
    }

    public void DisplayOptions()
    {
        for (int i = 0; i < _options.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_options[i]}");
        }
    }

    public bool CheckResponse(int response)
    {
        return response == _correctResponse;
    }

    public abstract string GetIncidentType();
}