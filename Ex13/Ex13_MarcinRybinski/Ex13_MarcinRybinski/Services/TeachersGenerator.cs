using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ex13_MR.Models;
using RandomNameGenerator;

namespace Ex13_MR.Services
{
    public class TeachersGenerator
    {
        private static readonly List<string> _subjects = new List<string>
        {
            "Chemistry",
            "Mathematics",
            "Materials Engineering",
            "Mechanical Engineering",
            "Military Science",
            "Physics",
            "Electronics"
        };
        public static List<Teacher> GenerateTeachers(int number)
        {
            var rnd = new Random();
            var teachers = new List<Teacher>();
            for (var i = 0; i < number; i++)
            {
                var newTeacher = new Teacher
                {
                    Id = Guid.NewGuid(),
                    FullName = NameGenerator.Generate(rnd.Next(0, 2) == 0 ? Gender.Male : Gender.Female),
                    Subject = _subjects[rnd.Next(0, _subjects.Count)]
                };
                teachers.Add(newTeacher);
            }

            return teachers;
        }

    }
}
