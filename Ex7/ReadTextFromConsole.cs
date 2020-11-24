using System;

namespace Ex7
{
    public class ReadTextFromConsole : IReadText
    {
        public string ReadText()
        {
            Console.WriteLine("Type some text to process:");
            return Console.ReadLine();
        }
    }
}