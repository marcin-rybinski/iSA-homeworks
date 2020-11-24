using System;
using System.IO;

namespace Ex7
{
    public class ReadTextFromFile : IReadText
    {
        public string ReadText()
        {
            Console.Write("Enter full file path: ");
            try
            {
                var path = Console.ReadLine();
                var text = File.ReadAllText(path);
                return text;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Try again and enter full file path.");
                throw;
            }
        }

    }
}