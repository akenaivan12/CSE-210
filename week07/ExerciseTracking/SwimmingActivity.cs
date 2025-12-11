// SwimmingActivity.cs
public class SwimmingActivity : Activity
{
    private int _laps;

    public SwimmingActivity(string date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // 50 meters per lap → converting to kilometers
        return (_laps * 50) / 1000.0;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetMinutes() / GetDistance();
    }
}
