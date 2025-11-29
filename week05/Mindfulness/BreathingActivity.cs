// BreathingActivity.cs
using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity", "This activity helps you relax through guided breathing.")
    {
    }

    public override void Start()
    {
        DisplayStartingMessage();

        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            Console.Write("\nBreathe in ");
            AnimateBreath(true);

            Console.Write("\nBreathe out ");
            AnimateBreath(false);
        }

        DisplayEndingMessage();
    }

    private void AnimateBreath(bool inhale)
    {
        int steps = 10;
        for (int i = inhale ? 1 : steps; inhale ? i <= steps : i >= 1; i += ( inhale ? 1 : -1 ))
        {
            Console.Write($"{new string('.', i)}");
            Thread.Sleep(200);
            Console.Write(new string('\b', i));
        }
    }
}
