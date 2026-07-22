public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base (name, description, points)
    {
        
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override int RecordEvent()
    {
        return GetPoints();
    }

    public override string GetDetails()
    {
        return $"[ ] {GetShortName()} ({GetDescription})";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{GetShortName()}|{GetDescription()}|{GetPoints()}";   
    }
}