using System;

public class ActivityLog
{
    private Dictionary<string, int> activityCount;

    public ActivityLog()
    {
        activityCount = new Dictionary<string, int>();
    }

    public void AddActivity(string activityName)
    {
        if (activityCount.ContainsKey(activityName))
            activityCount[activityName]++;
        else
            activityCount[activityName] = 1;
    }

    public void DisplayLog()
    {
        Console.WriteLine("Activity Log:");
        foreach (var activity in activityCount)
        {
            Console.WriteLine($"{activity.Key}: {activity.Value} times");
        }
    }

    public void SaveLogToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine("Activity Log:");
            foreach (var activity in activityCount)
            {
                writer.WriteLine($"{activity.Key}: {activity.Value} times");
            }
        }
        Console.WriteLine($"The activity log is saved to {filename}");
    }
}