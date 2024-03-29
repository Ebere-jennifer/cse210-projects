using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"{base.GetStringRepresentation()}";
    }

    public override string Serialize()
    {
        return $"EternalGoal: {_shortName}, {_description}, {_points}";
    }

    public override void Deserialize(string serializedData)
    {
        string[] data = serializedData.Split(',');
        if (data.Length == 3)
        {
            _shortName = data[0].Trim().Substring(12);
            _description = data[1].Trim();
            _points = int.Parse(data[2].Trim());
        }
        else
        {
            Console.WriteLine("Error: Invalid serialized data for EternalGoal.");
        }
    }
}