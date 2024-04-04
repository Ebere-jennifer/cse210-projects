using System;

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
        Console.WriteLine(lecture.GetStandardDetails());
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine(lecture.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine("Reception:");
        Console.WriteLine(reception.GetStandardDetails());
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine(reception.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine("Outdoor Gathering:");
        Console.WriteLine(outdoorGathering.GetStandardDetails());
        Console.WriteLine(outdoorGathering.GetFullDetails());
        Console.WriteLine(outdoorGathering.GetShortDescription());
    }
}
