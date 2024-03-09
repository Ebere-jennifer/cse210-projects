using System;

class Program
{
    static void Main(string[] args)
    {
        PromptGenerator _promptGenerator = new PromptGenerator();

        // Prompt user for their name
        Console.Write("What is your name? ");
        string _userName = Console.ReadLine();
        
        // Prompt user for their mood
        Console.Write("What is your mood for today: ");
        string _mood = Console.ReadLine();

        // Get the current date
        string _date = DateTime.Now.ToString("dd-MM-yyyy");

        // Get a random prompt
        string _promptText = _promptGenerator.GetRandomPrompt();

        // Create a new instance of Journal with the provided parameters
        Journal journal = new Journal(_promptGenerator, _userName, _mood);

        while (true)
        {
            Console.WriteLine($"\n**** Welcome to the Journal Program! ****\n");
            Console.WriteLine("Please select one of the following choices?");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    journal.AddEntry(new Entry(_userName, _mood, _date, _promptText, ""));
                    break;
                case 2:
                    journal.DisplayAll();
                    break;
                case 3:
                    Console.WriteLine("What is the filename? ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;
                case 4:
                    Console.WriteLine("What is the filename? ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}