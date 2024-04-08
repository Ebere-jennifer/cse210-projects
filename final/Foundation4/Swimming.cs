using System;
using System.Collections.Generic;

class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        double distanceInMiles = _laps * 50.0 / 1609.34; // Convert laps to miles
        return Math.Round(distanceInMiles, 3); // Round distance to 3 decimal places
    }

    public override double GetSpeed()
    {
       double speed = GetDistance() / (_minutes / 60.0);
    return Math.Round(speed, 3); // Round speed to 3 decimal places
    }

    public override double GetPace()
    {
        double pace = _minutes / GetDistance();
        return Math.Round(pace, 2);
    }
}