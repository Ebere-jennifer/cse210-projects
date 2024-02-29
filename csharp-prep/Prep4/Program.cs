using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List <int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Enter a number: ");
            string userResponse  = Console.ReadLine();
            userNumber = int.Parse(userResponse);

            //If user number is not equal to zero
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }
        
       // 1. Compute the sum, or total, of the numbers in the list.
       int sum = 0;
       foreach (int number in numbers)
       {
        sum += number;
       }

       Console.WriteLine($"The sum is: {sum}");

       // 2. Compute the average of the numbers in the list.
       float average = ((float)sum) / numbers.Count;
       Console.WriteLine($"The average is: {average}");

       // 3. Find the maximum, or largest, number in the list
       int max = numbers[0];

       foreach (int number in numbers)
       {
        if (number > max)
        {
            // if this number is greater than the max, we have found the new max!
            max = number;
        }
       }

       Console.WriteLine($"The maximum or largest number is: {max}");
    }
}