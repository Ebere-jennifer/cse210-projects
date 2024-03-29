using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score = 0;

    public GoalManager()
    {
        _goals = new List<Goal>();
    }

    public void Start()
    {
        // Prompt the user to enter their name
        Console.Write("What is your name? ");
        string name = Console.ReadLine();

        // Prompt the user to enter their age
        Console.Write("How old are you? ");
        int age = int.Parse(Console.ReadLine());

        // Prompt the user to enter their gender
        Console.Write("Enter your gender (M/F): ");
        char gender = char.Parse(Console.ReadLine());
        Console.WriteLine();

        // Display a welcome message with user information
        Console.WriteLine($"{name}, you're welcome to the Eternal Quest Program - Goals.");
        Console.WriteLine();

        // Display a personalized and enthusiastic message about the user's age and gender
        Console.WriteLine($"Fantastic! You're {age} years young and ready to embark on your journey to conquer your goals, {name}!");
        Console.WriteLine();

        string genderPronoun = (gender == 'M') ? "He" : "She";
        string genderPossessive = (gender == 'M') ? "His" : "Her";

        Console.WriteLine($"{name}, is ready to unleash the power within as {genderPronoun.ToLower()} tackles each goal with determination and courage. With {genderPossessive.ToLower()} unwavering spirit, nothing can stand in {genderPossessive.ToLower()} way!");
        Console.WriteLine();

        Console.WriteLine("Let's start by setting up your goals and making every moment count!");
        Console.WriteLine();
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points. ");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are: ");
        Console.WriteLine();
        
        int count = 1; // Counter to put an index
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{count}. {goal.ShortName}");
            count++;
        }
        // Add spacing before displaying the menu again
        Console.WriteLine();
    }

    public void ListGoalDetails()
    {
        Console.WriteLine($"Score: {_score}");
        Console.WriteLine("The goals are: ");
        
        int count = 1; // Counter to put an index
        foreach (Goal goal in _goals)
        {
           Console.WriteLine($"{count}. {goal.GetDetailsString()}");
            count++;
        }
        // Add spacing before displaying the menu again
        Console.WriteLine();
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are: ");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string goalTypeInput = Console.ReadLine();

        switch (goalTypeInput)
        {
            case "1":
                Console.Write("What is the name of your goal? ");
                string simpleName = Console.ReadLine();
                Console.Write("What is a short description of it? ");
                string simpleDescription = Console.ReadLine();
                Console.Write("What is the amount of points associated with this goal? ");
                int simplePoints = int.Parse(Console.ReadLine());
                _goals.Add(new SimpleGoal(simpleName, simpleDescription, simplePoints));
                break;
            case "2":
                Console.Write("What is the name of your goal? ");
                string eternalName = Console.ReadLine();
                Console.Write("What is a short description of it? ");
                string eternalDescription = Console.ReadLine();
                Console.Write("What is the amount of points associated with this goal? ");
                int eternalPoints = int.Parse(Console.ReadLine());
                _goals.Add(new EternalGoal(eternalName, eternalDescription, eternalPoints));
                break;
            case "3":
                Console.Write("What is the name of your goal? ");
                string checklistName = Console.ReadLine();
                Console.Write("What is a short description of it? ");
                string checklistDescription = Console.ReadLine();
                Console.Write("What is the amount of points associated with this goal? ");
                int checklistPoints = int.Parse(Console.ReadLine());
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(checklistName, checklistDescription, checklistPoints, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type");
                break;
        }
        // Add spacing before displaying the menu again
        Console.WriteLine();
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine());

        if (index >= 1 && index <= _goals.Count)
        {
            int selectedIndex = index - 1;
            _goals[selectedIndex].RecordEvent();
            _score += _goals[selectedIndex].Points;
            Console.WriteLine($"Congratulations! You have earned {_goals[selectedIndex].Points} point.");
            Console.WriteLine($"You now have {_score} points.");

            // Check if the completed goal is a ChecklistGoal
            if (_goals[selectedIndex] is ChecklistGoal checklistGoal)
            {
                // Increment the amount completed for the ChecklistGoal
                checklistGoal.RecordEvent(checklistGoal.AmountCompleted + 1);

                // Check if the ChecklistGoal has reached its target
                if (checklistGoal.IsComplete())
                {
                    // If the target is reached, award the bonus points
                    _score += checklistGoal.Bonus;
                    Console.WriteLine($"Congratulations! You have completed {checklistGoal.ShortName} and earned a bonus of {checklistGoal.Bonus} points.");
                    Console.WriteLine($"You now have {_score} points.");
                }
                else
                {
                    Console.WriteLine($"You have completed {checklistGoal.AmountCompleted} out of {checklistGoal.Target} times for {checklistGoal.ShortName}.");
                }
            }

        }
        else
        {
            Console.WriteLine("Invalid goal index");
        }

        // Add spacing before displaying the menu again
        Console.WriteLine();
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        // Get the path to the file where goals will be saved
        string filePath = fileName;

        // Create a new StreamWriter to write to the file
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            // Write the player's score first
            writer.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                // Write the goal details to the file
                writer.WriteLine(goal.Serialize());
            }
        }

        Console.WriteLine("Goals saved successfully.");

        // Add spacing before displaying the menu again
        Console.WriteLine();
    }

    

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        // Get the path to the file where goals will be saved
        string filePath = fileName;

        // Clear existing goals before loading
        _goals.Clear();

        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                _score = int.Parse(reader.ReadLine()); // Read and set the player's score
                
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(':');
                    if (data.Length == 2)
                    {
                        string goalType = data[0].Trim();
                        string serializedData = data[1].Trim();

                        Goal goal;

                        if (goalType == "SimpleGoal")
                        {
                            string[] goalData = serializedData.Split(',');
                            if (goalData.Length == 4)
                            {
                                string name = goalData[0].Trim();
                                string description = goalData[1].Trim();
                                int points = int.Parse(goalData[2].Trim());
                                bool isComplete = bool.Parse(goalData[3].Trim()); // Parse the boolean value
                                goal = new SimpleGoal(name, description, points);
                            }
                            else
                            {
                                // Handle invalid serialized data for SimpleGoal if needed
                                continue;
                            }
                        }
                        else if (goalType == "EternalGoal")
                        {
                            string[] goalData = serializedData.Split(',');
                            if (goalData.Length == 3)
                            {
                                string name = goalData[0].Trim();
                                string description = goalData[1].Trim();
                                int points = int.Parse(goalData[2].Trim());
                                goal = new EternalGoal(name, description, points);
                            }
                            else
                            {
                                // Handle invalid serialized data for EternalGoal if needed
                                continue;
                            }
                        }
                        else if (goalType == "ChecklistGoal")
                        {
                            string[] goalData = serializedData.Split(',');
                            if (goalData.Length == 6)
                            {
                                string name = goalData[0].Trim();
                                string description = goalData[1].Trim();
                                int points = int.Parse(goalData[2].Trim());
                                int target = int.Parse(goalData[3].Trim());  
                                int bonus = int.Parse(goalData[4].Trim());
                                int amountCompleted = int.Parse(goalData[5].Trim());
                                goal = new ChecklistGoal(name, description, points, target, bonus);
                            }
                            else
                            {
                                // Handle invalid serialized data for ChecklistGoal if needed
                                continue;
                            }
                        }
                        else
                        {
                            // Handle unrecognized goal type if needed
                            continue;
                        }
                            _goals.Add(goal);                       
                    }
                }
            }
            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("No goals found.");
        }

        Console.WriteLine();
    }
}