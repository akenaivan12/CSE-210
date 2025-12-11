// CyclingActivity.cs
public class CyclingActivity : Activity
{
    private double _speed; // mph or kph

    public CyclingActivity(string date, int minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return (_speed / 60) * GetMinutes();
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}
