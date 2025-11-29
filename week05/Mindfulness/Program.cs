// Program.cs
using System;

class Program
{
    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== Mindfulness Program ===");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("\nSelect an option: ");

            string choice = Console.ReadLine();
            Activity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                "4" => null,
                _ => null
            };

            if (choice == "4")
            {
                running = false;
                continue;
            }

            if (activity == null)
            {
                Console.WriteLine("Invalid selection. Press Enter.");
                Console.ReadLine();
                continue;
            }

            Console.Write("Enter duration in seconds: ");
            if (!int.TryParse(Console.ReadLine(), out int sec) || sec <= 0)
                sec = 30; // default

            activity.SetDuration(sec);
            activity.Start();

            Console.WriteLine("\nPress Enter to return to menu...");
            Console.ReadLine();
        }

        Console.WriteLine("Goodbye!");
    }
}
