using System.Collections.Generic;

namespace ClassRegister.Models
{
    internal class Student : Person
    {
        public int Number { get; set; }
        public List<Course> Courses { get; set; }
        public List<int> Marks { get; set; }

        public Student()
        {
            Courses = new List<Course>();
            Marks = new List<int>();
        }
    }
}