// ReflectionActivity.cs
using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private Random _random = new Random();

    private List<string> _prompts = new()
    {
        "Think of a time when you helped someone in need.",
        "Think of a time when you overcame a challenge.",
        "Think of a moment where you made a good decision.",
        "Think of a time when you stayed calm in a stressful situation."
    };

    private List<string> _questions = new()
    {
        "Why was this meaningful to you?",
        "What did you learn from it?",
        "How did you feel afterward?",
        "What made this experience special?",
        "How can you apply this lesson again?"
    };

    public ReflectionActivity()
        : base("Reflection Activity", "This activity helps you reflect on meaningful experiences.")
    {
    }

    public override void Start()
    {
        DisplayStartingMessage();

        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine($"\nPrompt:\n>> {prompt}");
        Console.WriteLine("\nConsider the following questions:");

        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            string q = _questions[_random.Next(_questions.Count)];
            Console.WriteLine($"\n- {q}");
            PauseWithSpinner(6);
        }

        DisplayEndingMessage();
    }
}
