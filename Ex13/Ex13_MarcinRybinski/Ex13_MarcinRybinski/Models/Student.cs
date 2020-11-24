using System;
using System.Collections.Generic;

namespace Ex13_MR.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public Guid TeacherId { get; set; }
        public List<Grade> Grades { get; set; }
    }
}