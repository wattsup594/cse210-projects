using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string name = PromptUserName();
        int favoriteNumber = PromptUserNumber();

        int birthYear;
        PromptUserBirthYear(out birthYear);

        int squaredNumber = SquareNumber(favoriteNumber);

        DisplayResult(name, squaredNumber, birthYear);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome!");
    }

    static string PromptUserName()
    {
        Console.Write("Please Enter Your Name: ");
        string name =  Console.ReadLine();
        return name;
    }
    static int PromptUserNumber()
    {
        Console.Write("Please Enter Your Favorite Number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }
    static void PromptUserBirthYear(out int birthYear)
    {
        Console.Write("Please Enter Your Birth Year:");
        birthYear = int.Parse(Console.ReadLine());
    }
    static int SquareNumber(int number)
    {
       int square = number * number;
       return square; 
    }
    static void DisplayResult(string name, int squaredNumber, int birthYear)
    {
        int currentYear = DateTime.Now.Year;
        int ageThisYear = currentYear - birthYear;

        Console.WriteLine($"{name}, the square of your favorite number is: {squaredNumber}");
        Console.WriteLine($"{name}, you will turn {ageThisYear} this year.");
    }
}