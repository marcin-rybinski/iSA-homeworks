using System;

namespace Ex3
{
    class RandomStringGenerator
    {
        public static string GenerateRandomString(int maxVal, int minVal)
        {
            string newRandomString = "";
            Random rnd = new Random();
            var stringLength = rnd.Next(maxVal, minVal);
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            for (int i = 0; i < stringLength; i++)
            {
                newRandomString += chars[rnd.Next(chars.Length)];
            }

            return newRandomString;
        }
    }
}