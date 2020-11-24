using System;
using System.ComponentModel.DataAnnotations;

namespace Ex13_MR.Models
{
    public class Grade
    {
        public int Id { get; set; }
        [Range(1,5)]
        public int Value { get; set; }
        public string Weight { get; set; }
        public string Category { get; set; }
        public Guid StudentId { get; set; }
    }
}