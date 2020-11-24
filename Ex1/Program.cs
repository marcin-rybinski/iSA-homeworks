using System;
using System.Dynamic;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Channels;
using Microsoft.VisualBasic.CompilerServices;
using Console = System.Console;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is a Simple Calculator Program.\n\n" +
                              "Enter first value, an operator and a second value to perform an operation.\n\n" +
                              "If You want to add a number to MEMORY or read a number from MEMORY press 'M'.\n\n" +
                              "If You want to exit the program type 'exit'.");
            int memory = 0;
            var decision = "Y";
            while (decision.ToUpper() == "Y")
            {
                var firstValueOutSignal = false;
                int firstValueInt;
                do
                {
                    Console.WriteLine();
                    Console.Write("Enter first value: ");
                    var firstValue = Console.ReadLine();
                    if (firstValue.ToLower() == "exit")
                    {
                        if (memory == 0)
                        {
                            Console.WriteLine("\nWARNING! The value stored in MEMORY is 0! Do You want to leave it that way?");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Do You really want to quit? Press ESC to confirm.\n" +
                                          "Press any other key to continue program.");
                        ConsoleKeyInfo breakDecision = Console.ReadKey();
                        if (breakDecision.Key == ConsoleKey.Escape) return;
                    }
                    if (int.TryParse(firstValue, out firstValueInt))
                    {                                   
                        firstValueOutSignal = true;
                    }
                    else if (firstValue.ToUpper() == "M")
                    {
                        var outSignal = false;
                        do
                        {
                            Console.WriteLine();
                            Console.WriteLine("Would like to add a number to MEMORY or read a number that is stored in MEMORY? \n" +
                                              "Press A to enter and R to read.");
                            var memDecision = Console.ReadLine();
                            if (memDecision.ToLower() == "exit")
                            {
                                if (memory == 0)
                                {
                                    Console.WriteLine("\nWARNING! The value stored in MEMORY is 0! Do You want to leave it that way?");
                                }

                                Console.WriteLine();
                                Console.WriteLine("Do You really want to quit? Press ESC to confirm.\n" +
                                                  "Press any other key to continue program.");
                                ConsoleKeyInfo breakDecision = Console.ReadKey();
                                if (breakDecision.Key == ConsoleKey.Escape) return;
                            }
                            else if (memDecision.ToUpper() == "A")
                            {
                                var innerOutSignal = false;
                                do
                                {
                                    Console.WriteLine();
                                    Console.Write("Please enter a number to add to MEMORY: ");
                                    var numberToMemory = Console.ReadLine();
                                    if (numberToMemory.ToLower() == "exit")
                                    {
                                        if (memory == 0)
                                        {
                                            Console.WriteLine("\nWARNING! The value stored in MEMORY is 0! Do You want to leave it that way?");
                                        }

                                        Console.WriteLine();
                                        Console.WriteLine("Do You really want to quit? Press ESC to confirm.\n" +
                                                          "Press any other key to continue program.");
                                        ConsoleKeyInfo breakDecision = Console.ReadKey();
                                        if (breakDecision.Key == ConsoleKey.Escape) return;
                                    }
                                    if (int.TryParse(numberToMemory, out memory))
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine($"You have added {memory} to MEMORY.");
                                        innerOutSignal = true;
                                        outSignal = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please enter a valid number to add to memory.");
                                    }
                                } while (innerOutSignal == false);
                            }
                            else if (memDecision.ToUpper() == "R")
                            {
                                Console.WriteLine();
                                Console.WriteLine($"The number stored in MEMORY is: {memory}");
                                outSignal = true;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid answer.");
                            }
                        } while (outSignal == false);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please enter valid first value.");
                    }
                } while (firstValueOutSignal == false);


                var operatorSelectOutSignal = false;
                string operatorSelected;
                do
                {
                    Console.WriteLine();
                    Console.Write("Select an operation to perform ( + - * / % ): ");
                    var operatorSelect = Console.ReadLine();
                    if (operatorSelect.ToLower() == "exit")
                    {
                        if (memory == 0)
                        {
                            Console.WriteLine("WARNING! The value stored in MEMORY is 0! Do You want to leave it that way?");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Do You really want to quit? Press ESC to confirm.\n" +
                                          "Press any other key to continue program.");
                        ConsoleKeyInfo breakDecision = Console.ReadKey();
                        if (breakDecision.Key == ConsoleKey.Escape) return;
                    }
                    if (operatorSelect == "+" || operatorSelect == "-" || operatorSelect == "*" || operatorSelect == "/" || operatorSelect == "%")
                    {
                        operatorSelectOutSignal = true;
                    }
                    else if (operatorSelect.ToUpper() == "M")
                    {
                        var outSignal = false;
                        do
                        {
                            Console.WriteLine();
                            Console.WriteLine("Would like to add a number to MEMORY or read a number that is stored in MEMORY? \n" +
                                              "Press A to enter and R to read.");
                            var memDecision = Console.ReadLine();
                            if (memDecision.ToLower() == "exit")
                            {
                                if (memory == 0)
                                {
                                    Console.WriteLine("\nWARNING! The value stored in MEMORY is 0! Do You want to leave it that way?");
                                }

                                Console.WriteLine();
                                Console.WriteLine("Do You really want to quit? Press ESC to confirm.\n" +
                                                  "Press any other key to continue program.");
                                ConsoleKeyInfo breakDecision = Console.ReadKey();
                                if (breakDecision.Key == ConsoleKey.Escape) return;
                            }
                            else if (memDecision.ToUpper() == "A")
                            {
                                var innerOutSignal = false;
                                do
                                {
                                    Console.WriteLine();
                                    Console.Write("Please enter a number to add to MEMORY: ");
                                    var numberToMemory = Console.ReadLine();
                                    if (numberToMemory.ToLower() == "exit")
                                    {
                                        if (memory == 0)
                                        {
                                            Console.WriteLine("\nWARNING! The value stored in MEMORY is 0! Do You want to leave it that way?");
                                        }

                                        Console.WriteLine();
                                        Console.WriteLine("Do You really want to quit? Press ESC to confirm.\n" +
                                                          "Press any other key to continue program.");
                                        ConsoleKeyInfo breakDecision = Console.ReadKey();
                                        if (breakDecision.Key == ConsoleKey.Escape) return;
                                    }
                                    if (int.TryParse(numberToMemory, out memory))
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine($"You have added {memory} to MEMORY.");
                                        innerOutSignal = true;
                                        outSignal = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please enter a valid number to add to memory.");
                                    }
                                } while (innerOutSignal == false);
                            }
                            else if (memDecision.ToUpper() == "R")
                            {
                                Console.WriteLine($"The number stored in MEMORY is: {memory}");
                                outSignal = true;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid answer.");
                            }
                        } while (outSignal == false);
                    }
                    else
                    {
                        Console.WriteLine("Please enter valid operator.");
                    }
                    operatorSelected = operatorSelect;

                } while (operatorSelectOutSignal == false);

                var secondValueOutSignal = false;
                int secondValueInt;
                do
                {
                    Console.WriteLine();
                    Console.Write("Enter second value: ");
                    var secondValue = Console.ReadLine();
                    if (secondValue.ToLower() == "exit")
                    {
                        if (memory == 0)
                        {
                            Console.WriteLine("WARNING! The value stored in MEMORY is 0! Do You want to leave it that way?");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Do You really want to quit? Press ESC to confirm.\n" +
                                          "Press any other key to continue program.");
                        ConsoleKeyInfo breakDecision = Console.ReadKey();
                        if (breakDecision.Key == ConsoleKey.Escape) return;
                    }
                    if (int.TryParse(secondValue, out secondValueInt))
                    {
                        secondValueOutSignal = true;
                    }
                    else if (secondValue.ToUpper() == "M")
                    {
                        var outSignal = false;
                        do
                        {
                            Console.WriteLine();
                            Console.WriteLine("Would like to add a number to MEMORY or read a number that is stored in MEMORY? \n" +
                                              "Press A to enter and R to read.");
                            var memDecision = Console.ReadLine();
                            if (memDecision.ToLower() == "exit")
                            {
                                if (memory == 0)
                                {
                                    Console.WriteLine("\nWARNING! The value stored in MEMORY is 0! Do You want to leave it that way?");
                                }

                                Console.WriteLine();
                                Console.WriteLine("Do You really want to quit? Press ESC to confirm.\n" +
                                                  "Press any other key to continue program.");
                                ConsoleKeyInfo breakDecision = Console.ReadKey();
                                if (breakDecision.Key == ConsoleKey.Escape) return;
                            }
                            else if (memDecision.ToUpper() == "A")
                            {
                                var innerOutSignal = false;
                                do
                                {
                                    Console.WriteLine();
                                    Console.Write("Please enter a number to add to MEMORY: ");
                                    var numberToMemory = Console.ReadLine();
                                    if (numberToMemory.ToLower() == "exit")
                                    {
                                        if (memory == 0)
                                        {
                                            Console.WriteLine("\nWARNING! The value stored in MEMORY is 0! Do You want to leave it that way?");
                                        }

                                        Console.WriteLine();
                                        Console.WriteLine("Do You really want to quit? Press ESC to confirm.\n" +
                                                          "Press any other key to continue program.");
                                        ConsoleKeyInfo breakDecision = Console.ReadKey();
                                        if (breakDecision.Key == ConsoleKey.Escape) return;
                                    }
                                    if (int.TryParse(numberToMemory, out memory))
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine($"You have added {memory} to MEMORY.");
                                        innerOutSignal = true;
                                        outSignal = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please enter a valid number to add to memory.");
                                    }
                                } while (innerOutSignal == false);
                            }
                            else if (memDecision.ToUpper() == "R")
                            {
                                Console.WriteLine($"The number stored in MEMORY is: {memory}");
                                outSignal = true;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid answer.");
                            }
                        } while (outSignal == false);
                    }
                    else
                    {
                        Console.WriteLine("Please enter valid second value.");
                    }
                } while (secondValueOutSignal == false);


                if (operatorSelected == "+")
                {
                    var sum = firstValueInt + secondValueInt;
                    Console.WriteLine();
                    Console.WriteLine($"The result of addition is: {sum}");
                }
                else if (operatorSelected == "-")
                {
                    var difference = firstValueInt - secondValueInt;
                    Console.WriteLine();
                    Console.WriteLine($"The result of subtraction is: {difference}");
                }
                else if (operatorSelected == "*")
                {
                    var product = firstValueInt * secondValueInt;
                    Console.WriteLine();
                    Console.WriteLine($"The result of multiplication is: {product}");
                }
                else if (operatorSelected == "/")
                {
                    if (secondValueInt == 0)
                    {
                        Console.WriteLine("Can't divide by 0. Enter values one more time.");
                        continue;
                    }
                    var quotient = firstValueInt / secondValueInt;
                    Console.WriteLine();
                    Console.WriteLine($"The result of division is: {quotient}");

                }
                else if (operatorSelected == "%")
                {
                    if (secondValueInt == 0)
                    {
                        Console.WriteLine("Can't divide by 0. Enter values one more time.");
                        continue;
                    }
                    var modulo = firstValueInt % secondValueInt;
                    Console.WriteLine();
                    Console.WriteLine($"The modulo is: {modulo}");
                }

                Console.WriteLine();
                if (memory == 0)
                {
                    Console.WriteLine("WARNING! The value stored in MEMORY is 0! Do You want to leave it that way?");
                }
                Console.WriteLine();
                Console.WriteLine("Would You like to perform another operation (Y/N)?");
                decision = Console.ReadLine();
                while (decision.ToUpper() != "Y")
                {
                    if (decision.ToUpper() == "N")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Ok. Bye.");
                        break;
                    }

                    Console.WriteLine("Please, enter the correct answer (Y - for Yes, N - for No).");
                    decision = Console.ReadLine();

                }

            }
            Console.ReadKey();
        }
    }
}
