using ClassRegister.Models;
using System;

namespace ClassRegister.HelperMethods
{
    internal class HelperMethods
    {
        public bool AddAnotherStudentDecision()
        {
            bool addAnotherStudent;
            do
            {
                Console.WriteLine("Add another student? (y/n)");
                var addAnother = Console.ReadKey();
                Console.WriteLine();
                if (addAnother.Key != ConsoleKey.Y)
                {
                    if (addAnother.Key != ConsoleKey.N) continue;
                    addAnotherStudent = false;
                    break;
                }

                addAnotherStudent = true;
                break;
            } while (true);

            return addAnotherStudent;
        }

        public Person GetPersonData(string personType)
        {
            Console.WriteLine();
            var newPerson = new Person();
            Console.Write($"{personType} name:");
            newPerson.FirstName = GetStringFromConsole();
            Console.Write($"{personType} surname:");
            newPerson.Surname = GetStringFromConsole();
            Console.WriteLine($"{personType}'s address");
            newPerson.Address = new Address();
            Console.Write("Street:");
            newPerson.Address.Street = GetStringFromConsole();
            Console.Write("City:");
            newPerson.Address.City = GetStringFromConsole();
            Console.Write("Zipcode:");
            newPerson.Address.Zipcode = GetStringFromConsole();
            return newPerson;
        }

        public string GetStringFromConsole()
        {
            do
            {
                var newString = Console.ReadLine();
                if (!string.IsNullOrEmpty(newString))
                {
                    if (newString.Length >= 3) return newString;
                }
                Console.WriteLine("Please enter Your value (minimum 3 characters).");
            } while (true);
        }

        public int GetANumberFromConsole()
        {
            do
            {
                if (int.TryParse(Console.ReadLine(), out var stringGiven))
                    return stringGiven;
                Console.WriteLine("You didn't give a valid number.");
            } while (true);
        }
    }
}