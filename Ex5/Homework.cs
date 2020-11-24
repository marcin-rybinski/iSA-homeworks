using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex5
{
    public class Homework
    {
        //TODO: Do każdej z metod dodaj wypisywanie wyniku na konsolę w czytelny i przejrzysty sposób ;)
        public void E1()
        {
            // Każdy z wyrazow „weź” w cudzysłów

            string[] words = new[] { "ala", "ma", "kota" };
            var newWords = words.Select(word => "\"" + word + "\"").ToList();
            Console.WriteLine("E1 solution: \n");
            newWords.ForEach(Console.WriteLine);
            Console.WriteLine();
        }

        public void E2()
        {
            // Znajdź takie słowa które zaczynają się na A i kończą na A. Wielkość liter nie ma znacznia.
            // 
            string[] words = new[] { "Ala", "ma", "kota", "beata", "ameba", "Amanda", "Albert" };

            //Wynik: Ala ameba Amanda
            var wordsNewList = words.Where(word => word.StartsWith("a", StringComparison.InvariantCultureIgnoreCase) && word.EndsWith("a", StringComparison.InvariantCultureIgnoreCase)).ToList();
            Console.WriteLine("E2 solution: \n");
            wordsNewList.ForEach(Console.WriteLine);
            Console.WriteLine();
        }

        public void E3()
        {
            // Połącz liczby tak aby w rezultacie dały jeden string „0, 1, 2, 3, 4, 5” // zera nie ma w kolekcji celowo ;)

            int[] numbers = new[] { 1, 2, 3, 4, 5 };
            var newString = numbers.Aggregate("0, ", (x, y) => x + y + ", ").TrimEnd(' ').TrimEnd(',');
            Console.WriteLine("E3 solution: \n");
            Console.WriteLine(newString);
            Console.WriteLine();
        }

        public void E4()
        {
            // Policz sumę liczb w tablicy (uwaga liczby są typu string)

            string[] numbersAsStrings = new[] { "1", "2", "3", "4" };

            //WyniK:  10 : int
            var sum = numbersAsStrings.Select(int.Parse).Aggregate((x, y) => x + y);
            Console.WriteLine("E4 solution: \n");
            Console.WriteLine(sum);
            Console.WriteLine();
        }

        public void E5()
        {
            string votes = "Yes,No,Yes,Yes,Yes,No,No,Yes,Yes,No";

            //o ile więcej było głosów na 'tak' ?

            // Wynik: o 2 głosy.
            var votesDiff = votes.Split(',').Where(x => x == "Yes").ToList().Count -
                           votes.Split(',').Where(x => x == "No").ToList().Count;
            Console.WriteLine("E5 solution: \n");
            if (votesDiff > 0 ) Console.WriteLine("Głosów na 'tak' było więcej o " + votesDiff + " głosy.");
            else if (votesDiff <0) Console.WriteLine("Głosów na 'tak' było mniej o " + -votesDiff + " głosy.");
            else Console.WriteLine("Głosów na 'tak' i na 'nie' było tyle samo.");
            Console.WriteLine();
        }

        public void E6()
        {
            // W jaki dzień tygodnia wypada
            // Wigilia Bożego Narodzenia przez
            // następne 5 lat (od 2021 do 2025 roku) ?

            // Wynik: Powinniśmy stworzyć kolekcję par: rok i dzień tygodnia czyli coś podobnego do:
            /*
             * 2021 Friday 
               2022 Saturday 
               2023 Sunday 
               2024 Tuesday 
               2025 Wednesday 
             */
            Dictionary<int, DayOfWeek> christmasEves = new Dictionary<int, DayOfWeek>();
            for (var i = 2021; i <= 2025; i++)
            {
                DateTime christmasEve = new DateTime(i,12,24);
                christmasEves.Add(i,christmasEve.DayOfWeek);
            }
            Console.WriteLine("E6 solution: \n");
            Console.WriteLine(christmasEves.Aggregate("" , (k,v) => k + v +"\n"));
        }
    }
}