using System;

class Program
{
    static void Main(string[] args)
    {

        //Exceeding Requirements:
        //1. I added the Gratitude Activity.
        //2. I added an Activity Log class that saves activity to a txt file.
        //3. I made the Reflection Activity class use all the questions within the class
        // in a single session before repeating questions.

        
        ActivityLog log = new ActivityLog("ActivityLog.txt");

        string choice = "";

        while (choice != "6")
        {
            Console.Clear();

            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Start Breathing Activity");
            Console.WriteLine(" 2. Start Listing Activity");
            Console.WriteLine(" 3. Start Gratitude Activity");
            Console.WriteLine(" 4. Start Reflecting Activity");
            Console.WriteLine(" 5. View Activity Log");
            Console.WriteLine(" 6. Quit");
            Console.Write("Choose A Number From The Menu: ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                RunActivity(new BreathingActivity(), log);
            }
            else if (choice == "2")
            {
                RunActivity(new ListingActivity(), log);
            }
            else if (choice == "3")
            {
                RunActivity(new GratitudeActivity(), log);
            }
            else if (choice == "4")
            {
                RunActivity(new ReflectingActivity(), log);
            }
            else if (choice == "5")
            {
                log.DisplayLog();
            }
            else if (choice == "6")
            {
                Console.WriteLine("Until Next Time!");
            }
            else
            {
                Console.WriteLine("Please Enter A Valid Choice");
                Console.WriteLine("Press Enter To Continue");
                Console.ReadLine();
            }
        }
    }

    static void RunActivity(Activity activity, ActivityLog log)
    {
        activity.Run();
        log.RecordActivity(activity.GetName(), activity.GetDuration());
    }
}