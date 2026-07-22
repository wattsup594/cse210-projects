using System;

//I added a level system to the program, so that
//when the user reaches 1000 points they go up one level.
//The program also announces when they have reached a new level.

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}