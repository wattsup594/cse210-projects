public class ResponseResult
{
    private string _incidentType;
    private bool _wasCorrect;
    private int _pointsEarned;
    private string _explanation;

    public ResponseResult(
        string incidentType,
        bool wasCorrect,
        int pointsEarned,
        string explanation)
    {
        _incidentType = incidentType;
        _wasCorrect = wasCorrect;
        _pointsEarned = pointsEarned;
        _explanation = explanation;
    }

    public string GetIncidentType()
    {
        return _incidentType;
    }

    public bool GetWasCorrect()
    {
        return _wasCorrect;
    }

    public int GetPointsEarned()
    {
        return _pointsEarned;
    }

    public string GetExplanation()
    {
        return _explanation;
    }

    public string GetSummary()
    {
        string result;

        if (_wasCorrect)
        {
            result = "Correct";
        }
        else
        {
            result = "Incorrect";
        }

        return $"{_incidentType}: {result} - {_pointsEarned} points";
    }
}