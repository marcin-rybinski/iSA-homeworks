using System;
using System.Collections.Generic;

namespace Ex3
{
    class Menu
    {
               
        private static readonly string[,] _menu =
        {
            {"I.", "Create new user"},
            {"II.", "Display users"},
            {"III.", "Delete user"},
            {"IV.", "Exit program"},
        };

        private static int _currentLine = 0;
        
        public static string DisplayMenu()
        {
            Console.Clear();
            for (int i = 0; i < _menu.GetLength(0); i++)
            {
                for (int j = 0; j < _menu.GetLength(1); j++)
                {
                    if (i == _currentLine)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write(_menu[i, j].PadRight(6, ' '));
                    Console.ResetColor();
                }
                Console.WriteLine();
            }

            ConsoleKeyInfo keyPressed = Console.ReadKey();

            if (keyPressed.Key == ConsoleKey.DownArrow)
            {
                if (_currentLine == _menu.GetLength(0) - 1)
                {
                    _currentLine = 0;
                }
                else
                {
                    _currentLine++;
                }
            }
            else if (keyPressed.Key == ConsoleKey.UpArrow)
            {
                if (_currentLine <= 0)
                {
                    _currentLine = _menu.GetLength(0) - 1;
                }
                else
                {
                    _currentLine--;
                }
            }
            else if (keyPressed.Key == ConsoleKey.Enter)
            {
                return _menu[_currentLine,0];
            }

            return "";
        }
    }
}