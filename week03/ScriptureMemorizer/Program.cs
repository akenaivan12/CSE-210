using System;
using System.Collections.Generic;

class Program
{
    /*
     * EXCEEDS CORE REQUIREMENTS:
     * --------------------------
     * 1. Program contains a SCRIPTURE LIBRARY.
     *    - Instead of one scripture, the program randomly selects from a list.
     * 2. User gets a different scripture each time they run the program.
     */

    static void Main(string[] args)
    {
        Console.Clear();

        List<Scripture> scriptureLibrary = new List<Scripture>()
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son " +
                "that whosoever believeth in him should not perish but have everlasting life."
            ),

            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding " +
                "in all thy ways acknowledge him and he shall direct thy paths."
            ),

            new Scripture(
                new Reference("1 Nephi", 3, 7),
                "I will go and do the things which the Lord hath commanded for I know that the Lord " +
                "giveth no commandments unto the children of men save he shall prepare a way for them " +
                "that they may accomplish the thing which he commandeth them."
            )
        };

        Random rand = new Random();
        Scripture scripture = scriptureLibrary[rand.Next(scriptureLibrary.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);

            if (scripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                break;
            }
        }
    }
}
