using System;

// Inheritance with Event Planning
// In this program, I was able to Write a program that has a base Event class along with derived classes for each type of event. 
// These classes contained the necessary data and provided methods to return strings for each of the messages the company desires. 
// Below is the output of one of the events: 

// Outdoor Gathering:
// Standard Details:
// Event Title: Picnic in the Park
// Description: Enjoy a day outdoors with friends and family
// Date: 6/20/2024
// Time: 11:00:00
// Address: 789 Oak St, Somewhere, TX, USA

// Full Details:
// Event Title: Picnic in the Park
// Description: Enjoy a day outdoors with friends and family
// Date: 6/20/2024
// Time: 11:00:00
// Address: 789 Oak St, Somewhere, TX, USA
// Type of Event: Outdoor Gathering
// Weather Forecast: Sunny with a chance of showers

// Short Description:
// Type of Event: Outdoor Gathering
// Event Title: Picnic in the Park
// Date: 6/20/2024

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Lecture lecture = new Lecture("Tech Talk", "Learn about the latest technologies", new DateTime(2024, 4, 10), new TimeSpan(14, 0, 0), address1, "John Doe", 50);

        Address address2 = new Address("456 Elm St", "AnotherTown", "NY", "USA");
        Reception reception = new Reception("Networking Event", "Meet professionals from various industries", new DateTime(2024, 5, 15), new TimeSpan(18, 30, 0), address2, "rsvp@example.com");

        Address address3 = new Address("789 Oak St", "Somewhere", "TX", "USA");
        OutdoorGathering outdoorGathering = new OutdoorGathering("Picnic in the Park", "Enjoy a day outdoors with friends and family", new DateTime(2024, 6, 20), new TimeSpan(11, 0, 0), address3, "Sunny with a chance of showers");

        Console.WriteLine("Lecture:");
        Console.WriteLine("Standard Details:");
        Console.WriteLine(lecture.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine("Full Details:");
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine("Short Description:");
        Console.WriteLine(lecture.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine("Reception:");
        Console.WriteLine("Standard Details:");
        Console.WriteLine(reception.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine("Full Details:");
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine("Short Description:");
        Console.WriteLine(reception.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine("Outdoor Gathering:");
        Console.WriteLine("Standard Details:");
        Console.WriteLine(outdoorGathering.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine("Full Details:");
        Console.WriteLine(outdoorGathering.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine("Short Description:");
        Console.WriteLine(outdoorGathering.GetShortDescription());
    }
}