public class ChecklistGoal : Goal
{
    private int _amountComplete;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base (name, description, points)
    {
        _amountComplete = 0;
        _target = target;
        _bonus = bonus;
    }

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountComplete)
        : base(name, description, points)
    {
        _amountComplete = amountComplete;
        _target = target;
        _bonus = bonus;
    }

    public override bool IsComplete()
    {
        return _amountComplete >= _target;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0;
        }

        _amountComplete++;

        int pointsEarned = GetPoints();

        if (_amountComplete == _target)
        {
            pointsEarned += _bonus;
        }

        return pointsEarned;
    }

    public override string GetDetails()
    {
        string checkbox = "[ ]";

        if (IsComplete())
        {
            checkbox = "[X]";
        }

        return $"{checkbox} {GetShortName()} ({GetDescription()})" + $"-- Currently Completed: {_amountComplete}/{_target}";

    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{GetShortName()}|{GetDescription()}|" + $"{GetPoints()}|{_target}|{_bonus}|{_amountComplete}";
    }
}