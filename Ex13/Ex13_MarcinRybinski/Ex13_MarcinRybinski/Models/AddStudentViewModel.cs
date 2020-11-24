using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ex13_MR.Models
{
    public class AddStudentViewModel
    {
        public string FullName { get; set; }
        public Guid TeacherId { get; set; }
        public List<SelectListItem> TeachersList { get; set; }
    }
}
