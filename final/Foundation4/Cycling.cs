using System;
using System.Collections.Generic;

class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetSpeed()
    {
        return Math.Round(_speed, 1); // Round speed to 1 decimal place
    }

    public override double GetDistance()
    {
        double distance = _speed * (_minutes / 60.0);
        return Math.Round(distance, 1); // Round distance to 1 decimal place
    }

    public override double GetPace()
    {
        double pace = 60.0 / _speed;
        return Math.Round(pace, 1); // Round distance to 1 decimal place
        // return pace.ToString("F2");
    }
}