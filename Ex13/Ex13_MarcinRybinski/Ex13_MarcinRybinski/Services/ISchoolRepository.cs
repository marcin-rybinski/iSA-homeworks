using System;
using System.Collections.Generic;
using Ex13_MR.Models;

namespace Ex13_MR.Services
{
    public interface ISchoolRepository
    {
        List<Teacher> ListAllTeachers();
        List<Student> ListAllStudents();
        Student GetStudentById(Guid id);
        Teacher GetTeacherById(Guid id);
        List<Grade> ListAllStudentsGrades(Student student);
        void InsertStudent(Student student);
        void InsertGrade(Grade grade);
    }
}