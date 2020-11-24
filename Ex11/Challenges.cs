using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using MoreLinq;
using Xunit;

namespace Ex11
{
    public class Challenges
    {
        [Fact]
        public void One()
        {
            const string n = "1-5;15-17;25-30";

            // TODO: Generate numbers e.g. 1-5;7-9 means 1, 2, 3, 4, 5, 7, 8, 9

            var numbers = n.Split(';').Select(x => x.Split('-'))
                .Select(x => x.Select(int.Parse))
                .Select(x => MoreEnumerable.Sequence(x.Min(), x.Max()))
                .Flatten();

            numbers.Should().Equal(1, 2, 3, 4, 5, 15, 16, 17, 25, 26, 27, 28, 29, 30);
        }

        [Fact]
        public void Two()
        {
            var names = new[] { "Marian", "Bartek", "Beata", "Daniel", "Monika", "Damian" };

            //scores of those who finished the game
            var scores = new[] { 350, 550, 550, 450 };

            //TODO: Get the best players (names and score)

            var bestPlayers = names.Zip(scores, (x, y) => new {name = x, score = y})
                .MaxBy(x => x.score).ToList();

            bestPlayers.Should().Equal(new { name = "Bartek", score = 550 }, new { name = "Beata", score = 550 });
        }

        [Fact]
        public void Three()
        {
            var students = new[]
                {"Bartek", "Blazej", "Natalia", "Danuta", "Mariusz", "Marian", "Beata", "Kasia", "Basia"};

            // TODO: assign students to groups of max. four persons.

            var studentGroups = students.Batch(4)
                .Select((x, i) => new {groupNumber = i + 1, groupMembers = x});

            studentGroups.Should().BeEquivalentTo(
                new
                {
                    groupNumber = 1,
                    groupMembers = new[]
                    {
                        "Bartek", "Blazej", "Natalia", "Danuta"
                    }
                },
                new
                {
                    groupNumber = 2,
                    groupMembers = new[]
                    {
                        "Mariusz", "Marian", "Beata", "Kasia"
                    }
                },
                new
                {
                    groupNumber = 3,
                    groupMembers = new[]
                    {
                        "Basia"
                    }
                }
            );
        }

        [Fact]
        public void Four()
        {
            var fruitOrVegetables = new[]
            {
                "apple",
                "orange",
                "orange",
                "carrot",
                "apple",
                "carrot",
                "carrot",
                null,
                "cucumber",
                "apple",
                "cucumber",
                "cucumber",
                "cucumber"
            };

            // TODO: Get only those fruit with total number of min. 3.

            var fruit = new[]
            {
                "apple",
                "orange"
            };

            var minimum3Fruit = fruitOrVegetables
                .Where(x => fruit.Any(y=>x==y))
                .CountBy(x=>x)
                .MaxBy(x=>x.Value)
                .Select(x=>x.Key);

            minimum3Fruit.Should().Equal("apple");
        }

        [Fact]
        public void Five()
        {
            var names = new[] { "Marian", null, "Bartek", "Daniel" };

            var scores = new[] { 350, 550, 550, 450 };

            // TODO: return the short summary of the players and their corresponding scores.
            // Please use the pattern: FirstPlayer:FirstPlayerScore - SecondPlayer:SecondPlayerScore to format the final result.
            // Use 'N/A' value when the player name is missing

            var playersSummary = names.Select(x => x ?? "N/A")
                .Zip(scores, (x,y) => new {name=x,score=y})
                .OrderByDescending(x=> x.score)
                .ThenBy(x=>x.name)
                .Select(x=>$"{x.name}:{x.score}")
                .ToDelimitedString(" - ");

            playersSummary.Should().Be("Bartek:550 - N/A:550 - Daniel:450 - Marian:350");
        }
    }
}
