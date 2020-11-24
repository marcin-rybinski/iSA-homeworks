using ClassRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassRegister.Services
{
    internal class StudentService
    {
        private readonly ClassRegister _classRegister;
        private readonly HelperMethods.HelperMethods _helperMethods;

        public StudentService(ClassRegister classRegister)
        {
            _classRegister = classRegister;
            _helperMethods = new HelperMethods.HelperMethods();
        }

        public void AddStudentToList(Person newStudent)
        {
            _classRegister.Students.Add(new Student
            {
                Email = new Email(newStudent.FirstName, newStudent.Surname),
                FirstName = newStudent.FirstName,
                Number = _classRegister.Students.Any() ? _classRegister.Students.Max(s => s.Number) + 1 : 1,
                Address = newStudent.Address,
                Surname = newStudent.Surname,
            });
        }

        public List<Student> GetBestAverage()
        {
            return _classRegister.Students.Where(student => student.Marks.Count != 0).Where(student => Math.Round(student.Marks.Average(), 2) > 4.75).ToList();
        }

        public void AddStudent()
        {
            var newStudent = _classRegister.HelperMethods.GetPersonData("Student");
            AddStudentToList(newStudent);
        }

        public void ListBestStudents()
        {
            foreach (var student in GetBestAverage())
            {
                Console.WriteLine($"{student.Number}. {student.FirstName} {student.Surname} Average: {Math.Round(student.Marks.Average(), 2)}");
            }
        }

        public void ListAllStudents()
        {
            Console.WriteLine();
            foreach (var student in _classRegister.Students)
            {
                Console.WriteLine($"{student.Number}. {student.FirstName} {student.Surname}");
            }
        }

        public void AddMark()
        {
            ListAllStudents();
            Console.Write("Select student to add mark for (type student's number): ");
            var chosenStudentsNumber = _helperMethods.GetANumberFromConsole();
            if (_classRegister.Students.Any(s => s.Number == chosenStudentsNumber))
            {
                Console.Write("Choose mark value (1,2,3,4,5): ");
                var mark = _helperMethods.GetANumberFromConsole();
                Console.WriteLine();
                if (mark >=1 && mark <=5)
                {
                    _classRegister.Students.FirstOrDefault(s => s.Number == chosenStudentsNumber)
                        ?.Marks.Add(mark);
                    Console.WriteLine("Mark added.");
                    return;
                }
                Console.WriteLine("Wrong mark value.");
                return;
            }
            Console.WriteLine("There is no student with given number.");
        }
    }
}