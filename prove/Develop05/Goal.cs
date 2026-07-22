public class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public string GetShortName()
    {
        return _shortName;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    public virtual bool IsComplete()
    {
        return false;
    }

    public virtual int RecordEvent()
    {
        return _points;
    }

    public virtual string GetDetails()
    {
        return $"[ ] {_shortName} ({_description})";
    }

    public virtual string GetStringRepresentation()
    {
        return $"Goal|{_shortName}|{_description}|{_points}";
    }
}