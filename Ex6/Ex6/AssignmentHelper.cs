using System;
using System.Collections.Generic;

namespace Ex6
{
    public static class AssignmentHelper
    {
        private static readonly string[] nameFirstElement =
            {"repair", "repair", "buy new", "buy new", "renew", "sell old", "move", "clean", "find new", "look at", "admire", "stand on", "laugh at"};

        private static readonly string[] nameSecondElement =
            {"couch", "chair", "desk", "table", "door", "curtains", "carpet", "computer", "laptop", "coffee machine", "cooker", "mirror", "wardrobe", "dresser", "keyboard", "bed", "clock", "shower", "tv set", "fridge", "dishwasher", "washing machine"};

        private static readonly string[] priority = { "high", "medium high", "medium", "medium low", "low" };
        private static readonly Random generator = new Random();

        public static Assignment CreateRandomAssignment()
        {
            var nameFirstPart = nameFirstElement[generator.Next(0, nameFirstElement.Length)];
            var nameSecondPart = nameSecondElement[generator.Next(0, nameSecondElement.Length)];
            var assignmentName = $"{nameFirstPart} {nameSecondPart}";
            var assignmentPriority = priority[generator.Next(0, priority.Length)];

            return new Assignment(assignmentName, assignmentPriority);
        }
        public static List<Assignment> CreateAssignmentList(int number)
        {
            var assignmentList = new List<Assignment>();
            for (var i = 0; i < number; i++)
            {
                assignmentList.Add(CreateRandomAssignment());
            }
            return assignmentList;
        }
    }
}