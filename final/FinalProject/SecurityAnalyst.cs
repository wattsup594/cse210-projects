using System;

public class SecurityAnalyst
{
    private string _name;
    private int _score;

    public SecurityAnalyst(string name)
    {
        _name = name;
        _score = 0;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetScore()
    {
        return _score;
    }

    public void AddPoints(int points)
    {
        _score += points;
    }

    public void RemovePoints(int points)
    {
        _score -= points;

        if (_score < 0)
        {
            _score = 0;
        }
    }

    public void DisplayStatus()
    {
        Console.WriteLine($"Analyst: {_name}");
        Console.WriteLine($"Current Score: {_score}");

    }
}