using System;

// To exceed the requirements, I implemented a feature to keep a log of how many times each activity was performed. 
// Each time an activity is completed, the log is updated. The user can also view the activity log and save it to a file. 

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Mindfulness Program!");
        ActivityLog activityLog = new ActivityLog(); 

        while (true)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. View activity log");
            Console.WriteLine("5. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", 30);
                    breathingActivity.Run();
                    activityLog.AddActivity("Breathing");
                    break;

                case "2":
                    ReflectingActivity reflectingActivity = new ReflectingActivity("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", 30);
                    reflectingActivity.Run();
                    activityLog.AddActivity("Reflecting");
                    break;

                case "3":
                    ListingActivity listingActivity = new ListingActivity("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 20);
                    listingActivity.Run();
                    activityLog.AddActivity("Listing");
                    break;

                case "4":
                    activityLog.DisplayLog();
                    break;

                case "5":
                    Console.WriteLine();
                    Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
                    activityLog.SaveLogToFile("activity_log.txt");
                    return;    

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }
    static int ReadDuration(string activityName)
    {
        Console.Write($"Enter duration for {activityName} activity in seconds: ");
        return int.Parse(Console.ReadLine());
    }
}
