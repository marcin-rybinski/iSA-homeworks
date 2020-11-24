using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Ex2
{
    class Timer
    {
        private Dictionary<int, string> options = new Dictionary<int, string>()
        {
            {1, "10 sekund"},
            {2, "30 sekund"},
            {3, "1 minuta"},
            {4, "3 minuty"},
            {5, "Inny czas"}
        };

        public void DisplayInterface()
        {

            Console.WriteLine("Witaj w aplikacji 'Timer'!\n");
            Console.WriteLine("Wybierz czas odliczania: \n");
            foreach (KeyValuePair<int, string> option in options)
            {
                Console.WriteLine($"{option.Key} - {option.Value}");
            }

            Console.WriteLine();
            Console.WriteLine("Aby zakończyć program wciśnij ESC.\n");

        }

        public int GetUserChoice()
        {
            bool wrongInput;
            int userChoice;
            
            do
            {
                ConsoleKeyInfo userKey = Console.ReadKey();
                if (userKey.Key == ConsoleKey.Escape) return 6;
                else if (int.TryParse(userKey.KeyChar.ToString(), out userChoice) == false)
                {
                    Console.WriteLine();
                    Console.Write("Proszę dokonać poprawnego wyboru (1, 2, 3, 4 lub 5): \n\n");
                    wrongInput = true;
                }
                else if (userChoice < 1 || userChoice > 5)
                {
                    Console.WriteLine();
                    Console.Write("Proszę dokonać poprawnego wyboru (1, 2, 3, 4 lub 5): \n\n");
                    wrongInput = true;
                }
                else wrongInput = false;

            } while (wrongInput);

            
            Console.SetCursorPosition(Console.CursorLeft -1, Console.CursorTop);
            Console.WriteLine($"Wybrano: {options.Keys.ElementAt(userChoice -1)} - {options[userChoice]}");
            return userChoice;
        }

        private void GetUserTime(out int userMinutesChoice, out int userSecondsChoice)
        {
            bool wrongInput = false;
            do
            {
                Console.WriteLine();
                Console.Write("Podaj liczbę minut: ");
                if (int.TryParse(Console.ReadLine(), out userMinutesChoice) == false)
                {
                    wrongInput = true;
                }
                else
                {
                    wrongInput = false;
                }
            } while (wrongInput);

            do
            {
                Console.Write("Podaj liczbę sekund: ");
                if (int.TryParse(Console.ReadLine(), out userSecondsChoice) == false)
                {
                    wrongInput = true;
                }
                else if (userSecondsChoice > 59)
                {
                    Console.WriteLine("Liczba sekund nie może być większa niż 59.");
                    wrongInput = true;
                }
                else
                {
                    wrongInput = false;
                }
            } while (wrongInput);

        }

        private void TimerWorking(int userMinutes, int userSeconds)
        {
            Console.WriteLine();
            Console.WriteLine("Naciśnij dowolny klawisz, aby wystartować timer...");
            Console.ReadKey();
            Console.WriteLine();
            if (userMinutes == 0)
            {
                for (int k = userSeconds; k >= 1; k--)
                {
                    if (k >= 10)
                    {
                        
                        Console.WriteLine($"00:{k}");
                        Thread.Sleep(1000);
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                    }
                    else
                    {
                        Console.WriteLine($"00:0{k}");
                        Thread.Sleep(1000);
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                    }
                }
                Console.WriteLine("00:00");
            }
            else
            {
                for (int k = userSeconds; k >= 0; k--)
                {
                    if (k >= 10)
                    {
                        if (userMinutes >= 10)
                        {
                            Console.WriteLine($"{userMinutes}:{k}");
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                        }
                        else
                        {
                            Console.WriteLine($"0{userMinutes}:{k}");
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                        }
                    }
                    else
                    {
                        if (userMinutes >= 10)
                        {
                            Console.WriteLine($"{userMinutes}:0{k}");
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                        }
                        else
                        {
                            Console.WriteLine($"0{userMinutes}:0{k}");
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                        }
                    }
                }
                userMinutes--;

                while (userMinutes >= 10)
                {
                    for (int k = 59; k >= 0; k--)
                    {
                        if (k >= 10)
                        {
                            Console.WriteLine($"{userMinutes}:{k}");
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                        }
                        else
                        {
                            Console.WriteLine($"{userMinutes}:0{k}");
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                        }
                    }

                    userMinutes--;
                }

                while (userMinutes > 0)
                {
                    for (int k = 59; k >= 0; k--)
                    {
                        if (k >= 10)
                        {
                            Console.WriteLine($"0{userMinutes}:{k}");
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                        }
                        else
                        {
                            Console.WriteLine($"0{userMinutes}:0{k}");
                            Thread.Sleep(1000);
                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                        }
                    }

                    userMinutes--;
                }

                for (int k = 59; k >= 1; k--)
                {
                    if (k >= 10)
                    {
                        Console.WriteLine($"0{userMinutes}:{k}");
                        Thread.Sleep(1000);
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                    }
                    else
                    {
                        Console.WriteLine($"0{userMinutes}:0{k}");
                        Thread.Sleep(1000);
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                    }
                }

                Console.WriteLine("00:00");
            }
            
        }

        public void RunTimer(int presetChoice)
        {
            switch (presetChoice)
            {
                case 1:
                    TimerWorking(0, 10);
                    Beep();
                    break;
                case 2:
                    TimerWorking(0, 30);
                    Beep();
                    break;
                case 3:
                    TimerWorking(1, 0);
                    Beep();
                    break;
                case 4:
                    TimerWorking(3, 0);
                    Beep();
                    break;
                case 5:
                    GetUserTime(out int userMinutes, out int userSeconds);
                    TimerWorking(userMinutes, userSeconds);
                    Beep();
                    break;
                default:
                    return;
            }
        }
        private void Beep()
        {
            Console.WriteLine("\nCzas minął!");
            for (int i = 0; i < 3; i++)
            {
                Console.Beep(2300, 600);
                Console.Beep(1700, 300);
                Console.Beep(2300, 600);
                Thread.Sleep(600);
            }
        }

    }
}