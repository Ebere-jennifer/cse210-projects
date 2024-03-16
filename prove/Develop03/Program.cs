using System;

//
// To demonstrate creativity and surpass expectations, I added a naming to the code and I enhanced my program to operate with a 
// diverse library of scriptures rather than just one. It randomly selects scriptures to present to the user, adding variety
// and depth to the experience.

using System.Collections.Generic;

namespace ScriptureMemorizationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Scripture Memorization App!");
            Console.WriteLine();
            Console.WriteLine("Press Enter to start or type 'quit' to exit: ");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                return;

            // Create a library of scriptures
            List<Scripture> scriptureLibrary = new List<Scripture>();
            InitializeScriptureLibrary(scriptureLibrary);

            // Select a random scripture from the library
            Random rand = new Random();
            int index = rand.Next(scriptureLibrary.Count);
            Scripture selectedScripture = scriptureLibrary[index];

            // Display the full scripture
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());

            // Main loop to present scriptures to the user
            while (!selectedScripture.IsCompletelyHidden())
            {
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue  or type 'quit' to finish: ");
                input = Console.ReadLine();
                if (input.ToLower() == "quit")
                    return;

                // Hide random words in the scripture
                selectedScripture.HideRandomWords(3); // Hide 3 random words

                // Display the scripture with hidden words
                Console.Clear();
                Console.WriteLine(selectedScripture.GetDisplayText());    
            }
            Console.WriteLine();    
            Console.WriteLine("All Words are hidden. End of the program.");
        }
            
        // Function to initialize the scripture library
        static void InitializeScriptureLibrary(List<Scripture> library)
        {
            // Add scriptures to the library
            Reference reference1 = new Reference("John", 3, 16);
            Scripture scripture1 = new Scripture(reference1, "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");
            library.Add(scripture1);

            Reference reference2 = new Reference("Psalms", 23, 1);
            Scripture scripture2 = new Scripture(reference2, "The LORD is my shepherd; I shall not want.");
            library.Add(scripture2);

            Reference reference3 = new Reference("Proverbs", 3, 5, 6);
            Scripture scripture3 = new Scripture(reference3, "Trust in the LORD with all thine heart and lean not unto thine own understanding; in all thy ways acknowledge him, and he shall direct thy paths.");
            library.Add(scripture3);

            Reference reference4 = new Reference("Matthew", 7, 7, 8);
            Scripture scripture4 = new Scripture(reference4, "Ask, and it shall be given you; seek, and ye shall find; knock, and it shall be opened unto you: For every one that asketh receiveth; and he that seeketh findeth; and to him that knocketh it shall be opened.");
            library.Add(scripture4);

            Reference reference5 = new Reference("1 Corinthians", 10, 13);
            Scripture scripture5 = new Scripture(reference5, "There hath no temptation taken you but such as is common to man: but God is faithful, who will not suffer you to be tempted above that ye are able; but will with the temptation also make a way to escape, that ye may be able to bear it.");
            library.Add(scripture5);

            Reference reference6 = new Reference("1 John", 1, 9);
            Scripture scripture6 = new Scripture(reference6, "If we confess our sins, he is faithful and just to forgive us our sins, and to cleanse us from all unrighteousness.");
            library.Add(scripture6);

            Reference reference7 = new Reference("Moroni", 10, 4, 5);
            Scripture scripture7 = new Scripture(reference7, "And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, in the name of Christ, if these things are not true; and if ye shall ask with a sincere heart, with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost. And by the power of the Holy Ghost ye may know the truth of all things.");
            library.Add(scripture7);
        }
                
    }   
}