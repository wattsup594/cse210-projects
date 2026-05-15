public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;
    private string _mood;



    public Entry(string date, string promptText, string entryText, string mood)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
        _mood = mood;
    }

    public override string ToString()
    {
            return
            $"\nDate: {_date}\n" +
            $"Mood: {_mood}\n" +
            $"Prompt: {_promptText}\n" +
            $"Response: {_entryText}\n";
    }

    public string ToFileString()
    {
        return $"{_date}|{_promptText}|{_entryText}|{_mood}";
    }

    public static Entry FromFileString(string line)
    {
        string[] parts = line.Split('|');

        string date = parts[0];
        string prompt = parts[1];
        string response = parts[2];
        string mood = parts [3];

        return new Entry(date, prompt, response, mood);
    }



}