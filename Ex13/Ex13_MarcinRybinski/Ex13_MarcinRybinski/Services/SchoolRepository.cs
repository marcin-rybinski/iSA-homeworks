using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ex13_MR.Models;

namespace Ex13_MR.Services
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly AppContext _context;

        public SchoolRepository(AppContext context)
        {
            _context = context;
        }

        public List<Teacher> ListAllTeachers()
        {
            return _context.Teachers.ToList();
        }
        public List<Student> ListAllStudents()
        {
            return _context.Students.ToList();
        }

        public Student GetStudentById(Guid id)
        {
            return _context.Students.FirstOrDefault(s => s.Id == id);
        }
        public Teacher GetTeacherById(Guid id)
        {
            return _context.Teachers.FirstOrDefault(t => t.Id == id);
        }
        public List<Grade> ListAllStudentsGrades(Student student)
        {
            return _context.Grades.Where(g=>g.StudentId == student.Id).ToList();
        }

        public void InsertStudent(Student student)
        {
            _context.Students.Add(student).Context.SaveChanges();
        }

        public void InsertGrade(Grade grade)
        {
            _context.Grades.Add(grade).Context.SaveChanges();
        }
    }
}
