using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectingActivity(int duration)
        : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", duration)
    {
    }

    public ReflectingActivity(string name, string description, int duration)
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
        DisplayPrompt();
        DisplayQuestion();
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        return _prompts[new Random().Next(_prompts.Count)];
    }

    public string GetRandomQuestion()
    {
        return _questions[new Random().Next(_questions.Count)];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine("\nConsider the following prompt: ");
        Console.WriteLine($"\n--- {GetRandomPrompt()} ---");
        Thread.Sleep(3000);
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Thread.Sleep(5000);
    }

    public void DisplayQuestion()
    {
        Console.WriteLine("\nNow ponder on each of the following questions as they relate to this experience.");
        Console.WriteLine("You may begin in...");
        ShowCountDown(5);
        Console.ReadLine(); // Wait for the user to press enter before displaying the questions

        Random random = new Random();

        for (int i = 0; i < 2; i++) // Display only two questions
        {
            int randomIndex = random.Next(_questions.Count);
            string question = _questions[randomIndex];
            _questions.RemoveAt(randomIndex);

            // Display question with angle bracket
            Console.WriteLine($"> {question}");

            ShowSpinner(3);
        }
    }
}
