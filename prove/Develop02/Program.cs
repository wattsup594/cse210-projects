using System;

class Program
{
    static void Main(string[] args)
    {
        //exceeding requirement: I added a mood tracker, so that people can track their mood when they input their journal responses.
        
        Journal journal = new Journal();

        string choice = "";

        while(choice != "5")
        {
            Console.WriteLine("\nJournal Menu");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");

            Console.Write("Choose an option: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                journal.AddEntry();
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("Enter Filename: ");
                string filename = Console.ReadLine();

                journal.SaveToFile(filename);
            }
            else if (choice == "4")
            {
                Console.Write("Enter Filename: ");
                string filename = Console.ReadLine();

                journal.LoadFromFile(filename);
            }
            else if (choice == "5")
            {
                Console.WriteLine("Until Next Time!");
            }
            else
            {
                Console.WriteLine("Invalid Choice, Try Again");
            }
        }
    }
}