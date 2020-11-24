using System;
using System.Collections.Generic;

namespace Ex3
{
    class UserAccountsApp
    {

        private readonly DateTime _programStartTime = DateTime.Now;
        private string _selection;
        private int _usersNumber = 0;
        private readonly List<User> _usersList = new List<User>();

        public void RunProgram()
        {
            do
            {
                _selection = Menu.DisplayMenu();
                if (_selection == "I.")
                {
                    CreateUser(_usersNumber, _usersList, out _usersNumber);
                }
                else if (_selection == "II.")
                {
                    if (_usersNumber < 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine("There are no users in database.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                    }
                    else DisplayUsers(_usersList);
                }
                else if (_selection == "III.")
                {
                    DeleteUser(_usersNumber, _usersList, out _usersNumber);
                }
            } while (_selection != "IV.");

            TimeSpan programRunTime = DateTime.Now - _programStartTime;
            Console.WriteLine($"Application was running for {(int) programRunTime.TotalMinutes} minutes and " +
                              $"{programRunTime.Seconds:00} seconds, {_usersNumber} users are present");
        }
        private List<User> CreateUser(int usersNumber, List<User> usersList, out int usersNumberUpdate)
        {
            usersNumber++;
            try
            {
                GetUserData(out string newUserFirstName, out string newUserLastName, out int newUserAge);
                string newUserEmail = User.GenerateEmail(newUserFirstName, newUserLastName, usersList);
                var newUserPassword = User.GeneratePassword();
                usersList.Add(new User(newUserFirstName, newUserLastName, newUserAge, newUserEmail, newUserPassword));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                usersNumberUpdate = --usersNumber;
                return usersList;
            }

            Console.WriteLine("\nUser created.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            usersNumberUpdate = usersNumber;
            return usersList;
        }
        private static void GetUserData(out string newUserFirstName, out string newUserLastName, out int newUserAge)
        {
            Console.Write("Enter first name: ");
            newUserFirstName = Console.ReadLine();
            if (newUserFirstName.Length < 2)
            {
                throw new ArgumentException("First name has to be at least 2 characters long.");
            }
            Console.Write("Enter last name: ");
            newUserLastName = Console.ReadLine();
            if (newUserLastName.Length < 2)
            {
                throw new ArgumentException("Last name has to be at least 2 characters long.");
            }
            Console.Write("Enter age (between 18 and 65 allowed): ");
            int.TryParse(Console.ReadLine(), out newUserAge);
            if (newUserAge < 18 || newUserAge > 65)
            {
                throw new ArgumentException("Age should be between 18 and 65.");
            }
        }
        private void DisplayUsers(List<User> usersList)
        {
            var userNumber = 1;
            Console.WriteLine();
            Console.WriteLine("#".PadRight(4) + "Name".PadRight(15) + "Last Name".PadRight(20) + "E-mail".PadRight(20)
                              + "Age".PadRight(5) + "IsActive".PadRight(10) + "Password".PadRight(33));
            Console.WriteLine();
            for (int i = 0; i < 107; i++) Console.Write("#");
            Console.WriteLine();
            Console.WriteLine();
            foreach (var user in usersList)
            {
                Console.WriteLine((userNumber + ".").PadRight(4) + user.FirstName.PadRight(15)
                                  + user.LastName.PadRight(20) + user.Email.PadRight(20) + user.Age.ToString().PadRight(5)
                                  + user.IsActive.ToString().PadRight(10) + user.Password.PadRight(33));
                userNumber++;
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        private List<User> DeleteUser(int usersNumber, List<User> userList, out int usersNumberUpdate)
        {
            try
            {
                Console.WriteLine("Enter e-mail address of a user You want to delete: ");
                var email = Console.ReadLine();
                for (int i = 0; i < usersNumber; i++)
                {
                    if (email == userList[i].Email)
                    {
                        userList.RemoveAt(i);
                        usersNumberUpdate = --usersNumber;
                        Console.WriteLine();
                        Console.WriteLine("User deleted.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        return userList;
                    }

                }
                throw new ArgumentException("User not found in database.");

            }
            catch (ArgumentException e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                usersNumberUpdate = usersNumber;
                return userList;
            }
        }
    }
}