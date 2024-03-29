using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public int AmountCompleted => _amountCompleted;

    public int Target => _target;

    public int Bonus => _bonus;

    public override string ShortName => _shortName;

    public void RecordEvent(int amountCompleted)
    {
        _amountCompleted = amountCompleted;
        if (_amountCompleted == _target)
        {
            _points += _bonus;
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        if (IsComplete())
        {
            return $"{base.GetDetailsString()} --- Completed: {_amountCompleted}/{_target}";
        }
        else
        {
            return $"{base.GetDetailsString()} --- Currently completed: {_amountCompleted}/{_target}";
        }
    }

    public override string Serialize()
    {
        return $"ChecklistGoal: {_shortName}, {_description}, {_points}, {_target}, {_bonus}, {_amountCompleted}";
    }

    public override void Deserialize(string serializedData)
    {
        string[] data = serializedData.Split(',');
        if (data.Length == 6) 
        {
            base.Deserialize(serializedData);
            _target = int.Parse(data[3].Trim());
            _bonus = int.Parse(data[4].Trim());
            _amountCompleted = int.Parse(data[5].Trim()); 
        }
        else
        {
            Console.WriteLine("Error: Invalid serialized data for ChecklistGoal.");
        }
    }
}