using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"{base.GetStringRepresentation()}, {_isComplete}";
    }

    public override string Serialize()
    {
        return $"SimpleGoal: {_shortName}, {_description}, {_points}, {_isComplete}";
    }

    public override void Deserialize(string serializedData)
    {
        string[] data = serializedData.Split(',');
        if (data.Length == 4)
        {
            _shortName = data[0].Trim().Substring(11); // Adjust substring index
            _description = data[1].Trim();
            _points = int.Parse(data[2].Trim());
            
            if (!bool.TryParse(data[3].Trim(), out _isComplete))
            {
                Console.WriteLine("Error: Invalid boolean value in serialized data for SimpleGoal.");
                _isComplete = false; // Set default value
            }
        }
        else
        {
            Console.WriteLine("Error: Invalid serialized data for SimpleGoal.");
        }
    }
}