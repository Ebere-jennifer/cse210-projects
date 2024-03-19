using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a base "Assignment" object
        Assignment a1 = new Assignment("Jennifer Ebere", "Multiplication");
        Console.WriteLine(a1.GetSummary());

        // Create the MathAssignment class
        MathAssignment a2 = new MathAssignment("Jennifer Ebere", "Fractions", "7.3", "8-19");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        // Create the WritingAssignment class
        WritingAssignment a3 = new WritingAssignment("Jennifer Ebere", "European History", "The Causes of World War II");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}