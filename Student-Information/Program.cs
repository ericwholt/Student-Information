using System;
using System.Collections.Generic;

namespace Student_Information
{
    class Program
    {
        public static List<string> Names = new List<string>();
        public static List<string> HomeTowns = new List<string>();
        public static List<string> FavoriteFoods = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our C# class. Which student would you like to learn more about?");
            AddStudent("Eric Holt", "Italian", "Paragould");
            AddStudent("Miguel", "BBQ Ribs", "Chicago, IL.");
            AddStudent("Andre Otte", "Veggie Burgers", "St Catherines, Ontario");
            GetInput();
        }

        public static void AddStudent(string name, string favoriteFood, string homeTown)
        {
            Names.Add(name);
            HomeTowns.Add(homeTown);
            FavoriteFoods.Add(favoriteFood);
        }

        public static string GetStudent(int index)
        {
            //Write a static method named GetStudent().
            //This method will take in an int index and return a string with all the info about a student: name, favorite food, and hometown.
            //Format it as you please, as long as all the data is in there. - 1pt
            //If GetStudent receives an index not attached to student, the method should throw an IndexOutOfRange Exception.
            //Catch the exception and return a string saying “Student not found, try another index” -1pt for throwing exception, then catching and returning
            try
            {
                if (index > Names.Count - 1 || index > HomeTowns.Count - 1 || index > FavoriteFoods.Count - 1)
                {
                    throw new IndexOutOfRangeException("Student not found, try another index");
                }
                else
                {
                    return $"{Names[index]}";
                }
            }
            catch (IndexOutOfRangeException e)
            {
                return e.Message;
            }
        }

        public static void PrintMenu()
        {
            for (int i = 0; i < Names.Count; i++)
            {
                Console.WriteLine($"{i}) - {Names[i]}");
            }
        }

        public static void GetInput()
        {

            bool validUserInput = false;
            int index = 0;
            string userInput;

            while (!validUserInput)
            {
                PrintMenu();
                Console.WriteLine("Please select index of the student you want to learn about");
                userInput = Console.ReadLine();

                //Convert to an int - passint to get student or throw formatException
                try
                {
                    index = int.Parse(userInput);
                    if(index < Names.Count)
                    {
                        validUserInput = true;
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("That student does not exist.  Please try again.");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Not a valid number please try again.");
                }
                catch(IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            string student = GetStudent(index);
            Console.WriteLine($"Student {index} is {student}. What would you like to know about {student}? (enter or “hometown” or “favorite food”)");
            LearnMore(index);
        }

        public static void LearnMore(int index)
        {
            string name = Names[index];
            string food = name + "'s favorite food is " + FavoriteFoods[index] + ".";
            string homeTown = name + "'s home town is " + HomeTowns[index] + ".";
            bool validInput = false;
            //Console.WriteLine($"What would you like to know about {name}? (enter “hometown” or “favorite food”)");


            while (!validInput)
            {
                
                string userInput = Console.ReadLine();
                bool validAnswer = false;

                if (userInput.ToLower() == "hometown")
                {
                    string studentHomeTown = homeTown + " Would you like to know more? (enter “yes” or “no”): ";
                    Console.WriteLine(studentHomeTown);
                    while (!validAnswer)
                    {
                        string userAnswer = Console.ReadLine();
                        if (userAnswer.ToLower() == "yes" || userAnswer.ToLower() == "y" )
                        {
                            Console.WriteLine($"Student {index} is {name}. What would you like to know about {name}? (enter or “hometown” or “favorite food”)");
                            validAnswer = true;
                        }
                        else if(userAnswer.ToLower() == "no" || userAnswer.ToLower() == "n")
                        {
                            validAnswer = true;
                            validInput = true;
                        }
                    }
                }
                else if (userInput.ToLower() == "favorite food")
                {
                    string studentFood = food + " Would you like to know more? (enter “yes” or “no”): ";
                    Console.WriteLine(studentFood);
                    while (!validAnswer)
                    {
                        string userAnswer = Console.ReadLine();
                        if (userAnswer.ToLower() == "yes" || userAnswer.ToLower() == "y")
                        {
                            Console.WriteLine($"Student {index} is {name}. What would you like to know about {name}? (enter or “hometown” or “favorite food”)");
                            validAnswer = true;
                        }
                        else if (userAnswer.ToLower() == "no" || userAnswer.ToLower() == "n")
                        {
                            validAnswer = true;
                            validInput = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("That data does not exist.  Please try again.");

                }
                
            }
            validInput = false;
        }
    }
}
