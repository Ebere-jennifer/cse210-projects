using System;
using System.Collections.Generic;

class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int minutes, double distance)
        : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        // return _distance;
        return Math.Round(_distance, 1); // Round speed to 1 decimal place
    }

    public override double GetSpeed()
    {
        double speed = _distance / (_minutes / 60.0);
        return Math.Round(speed, 1); // Round speed to 1 decimal place
    }

    public override double GetPace()
    {
        double pace = _minutes / _distance;
        return Math.Round(pace, 1);
    }
}