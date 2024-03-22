using System;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    private bool _isStartingMessageDisplayed = false; // Add a flag to track if the starting message is displayed

    public virtual void DisplayStartingMessage()
    {
        if (!_isStartingMessageDisplayed) // Only display the starting message if it hasn't been displayed before
        {
          Console.Clear();
          Console.WriteLine($"\nWelcome to the {_name} Activity:");
          Console.WriteLine();
          Console.WriteLine(_description);
          Console.WriteLine();
          Console.Write("How long, in seconds, would you like for your session? ");
          Thread.Sleep(2000);
          Console.Clear();
          Console.WriteLine("\nGet ready...");
          ShowSpinner(3);
          _isStartingMessageDisplayed = true; // Set the flag to true after displaying the starting message
        }
    }

    public virtual void DisplayEndingMessage()
    {
        Console.WriteLine($"\nWell done!!");
        ShowSpinner(4);
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");
        Thread.Sleep(2000);
    }

    protected void ShowSpinner(int seconds)
    {
        char[] spinChars = { '/', '-', '\\', '|' }; // Additional spinner characters for variety
        int index = 0;

        for (int i = 0; i < seconds * 2; i++) // Multiplying by 2 to increase the number of iterations
        {
            Console.Write(spinChars[index]);
            Thread.Sleep(1000); // Increased delay time for a slower spinning effect
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop); // Move cursor back to overwrite the previous spinner
            index = (index + 1) % spinChars.Length; // Update the index to get the next spinner character
        }
    }


    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} "); // Display the countdown number
            Thread.Sleep(1000);
            if (Console.CursorLeft >= 2)
            {
                Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop); // Move cursor back to overwrite the previous countdown
            }
            else
            {
                Console.SetCursorPosition(0, Console.CursorTop); // Move cursor to the beginning of the line
            }
        
            // Clear the countdown number from the screen
            Console.Write(new string(' ', (seconds.ToString().Length + 1))); // Writes spaces over the countdown number
            Console.SetCursorPosition(Console.CursorLeft - (seconds.ToString().Length + 1), Console.CursorTop); // Move cursor back to the position before the countdown
        }
    }
}