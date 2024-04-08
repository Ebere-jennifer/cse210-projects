using System;
using System.Collections.Generic;

// Inheritance with Event Planning
// In this program, I was able to write a program that has a base Activity class and then has a derived class for each of 
// the three activities. The base class contains attributes that are shared among all activities. Then, each derived class 
// defines other additional attributes. In addition, the base class contains virtual methods for getting the distance, speed and
// pace. These methods were overridden in the derived classes. I provided a GetSummary method to produce a string with all the 
// summary information. Below is the output of summary in the form of: 

// 03 Nov 2022 Running (30 min) - Distance: 3.0 miles, Speed: 6.0 mph, Pace: 10.0 min per mile
// 03 Nov 2022 Cycling (30 min) - Distance: 3.0 miles, Speed: 6.0 mph, Pace: 10.0 min per mile 
// 03 Nov 2022 Swimming (30 min) - Distance: 0.9 miles, Speed: 1.9 mph, Pace: 32.2 min per mile

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),
            new Cycling(new DateTime(2022, 11, 3), 30, 6.0),
            new Swimming(new DateTime(2022, 11, 3), 30, 30)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}