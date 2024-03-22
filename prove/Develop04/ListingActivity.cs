using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private int _count;
    
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int duration)
        : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", duration)
    {
    }

    public ListingActivity(string name, string description, int duration)
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
        var question = GetRandomPrompt();
        List<string> items = GetListFromUser();
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        return _prompts[new Random().Next(_prompts.Count)];
    }

    public List<string> GetListFromUser()
    {   
        var question = GetRandomPrompt();
        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        Console.WriteLine($"\n--- {question} ---");

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        List<string> items = new List<string>();

        Console.WriteLine("You may begin in: ");
        ShowCountDown(5);

        while (DateTime.Now < endTime)
        {
            // Prompt the user with an angle bracket before their response
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
                items.Add(item);
            else
                break;
        }

        _count = items.Count;
        Console.WriteLine($"\nYou listed {_count} items!");
        return items;
    }
}
