using System;

namespace Ex7
{
    public class WriteTextToConsole : IWriteText
    {
        public void WriteText(string text)
        {
            Console.WriteLine(text);
        }
    }
}