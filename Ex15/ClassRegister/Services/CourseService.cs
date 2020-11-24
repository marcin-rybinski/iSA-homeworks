using ClassRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassRegister.Services
{
    internal class CourseService
    {
        private readonly ClassRegister _classRegister;

        public CourseService(ClassRegister classRegister)
        {
            _classRegister = classRegister;
            HelperMethods = new HelperMethods.HelperMethods();
        }

        public HelperMethods.HelperMethods HelperMethods { get; }

        public void AddCourse()
        {
            Console.WriteLine();
            var newCourse = new Course { Id = _classRegister.Courses.Any() ? _classRegister.Courses.Max(c => c.Id) + 1 : 1 };
            Console.WriteLine("Enter course name:");
            newCourse.Name = HelperMethods.GetStringFromConsole();
            Console.WriteLine("Enter teacher's data:");
            var newTeacher = HelperMethods.GetPersonData("Teacher");
            var newTeacherId = _classRegister.TeacherService.AddTeacher(newTeacher);
            newCourse.TeacherId = newTeacherId;
            newCourse.Teacher = _classRegister.Teachers.FirstOrDefault(t => t.Id == newTeacherId);
            newCourse.Students = AddStudentsToCourse();
            foreach (var foundStudent in newCourse.Students.Select(student => _classRegister.Students.Find(s => s.Number == student.Number)))
            {
                foundStudent?.Courses.Add(newCourse);
            }

            _classRegister.Courses.Add(newCourse);
        }

        private List<Student> AddStudentsToCourse()
        {
            Console.WriteLine();
            Console.WriteLine("Select students for this course.");
            _classRegister.StudentService.ListAllStudents();
            var studentsList = new List<Student>();
            bool addAnotherStudent;
            do
            {
                Console.WriteLine("Enter student's number to add student to course:");
                var studentNumber = HelperMethods.GetANumberFromConsole();
                if (!StudentInOnTheList(studentNumber))
                {
                    Console.WriteLine("There is no student with that number.");
                    addAnotherStudent = HelperMethods.AddAnotherStudentDecision();
                    continue;
                }
                
                if (studentsList.FirstOrDefault(s => s.Number == studentNumber) != null)
                {
                    Console.WriteLine("Student already on this course's list.");
                    addAnotherStudent = HelperMethods.AddAnotherStudentDecision(); 
                    continue;
                }
                studentsList.Add(_classRegister.Students.FirstOrDefault(s => s.Number == studentNumber));
                addAnotherStudent = HelperMethods.AddAnotherStudentDecision();

            } while (addAnotherStudent);

            return studentsList;
        }

        private bool StudentInOnTheList(int studentNumber)
        {
            return _classRegister.Students.FirstOrDefault(s => s.Number == studentNumber) != null;
        }
    }
}