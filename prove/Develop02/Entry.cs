using System;

public class Entry
{
    public string _userName;
    public string _mood;
    public string _date = DateTime.Now.ToString("dd-MM-yyyy");
    public string _promptText;
    public string _entryText;
    
    

    public Entry(string UserName, string Mood, string Date, string Prompt, string Response)
    {
        _userName = UserName;
        _mood = Mood;
        _date = Date;
        _promptText = Prompt;
        _entryText = Response;
        
    }

    public void Display()
    {
        Console.WriteLine($"UserName: {_userName}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"{_entryText}");
    }
}

