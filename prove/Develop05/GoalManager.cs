using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine();
            DisplayPlayerInfo();

            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("   1. Create New Goal");
            Console.WriteLine("   2. List Goals");
            Console.WriteLine("   3. Save Goals");
            Console.WriteLine("   4. Load Goals");
            Console.WriteLine("   5. Record Event");
            Console.WriteLine("   6. Quit");

            int choice = ReadInt("Select a choice from the menu: ");

            if (choice == 1)
            {
                CreateGoal();
            }
            else if (choice == 2)
            {
                ListGoalDetails();
            }
            else if (choice == 3)
            {
                SaveGoals();
            }
            else if (choice == 4)
            {
                LoadGoals();
            }
            else if (choice == 5)
            {
                RecordEvent();
            }
            else if (choice == 6)
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Please enter a number 1-6");
            }
        }

        Console.WriteLine("Until Next Time!!");
    }

    public void DisplayPlayerInfo()
    {
        int level = CalculateLevel();

        Console.WriteLine($"You have {_score} points");
        Console.WriteLine($"You are currently level {level}");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You haven't created any goals.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine();
        Console.WriteLine("The Goals Are: ");

        if (_goals.Count == 0)
        {
            Console.WriteLine("You haven't created any goals");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetails()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine();
        Console.WriteLine("The types of goals are: ");
        Console.WriteLine("   1. Simple Goal");
        Console.WriteLine("   2. Eternal Goal");
        Console.WriteLine("   3. Checklist Goal");

        int goalType = ReadInt("Which type of goal would you like to create?");

        if (goalType < 1 || goalType > 3)
        {
            Console.WriteLine("Choose a number between 1 and 3");
            return;
        }

        Console.WriteLine("What is the name of your goal?");
        string name = Console.ReadLine();

        Console.WriteLine("What is a short description of it?");
        string description = Console.ReadLine();

        int points = ReadInt("How many points is the goal worth?");

        Goal newGoal;

        if (goalType == 1)
        {
            newGoal = new SimpleGoal(name, description, points);
        }
        else if (goalType == 2)
        {
            newGoal = new EternalGoal(name, description, points);
        }
        else
        {
            int target = ReadInt("How many times does this goal need to be accomplished?");

            int bonus = ReadInt("What is the bonus for accomplishing it that many times?");

            newGoal = new ChecklistGoal(name, description, points, target, bonus);
        }

        _goals.Add(newGoal);

        Console.WriteLine("Goal Saved");
    }

    public void RecordEvent()
    {
        Console.WriteLine();

        if (_goals.Count == 0)
        {
            Console.WriteLine("A goal must be created before recording an event.");
            return;
        }

        Console.WriteLine("The goals are:");
        ListGoalNames();

        int goalNumber = ReadInt("Which goal did you accomplish?");

        int goalIndex = goalNumber - 1;

        if (goalIndex < 0 || goalIndex >= _goals.Count)
        {
            Console.WriteLine("That goal number does not exist");
            return;
        }

        int oldLevel = CalculateLevel();

        int pointsEarned = _goals[goalIndex].RecordEvent();

        _score += pointsEarned;

        int newLevel = CalculateLevel();

        if (pointsEarned == 0)
        {
            Console.WriteLine("That goal is done");
        }
        else
        {
            Console.WriteLine($"You earned {pointsEarned} points");
        }

        Console.WriteLine("You now have {_score} points");

        if (newLevel > oldLevel)
        {
            Console.WriteLine();
            Console.WriteLine("**************************");
            Console.WriteLine($"Congratulations! You have reached level {newLevel}");
            Console.WriteLine("**************************");
        }
    }

    public void SaveGoals()
    {
        Console.WriteLine("What is the filename for the goal file?");
        string fileName = Console.ReadLine();

        try
        {
            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                outputFile.WriteLine(_score);

                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("Goals Saved");
            
        }
        catch (Exception error)
        {
            Console.WriteLine($"The goals could not be saved: {error.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.WriteLine("What is the filename for the goal file?");
        string fileName = Console.ReadLine();

        if (!File.Exists(fileName))
        {
            Console.WriteLine("File does not exist");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(fileName);

            if (lines.Length == 0)
            {
                Console.WriteLine("The file is empty");
                return;
            }

            _goals.Clear();
            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');

                string goalType = parts[0];
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                Goal loadedGoal;

                if (goalType == "SimpleGoal")
                {
                    bool isComplete = bool.Parse(parts[4]);

                    loadedGoal = new SimpleGoal(name, description, points, isComplete);
                }
                else if (goalType == "EternalGoal")
                {
                    loadedGoal = new EternalGoal(name, description, points);
                }
                else if (goalType == "ChecklistGoal")
                {
                    int target = int.Parse(parts[4]);
                    int bonus = int.Parse(parts[5]);
                    int amountComplete = int.Parse(parts[6]);

                    loadedGoal = new ChecklistGoal(name, description, points, target, bonus, amountComplete);
                }
                else
                {
                    continue;
                }

                _goals.Add(loadedGoal);
            }
            
            Console.WriteLine("Goals Loaded");
        }
        catch (Exception error)
        {
            Console.WriteLine($"Goals Not Loaded: {error.Message}");
        }
    }

    private int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                return number;
            }

            Console.WriteLine("Please enter a valid number");
        }
    }

    public int CalculateLevel()
    {
        return (_score / 1000) + 1; 
    }
}