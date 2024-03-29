using System;

public class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public virtual string ShortName => _shortName;
    public string Description => _description;
    public int Points => _points;

    public virtual void RecordEvent()
    {
    }

    public virtual bool IsComplete()
    {
        return false;
    }

    public virtual string GetDetailsString()
    {
        return $"{(IsComplete() ? "[X]" : "[ ]")} {_shortName} ({_description})";
    }

    public virtual string Serialize()
    {
        return $"Goal: {_shortName}, {_description}, {_points}";
    }

    public virtual void Deserialize(string serializedData)
    {
        string[] data = serializedData.Split(',');
        if (data.Length == 3 && data[0].Trim().StartsWith("Goal:")) // Check for the expected format
        {
            _shortName = data[0].Trim().Substring(6).Trim();
            _description = data[1].Trim();
            if (int.TryParse(data[2].Trim(), out int points)) // Use int.TryParse to safely parse the points
            {
                _points = points;
            }
            else
            {
                Console.WriteLine("Error: Invalid points value in serialized data for Goal.");
            }
        }
        else
        {
            Console.WriteLine("Error: Invalid serialized data format for Goal.");
        }
    }

    public virtual string GetStringRepresentation()
    {
        return $"{_points}\n{_shortName}: {_description}, {_points}";
    }
}