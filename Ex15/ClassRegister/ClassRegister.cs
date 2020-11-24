using ClassRegister.Models;
using ClassRegister.Services;
using System.Collections.Generic;

namespace ClassRegister
{
    internal class ClassRegister
    {
        public List<Student> Students = new List<Student>();
        public List<Teacher> Teachers = new List<Teacher>();
        public List<Course> Courses = new List<Course>();

        public ClassRegister()
        {
            ConsoleDisplay = new ConsoleDisplay(this);
            StudentService = new StudentService(this);
            CourseService = new CourseService(this);
            TeacherService = new TeacherService(this);
            HelperMethods = new HelperMethods.HelperMethods();
        }

        public ConsoleDisplay ConsoleDisplay { get; }
        public StudentService StudentService { get; }
        public CourseService CourseService { get; }
        public TeacherService TeacherService { get; }
        public HelperMethods.HelperMethods HelperMethods { get; }

        public void Run()
        {
            ConsoleDisplay.DisplayMenu();
        }
    }
}
