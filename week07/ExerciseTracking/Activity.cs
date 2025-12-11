// Activity.cs
using System;

public abstract class Activity
{
    private string _date;         // shared attribute
    private int _minutes;         // shared attribute

    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public string GetDate()
    {
        return _date;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    // Abstract methods (must be overridden)
    public abstract double GetDistance(); // miles or km
    public abstract double GetSpeed();    // mph or kph
    public abstract double GetPace();     // minutes per mile or km

    // Virtual summary method
    public virtual string GetSummary()
    {
        return $"{_date} {this.GetType().Name} ({_minutes} min) - " +
               $"Distance {GetDistance():0.0}, " +
               $"Speed {GetSpeed():0.0}, " +
               $"Pace: {GetPace():0.0}";
    }
}
