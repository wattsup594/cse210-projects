using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction frac1 = new Fraction();
        Fraction frac2 = new Fraction(5);
        Fraction frac3 = new Fraction(3, 4);
        Fraction frac4 = new Fraction(1, 3);

        Console.WriteLine(frac1.GetFractionString());
        Console.WriteLine(frac1.GetDecimalValue());

        Console.WriteLine(frac2.GetFractionString());
        Console.WriteLine(frac2.GetDecimalValue());

        Console.WriteLine(frac3.GetFractionString());
        Console.WriteLine(frac3.GetDecimalValue());

        Console.WriteLine(frac4.GetFractionString());
        Console.WriteLine(frac4.GetDecimalValue());

        Console.WriteLine();

        frac1.SetTop(6);
        frac1.SetBottom(7);


        Console.WriteLine("After setters:");
        Console.WriteLine($"Top = {frac1.GetTop()}");
        Console.WriteLine($"Bottom = {frac1.GetBottom()}");


        Console.WriteLine();

        Random random = new Random();
        Fraction randomFraction = new Fraction();

        for (int i =1; i <= 20; i++)
        {
            int top = random.Next(1, 11);
            int bottom = random.Next(1, 11);

            randomFraction.SetTop(top);
            randomFraction.SetBottom(bottom);

            Console.WriteLine($"Fraction {i}:  Fraction: {randomFraction.GetFractionString()}  Decimal: {randomFraction.GetDecimalValue()}");
        }
    }
}