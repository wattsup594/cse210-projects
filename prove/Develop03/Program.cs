using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        //Exceeding Requirements:
        //I added a separate text file that the scriptures load from.
        //The program chooses a random scripture.
        //The user can choose how many words are hidden each round.

        List<Scripture> scriptures = LoadScripturesFromFile("Scriptures.txt");

        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        Console.Write("How many words would you like to hide each time? ");
        int wordsToHide = int.Parse(Console.ReadLine());

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine();
            Console.Write("Press Enter to continue or type 'quit': ");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }
            scripture.HideRandomWords(wordsToHide);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nProgram Complete");
    }

    static List<Scripture> LoadScripturesFromFile(string fileName)
    {
        List<Scripture> scriptures = new List<Scripture>();

        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            string book = parts[0];
            int chapter = int.Parse(parts[1]);
            int startVerse = int.Parse(parts[2]);
            int endVerse = int.Parse(parts[3]);
            string text = parts[4];

            Reference reference = new Reference(book, chapter, startVerse, endVerse);
            Scripture scripture = new Scripture(reference, text);

            scriptures.Add(scripture);
        }
        return scriptures;
    }
}