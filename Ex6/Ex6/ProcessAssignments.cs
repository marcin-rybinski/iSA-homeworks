using System;
using System.Collections.Generic;

namespace Ex6
{
    class ProcessAssignments
    {
        public Queue<Assignment> ExecuteAssignment(Queue<Assignment> assignments)
        {
            var nextAssignment = assignments.Peek();
            Console.WriteLine($"{nextAssignment.Name.PadRight(30)} | Added at {TimeZoneInfo.ConvertTime(nextAssignment.WhenCreated, TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time")).Hour}:{TimeZoneInfo.ConvertTime(nextAssignment.WhenCreated, TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time")).Minute} | Done in {(DateTime.UtcNow - nextAssignment.WhenCreated).Milliseconds} milliseconds.");
            assignments.Dequeue();
            return assignments;
        }

        public void ExecuteAllAssignments(Queue<Assignment> assignments)
        {
            while (assignments.Count > 0) ExecuteAssignment(assignments);
            Console.WriteLine();
            Console.WriteLine("All assignments have been processed successfully. Congratulations!");
            Console.WriteLine();
            Console.WriteLine("-----------------------------The End-----------------------------");
        }
    }
}