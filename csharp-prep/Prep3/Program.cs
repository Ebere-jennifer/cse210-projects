using System;

class Program
{
    static void Main(string[] args)
    {
        // For Core Requirement 1 and 2 whwre the user has to guess a number
        // Console.WriteLine("What is the magic number? ");
        // int magicNumber = int.Parse(Console.ReadLine());

        // For Core Requirement 3 where we generate a random number
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;

        int totalGuesses = 0;


        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            totalGuesses++;

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine($"Congratulations! You guessed it! ");
                Console.WriteLine($"It took you {totalGuesses} guesses.");
                Console.Write("Do you want to play again? (yes/no): ");

                string playAgain = Console.ReadLine().ToLower();

                if (playAgain != "yes")
                {
                    Console.WriteLine("Thank you for playing. Goodbye! ");
                    return;
                }
                else 
                {
                    totalGuesses = 0;
                    magicNumber = randomGenerator.Next(1, 101);
                }
            }
        }

    }
}