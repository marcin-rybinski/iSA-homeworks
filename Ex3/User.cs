using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace Ex3
{
    class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; }
        public string Password { get; }
        public bool IsActive { get; set; }

        
        public User(string firstName, string lastName, int age, string email, string password)
        {

            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;
            IsActive = true;
            Password = password;
        }
        
        public static string GenerateEmail(string firstName, string lastName, List<User> usersList)
        {
            string email = $"{char.ToLower(firstName[0])}{char.ToLower(firstName[1])}{char.ToLower(lastName[0])}{char.ToLower(lastName[1])}@example.com";
            int emailNumber = 1;
            foreach (var user in usersList)
            {
                if (email == user.Email)
                {
                    email = $"{char.ToLower(firstName[0])}{char.ToLower(firstName[1])}{char.ToLower(lastName[0])}{char.ToLower(lastName[1])}{emailNumber}@example.com";
                    emailNumber++;
                }
            }
            return email;
        }

        public static string GeneratePassword()
        {
            var password = RandomStringGenerator.GenerateRandomString(16, 32);
            return password;
        }

    }
}
