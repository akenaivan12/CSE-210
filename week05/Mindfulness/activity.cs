// Activity.cs
using System;
using System.Threading;

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void SetDuration(int seconds)
    {
        if (seconds <= 0) throw new ArgumentException("Duration must be positive.");
        _duration = seconds;
    }

    public virtual void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---\n");
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.WriteLine($"This activity will last {_duration} seconds.");
        Console.WriteLine("Get ready...\n");
        PauseWithSpinner(3);
    }

    public virtual void DisplayEndingMessage()
    {
        Console.WriteLine("\nGreat job!");
        Console.WriteLine($"You completed the {_name} for {_duration} seconds.");
        PauseWithSpinner(3);
    }

    protected void PauseCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i.ToString());
            Thread.Sleep(1000);

            // Clear digits (supports double-digit)
            Console.Write(new string('\b', i.ToString().Length));
            Console.Write(new string(' ', i.ToString().Length));
            Console.Write(new string('\b', i.ToString().Length));
        }
    }

    protected void PauseWithSpinner(int seconds)
    {
        char[] frames = { '|', '/', '-', '\\' };
        int i = 0;
        DateTime end = DateTime.Now.AddSeconds(seconds);

        while (DateTime.Now < end)
        {
            Console.Write(frames[i++ % frames.Length]);
            Thread.Sleep(200);
            Console.Write('\b');
        }
    }

    public abstract void Start();
}
