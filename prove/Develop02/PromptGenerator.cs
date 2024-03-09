using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "Did you have fun today?",
        "What did you do right today?",
        "What did you think about and why did you think about it?",
        "What are your goals?",
        "What went well today?",
        "What's a simple pleasure in your life that you are thankful for?",
        "How did you show love to someone today?",
        "How would you describe your spirituality today?",
        "What was your magic power today?",
        "Identify three times that you felt challenged today.",
        "What do I need to let go of today?",
        "What do you need the most right now?",
        "If you could only accomplish three things tomorrow, what would they be?",
        "What was the most peaceful moment during the day?",
        "Would you change any of the decisions you made today?",
        "What frightened you today?"
    };

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        return _prompts[index];
    }
}
