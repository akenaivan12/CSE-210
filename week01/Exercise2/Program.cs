using System;

class Program
{
    static void Main()
    {
        // Ask for the grade percentage
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        int grade = int.Parse(input);

        string letter = "";
        string sign = "";

        // Determine the letter grade
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Stretch Challenge: Determine the sign (+ or -)
        int lastDigit = grade % 10;

        if (letter != "A" && letter != "F") // no A+ or F+/F-
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        else if (letter == "A" && grade < 93)
        {
            // A- only if below 93
            sign = "-";
        }

        // Print the final grade
        Console.WriteLine($"\nYour grade is: {letter}{sign}");

        // Determine pass or fail
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }
        else
        {
            Console.WriteLine("Keep working hard, you'll do better next time!");
        }
    }
}
