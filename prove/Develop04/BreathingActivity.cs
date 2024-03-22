using System;

public class BreathingActivity : Activity
{
    public BreathingActivity(int duration)
        : base("Breathing", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.", duration)
    {
    }

    public BreathingActivity(string name, string description, int duration)
        : base(name, description, duration)
    {
    }

    public override void DisplayStartingMessage()
    {
        Console.Clear();
        base.DisplayStartingMessage();
    }

    public override void DisplayEndingMessage()
    {
        base.DisplayEndingMessage();
    }

    public void Run()
    {
        DisplayStartingMessage();
        for (int i = 0; i < 4; i++)
        {
            Console.Write("\nBreathe in...");
            if (i == 0)
            {
                ShowCountDown(3);
            }
            else
            {
                ShowCountDown(4);
            }

            Console.Write("\nNow breathe out...");
            if (i == 0)
            {
                ShowCountDown(3);
            }
            else
            {
                ShowCountDown(6);
            }
            Console.WriteLine();
        }
        DisplayEndingMessage();
    }
}
