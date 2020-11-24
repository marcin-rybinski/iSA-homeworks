using System;
using System.Collections.Generic;

namespace Ex13_MR.Models
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Subject { get; set; }
        public List<Student> Students { get; set; }
    }
}
