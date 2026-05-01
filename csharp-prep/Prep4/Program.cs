using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a  list of numbers, type 0 when finsihed.");
        int input = -1;

        while (input != 0)
        {
            Console.Write("Enter Number: ");
            input = int.Parse(Console.ReadLine());
            if (input != 0)
            {
                numbers.Add(input);
            }
        }

        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }

        double average = (double)sum / numbers.Count;

        int max = numbers[0];
        foreach (int num in numbers)
        {
            if (num > max)
            {
                max = num;
            }
        }

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }
}