using System;
using System.Collections.Generic;
using System.IO;


public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    private PromptGenerator _promptGenerator = new PromptGenerator();


    public void AddEntry()
    {
        string prompt = _promptGenerator.GetRandomPrompt();

        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("> ");

        string response = Console.ReadLine();

        Console.Write("Mood Today: ");
        string mood = Console.ReadLine();

        string date = DateTime.Now.ToShortDateString();

        Entry entry = new Entry(date, prompt, response, mood);

        _entries.Add(entry);

        Console.WriteLine("Entry Added");
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No Entries Found");
            return;
        }

        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry.ToString());
        }
    }

    public void SaveToFile(string filename)
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);

        using (StreamWriter outputFile = new StreamWriter(path, false))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.ToFileString());
            }
        }

        Console.WriteLine($"Journal Saved To: {path}");
    }

    public void LoadFromFile(string filename)
    {

        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);

        if (!File.Exists(path))
        {
            Console.WriteLine("File Not Found");
            return;
        }


        _entries.Clear();

        string[] lines = File.ReadAllLines(path);

        foreach (string line in lines)
        {
            Entry entry = Entry.FromFileString(line);

            _entries.Add(entry);
        }

        Console.WriteLine("Journal Loaded");
    }
}