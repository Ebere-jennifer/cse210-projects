using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public PromptGenerator _promptGenerator;
    public string _userName;
    public string _mood;

    public Journal(PromptGenerator promptGenerator, string UserName, string Mood)
    {
       _promptGenerator = promptGenerator;
       _userName = UserName;
       _mood = Mood;
    }

    public void AddEntry(Entry newEntry)
    {
        // Get the current date
        string _date = DateTime.Now.ToString("dd-MM-yyyy");

         // Get a random prompt
        string _promptText = _promptGenerator.GetRandomPrompt();

        // Display prompt on a new same line
        Console.Write($"Prompt: {_promptText}\n"); 

        // Get the entry text
        string _entryText = Console.ReadLine();

        // Check if response is not empty
        if (!string.IsNullOrWhiteSpace(_entryText)) 
        {
          Entry anEntry = new Entry(_userName, _mood, _date, _promptText, _entryText);
          _entries.Add(anEntry);
        }
    }

    public void DisplayAll()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
            Console.WriteLine();
        }

            // Add a prompt message to keep the console window open
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
    }


    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            // for each entry, write a new line with the data.
            foreach (var entry in _entries)
            {
                outputFile.WriteLine($"{entry._userName}, {entry._mood}, {entry._date}, {entry._promptText}, {entry._entryText}");
            };
        }
    }

    public void LoadFromFile(string file)
    {

        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(file);
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 5)
            {
                string _userName = parts[0];
                string _mood = parts[1];
                string _date = parts[2];
                string _promptText = parts[3];
                string _entryText = parts[4];
                Entry newEntry = new Entry(_userName, _mood, _date, _promptText, _entryText);
                _entries.Add(newEntry);
            }
        }
    }
}