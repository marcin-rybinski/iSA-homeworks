using System;

namespace Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            string continueProgram;
            Timer timer = new Timer();
            do
            {
                Console.Clear();
                timer.DisplayInterface();
                int presetChoice = timer.GetUserChoice();
                if (presetChoice == 6) return;
                timer.RunTimer(presetChoice);
                continueProgram = ContinueProgram();
            } while (continueProgram.ToUpper() == "T");
        }

        
        private static string ContinueProgram()
        {
            string continueProgram = "T";
            Console.WriteLine();
            Console.Write("Czy chcesz uruchomić timer ponownie? (T - Tak, N - Nie) ");
            continueProgram = Console.ReadLine();
            while (continueProgram.ToUpper() != "T")
            {
                if (continueProgram.ToUpper() == "N") break;
                Console.Write("Proszę udzielić poprawnej odpowiedzi (T - Tak, N - Nie) ");
                continueProgram = Console.ReadLine();
            }
            return continueProgram;
        }
    }
}
