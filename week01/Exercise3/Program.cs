using System;

class Program
{
    static void Main()
    {
        string playAgain;

        // Outer loop: allows the player to play multiple times
        do
        {
            // Create a random number between 1 and 100
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = -1;
            int guessCount = 0;

            Console.WriteLine("I've picked a magic number between 1 and 100!");

            // Inner loop: keeps asking until the correct guess
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }
            }

            // Ask to play again
            Console.Write("\nDo you want to play again (yes/no)? ");
            playAgain = Console.ReadLine().ToLower();
            Console.WriteLine();

        } while (playAgain == "yes");

        Console.WriteLine("Thanks for playing! Goodbye!");
    }
}
