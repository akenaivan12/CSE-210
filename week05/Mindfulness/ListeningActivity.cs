// ListingActivity.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ListingActivity : Activity
{
    private Random _random = new Random();

    private List<string> _prompts = new()
    {
        "List people you appreciate.",
        "List your personal strengths.",
        "List things that made you smile recently.",
        "List people you have helped this month."
    };

    public ListingActivity()
        : base("Listing Activity", "This activity helps you focus on good things in your life.")
    {
    }

    public override void Start()
    {
        DisplayStartingMessage();

        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine($"\nPrompt:\n>> {prompt}");
        Console.WriteLine("\nYou will begin shortly...");
        PauseCountdown(5);

        Console.WriteLine("\nStart listing items: (time-limited)");

        List<string> items = new();
        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            Task<string> inputTask = Task.Run(() => Console.ReadLine());

            while (!inputTask.IsCompleted && DateTime.Now < end)
                Thread.Sleep(50);

            if (DateTime.Now >= end) break;

            string result = inputTask.Result;

            if (!string.IsNullOrWhiteSpace(result))
                items.Add(result);
        }

        Console.WriteLine($"\nYou listed {items.Count} items:");
        foreach (var item in items)
            Console.WriteLine("- " + item);

        DisplayEndingMessage();
    }
}
