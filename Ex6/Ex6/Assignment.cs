using System;

namespace Ex6
{
    public class Assignment
    {
        public string Name { get; set; }
        public DateTime WhenCreated { get; set; }
        public string Priority { get; set; }

        public Assignment(string name, string priority)
        {
            Name = name;
            WhenCreated = DateTime.UtcNow;
            Priority = priority;
        }
        public Assignment()
        {

        }
    }
}