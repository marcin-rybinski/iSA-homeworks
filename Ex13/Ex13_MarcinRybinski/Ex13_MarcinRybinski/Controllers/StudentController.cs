using Ex13_MR.Models;
using Ex13_MR.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex13_MR.Controllers
{
    public class StudentController : Controller
    {
        private readonly ISchoolRepository _schoolRepository;

        public StudentController(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }
        // GET: StudentController
        public ActionResult ListTeachers()
        {
            IEnumerable<Teacher> model = _schoolRepository.ListAllTeachers();
            return View(model);
        }
        public ActionResult ListStudents()
        {
            var studentList = _schoolRepository.ListAllStudents();
            var model = new List<StudentsListViewModel>();
            foreach (var student in studentList)
            {
                model.Add(new StudentsListViewModel
                {
                    Student = student,
                    TeachersFullName = _schoolRepository.GetTeacherById(student.TeacherId).FullName
                });
            }
                
           
            return View(model);
        }
        public ActionResult ListGrades(Guid id)
        {
            var student = _schoolRepository.GetStudentById(id);
            var gradesList = _schoolRepository.ListAllStudentsGrades(student);
            var model = new StudentsGradesViewModel
            {
                StudentId = student.Id,
                StudentFullName = student.FullName,
                GradesList = gradesList
            };

            return View(model);
        }

        // GET: StudentController/AddStudent
        public ActionResult AddStudent()
        {
            var teachersList = _schoolRepository.ListAllTeachers();
            var model = new AddStudentViewModel
            {
                TeachersList = teachersList.Select(t => new SelectListItem()
                {
                    Value = t.Id.ToString(), Text = t.FullName
                }).ToList()
            };
            return View(model);
        }

        // POST: StudentController/AddStudent
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStudent(AddStudentViewModel newStudent)
        {
            var student = new Student
            {
                Id = Guid.NewGuid(),
                FullName = newStudent.FullName,
                TeacherId = newStudent.TeacherId
            };
            try
            {
                _schoolRepository.InsertStudent(student);
                return RedirectToAction(nameof(ListStudents));
            }
            catch
            {
                return View(newStudent);
            }
        }
        // GET: StudentController/AddStudent
        public ActionResult AddGrade(Guid studentId)
        {
            var model = new AddGradeViewModel()
            {
                StudentId = studentId
            };
            return View(model);
        }

        // POST: StudentController/AddStudent
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddGrade(AddGradeViewModel newGrade)
        {
            var grade = new Grade
            {
                Category = newGrade.Category,
                StudentId = newGrade.StudentId,
                Value = newGrade.Value,
                Weight = newGrade.Weight
            };
            try
            {
                _schoolRepository.InsertGrade(grade);
                return RedirectToAction("ListGrades", "Student", new {id = newGrade.StudentId});
            }
            catch
            {
                return View(newGrade);
            }
        }
    }
}
