using System;
using System.IO;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creativity/Extra features (explained here as required in the assignment):
            // 1. Leveling system: every 1000 points increases your level (displayed with score).
            // 2. Flexible plain-text save format that is human readable and allows easy debugging.
            // 3. Habit-tracking style: eternal goals are shown with [~].
            // Note: these extras are documented above and here so graders can see what was added.

            var gm = new GoalManager();
            string saveFile = "eternalquest_save.txt";

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Eternal Quest - Main Menu");
                Console.WriteLine($"Score: {gm.Score} | Level: {gm.GetLevel()}");
                Console.WriteLine("1. Show goals");
                Console.WriteLine("2. Create new goal");
                Console.WriteLine("3. Record event (accomplish a goal)");
                Console.WriteLine("4. Save goals");
                Console.WriteLine("5. Load goals");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");
                var input = Console.ReadLine();
                Console.WriteLine();

                if (input == "1")
                {
                    gm.ShowGoals();
                }
                else if (input == "2")
                {
                    CreateGoalInteractive(gm);
                }
                else if (input == "3")
                {
                    gm.ShowGoals();
                    Console.Write("Which goal number did you accomplish? ");
                    if (int.TryParse(Console.ReadLine(), out int n))
                    {
                        gm.RecordEvent(n - 1);
                    }
                }
                else if (input == "4")
                {
                    Console.Write($"Save file name (enter for '{saveFile}'): ");
                    var fn = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(fn)) saveFile = fn;
                    gm.Save(saveFile);
                }
                else if (input == "5")
                {
                    Console.Write($"Load file name (enter for '{saveFile}'): ");
                    var fn = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(fn)) saveFile = fn;
                    gm.Load(saveFile);
                }
                else if (input == "6")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option.");
                }
            }

            Console.WriteLine("Thanks for using Eternal Quest!");
        }

        static void CreateGoalInteractive(GoalManager gm)
        {
            Console.WriteLine("Choose goal type: 1) Simple  2) Eternal  3) Checklist");
            var type = Console.ReadLine();
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Description: ");
            var desc = Console.ReadLine();
            Console.Write("Points (integer): ");
            int pts = int.TryParse(Console.ReadLine(), out int p) ? p : 0;

            if (type == "1")
            {
                gm.AddGoal(new SimpleGoal(name, desc, pts));
            }
            else if (type == "2")
            {
                gm.AddGoal(new EternalGoal(name, desc, pts));
            }
            else if (type == "3")
            {
                Console.Write("Required number of times to complete: ");
                int req = int.TryParse(Console.ReadLine(), out int r) ? r : 1;
                Console.Write("Completion bonus points: ");
                int bonus = int.TryParse(Console.ReadLine(), out int b) ? b : 0;
                gm.AddGoal(new ChecklistGoal(name, desc, pts, req, bonus));
            }
            else
            {
                Console.WriteLine("Unknown type, aborting.");
            }
        }
    }
}
