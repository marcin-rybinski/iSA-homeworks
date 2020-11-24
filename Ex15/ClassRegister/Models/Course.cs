using System;
using System.Collections.Generic;

namespace ClassRegister.Models
{
    internal class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
       
        public Course()
        {
            Students = new List<Student>();
        }
    }
}