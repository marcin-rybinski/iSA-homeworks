using System;
using System.IO;

namespace Ex7
{
    public class TextProcessor
    {
        private IReadText _readingText;
        private IProcessText _processingText;
        private IWriteText _writingText;
        private string _textToProcess;
        private string _processedText;
        
        public void Run()
        {
            bool loop;

            do
            {
                try
                {
                    do
                    {
                        Console.WriteLine("How would You like to enter text?");
                        Console.WriteLine("1. Read from file.");
                        Console.WriteLine("2. Enter in console.");
                        var cursorPos = Console.CursorTop;
                        loop = int.TryParse(Console.ReadLine(), out var choice);
                        Console.SetCursorPosition(0, cursorPos);
                        Console.WriteLine(" ");
                        switch (choice)
                        {
                            case 1:
                                _readingText = new ReadTextFromFile();
                                break;
                            case 2:
                                _readingText = new ReadTextFromConsole();
                                break;
                            default:
                                Console.WriteLine("Try again...");
                                Console.WriteLine();
                                loop = false;
                                break;
                        }
                        
                    } while (loop == false);
                    
                    _textToProcess = _readingText.ReadText();
                    loop = false;
                }
                catch (FileNotFoundException)
                {
                    loop = true;
                }
            } while (loop);

            Console.WriteLine();

            do
            {
                Console.WriteLine("How would You like to process text?");
                Console.WriteLine("1. Whole text to uppercase.");
                Console.WriteLine("2. Remove all whitespaces.");
                var cursorPos = Console.CursorTop;
                loop = int.TryParse(Console.ReadLine(), out var choice);
                Console.SetCursorPosition(0, cursorPos);
                Console.WriteLine(" ");
                switch (choice)
                {
                    case 1:
                        _processingText = new TextToUppercase();
                        break;
                    case 2:
                        _processingText = new RemovingWhitespaces();
                        break;
                    default:
                        Console.WriteLine("Try again...");
                        Console.WriteLine();
                        loop = false;
                        break;
                }

            } while (loop == false);

            _processedText = _processingText.ProcessText(_textToProcess);

            do
            {
                Console.WriteLine("How would You like to write text?");
                Console.WriteLine("1. Write to file.");
                Console.WriteLine("2. Write to console.");
                var cursorPos = Console.CursorTop;
                loop = int.TryParse(Console.ReadLine(), out var choice);
                Console.SetCursorPosition(0, cursorPos);
                Console.WriteLine(" ");
                switch (choice)
                {
                    case 1:
                        _writingText = new WriteTextToFile();
                        break;
                    case 2:
                        _writingText = new WriteTextToConsole();
                        break;
                    default:
                        Console.WriteLine("Try again...");
                        Console.WriteLine();
                        loop = false;
                        break;
                }

            } while (loop == false);

            _writingText.WriteText(_processedText);
            Console.WriteLine();

            Console.WriteLine("The End.");
        }
    }
}
