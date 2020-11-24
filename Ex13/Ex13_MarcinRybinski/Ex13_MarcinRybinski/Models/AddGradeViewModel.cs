using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ex13_MR.Models
{
    public class AddGradeViewModel
    {
        public Guid StudentId { get; set; }
        public int Value { get; set; }
        public string Weight { get; set; }
        public string Category { get; set; }
    }
}
