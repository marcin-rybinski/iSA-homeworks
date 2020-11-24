namespace Ex6
{
    class Program
    {
        static void Main(string[] args)
        {
            var assignmentList = AssignmentHelper.CreateAssignmentList(20);

            var newFile = new WriteToXml();
            newFile.WriteToFile(assignmentList);

            var newFromXml = new ReadFromXml();
            var assignmentsFromFile = newFromXml.FromFileToQueue();

            var newProcessing = new ProcessAssignments();
            newProcessing.ExecuteAllAssignments(assignmentsFromFile);
        }

    }
}
