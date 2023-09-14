using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        
        static bool cont = true;
        static List<string> activities = new List<string>() 
        { "Movies", "Paintball", "Bowling", "Lazer Tag", "Video Games", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
        {
            Random rng = new Random();

            Console.WriteLine("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            string userInput1 = Console.ReadLine().ToLower();
            
            bool cont;

            if (userInput1 == "yes")
            {
                cont = true;
            }
            else
            {
                cont = false;
            }

            Console.WriteLine();
            Console.WriteLine("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("What is your age? ");
            int userAge = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Would you like to see the current list of activities? Sure/No thanks: ");

            bool seeList = (Console.ReadLine().ToLower() == "sure") ? true : false;

            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.WriteLine($"{activity} ");
                    Thread.Sleep(100);
                }

                Console.WriteLine();
                Console.WriteLine("Would you like to add any activities before we generate one? yes/no: ");

                bool addToList = (Console.ReadLine().ToLower() == "yes") ? true : false;

                Console.WriteLine();

                while (addToList)
                {
                    Console.WriteLine("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);

                    foreach (string activity in activities)
                    {
                        Console.WriteLine($"{activity} ");
                        Thread.Sleep(100);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    addToList = (Console.ReadLine().ToLower() == "yes") ? true : false;
                }
            }

            while (cont)
            {
                Console.WriteLine("Connecting to the database");

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(". ");
                    Thread.Sleep(250);
                }

                Console.WriteLine();
                Console.WriteLine("Choosing your random activity");

                for (int i = 0; i < 9; i++)
                {
                    Console.WriteLine(". ");
                    Thread.Sleep(250);
                }

                Console.WriteLine();


                int randomNumber = rng.Next(0, activities.Count);
                string randomActivity = activities[randomNumber];

                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    
                    Console.WriteLine($"Oh no! Looks like you are too young to do Wine Tasting!");
                    Console.WriteLine("Pick something else!");
                    
                    activities.Remove(randomActivity);

                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                }
                Console.WriteLine($"Ah got it! {userName}, " +
                    $"your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();

                cont = (Console.ReadLine().ToLower() == "redo") ? true : false;
            }
        }
    }
}