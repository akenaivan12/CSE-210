using System;

/*
W02 Project: Journal Program
CSE 210 - Programming with Classes
---------------------------------
This version exceeds requirements by:
- Adding mood ratings to entries
- Saving in CSV format (Excel-compatible)
- Automatically creating a "SavedJournals" folder
- Displaying summary statistics (entry count, average mood)
*/

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("\n--- Journal Menu ---");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option (1-5): ");

            string input = Console.ReadLine();
            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();

                    int mood = 0;
                    while (mood < 1 || mood > 5)
                    {
                        Console.Write("Rate your mood today (1–5): ");
                        int.TryParse(Console.ReadLine(), out mood);
                    }

                    Entry entry = new Entry
                    {
                        Date = DateTime.Now.ToString("MM/dd/yyyy"),
                        Prompt = prompt,
                        Response = response,
                        MoodRating = mood
                    };

                    journal.AddEntry(entry);
                    Console.WriteLine("Entry added successfully!\n");
                    break;

                case 2:
                    journal.DisplayAll();
                    break;

                case 3:
                    Console.Write("Enter filename (e.g., journal.csv): ");
                    string saveName = Console.ReadLine();
                    journal.SaveToFile(saveName);
                    break;

                case 4:
                    Console.Write("Enter filename to load (e.g., journal.csv): ");
                    string loadName = Console.ReadLine();
                    journal.LoadFromFile(loadName);
                    break;

                case 5:
                    Console.WriteLine("Goodbye! Keep journaling daily!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select 1–5.");
                    break;
            }
        }
    }
}
