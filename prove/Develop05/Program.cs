using System;

// To exceed the requirements, I implemented user input for name, age, and gender by modifying the Start() method in the 
// GoalManager class to prompt the user to enter their information. I also created a NotificationManager class responsible 
// for sending reminder messages. The SendReminder method in this class simply prints the reminder message to the console. 
// In the Main method, various reminder messages are simulated to demonstrate the functionality. With this setup, each 
// reminder message is sent at an appropriate point in the program's execution

class Program
{
    private static List<Goal> _goals = new List<Goal>();
    
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();

        // Create a NotificationManager instance
        NotificationManager notificationManager = new NotificationManager();

        bool quit = false;

        while (!quit)
        {
            // Simulate sending a reminder message to stay committed and persistent
            notificationManager.SendReminder("Success comes from persistence and commitment. Keep pushing forward, even when it gets tough!");
            goalManager.DisplayPlayerInfo(); // Access _score through GoalManager
            Console.WriteLine("------------------------");

            // Send a reminder message to embrace challenges as opportunities for growth
            notificationManager.SendReminder("Remember, challenges are opportunities for growth. Embrace them and learn from every experience!");

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals ");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    goalManager.CreateGoal();
                    // Send a reminder message after creating a new goal
                    notificationManager.SendReminder("Don't forget to complete your goals!");
                    Console.WriteLine("------------------------");
                    break;
                case "2":
                    goalManager.ListGoalDetails();
                    // Send a reminder message after listing goals
                    notificationManager.SendReminder("Review your goals and stay focused!");
                    Console.WriteLine("------------------------");
                    break;
                case "3":
                    goalManager.SaveGoals();
                    // Send a milestone celebration message after saving goals
                    notificationManager.SendReminder("Congratulations on reaching a milestone!");
                    Console.WriteLine("------------------------");
                    break;
                case "4":
                    goalManager.LoadGoals();
                    // Send a reminder message to reflect on achievements
                    notificationManager.SendReminder("Take a moment to reflect on what you've accomplished so far. You're doing great!");
                    Console.WriteLine("------------------------");
                    break;
                case "5":
                    goalManager.RecordEvent();
                    // Send a generic notification message after recording an event
                    notificationManager.SendReminder("Stay motivated and keep striving for success!");
                    Console.WriteLine("------------------------");
                    break;
                case "6":
                    quit = true;
                    // Send a reminder message after quitting the program
                    notificationManager.SendReminder("Remember to come back and continue your journey!");
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    // Send a reminder message after an invalid menu choice
                    notificationManager.SendReminder("Oops! It seems like you made an invalid choice. Try again!");
                    break;
            }

            Console.WriteLine();
        }
    }
}