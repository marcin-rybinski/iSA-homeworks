using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ex13_MR.Models
{
    public class StudentsGradesViewModel
    {
        public Guid StudentId { get; set; }
        public string StudentFullName { get; set; }
        public List<Grade> GradesList { get; set; }
    }
}
