using System;

namespace ClassRegister.Services
{
    internal class ConsoleDisplay
    {
        private readonly ClassRegister _classRegister;

        public ConsoleDisplay(ClassRegister classRegister)
        {
            _classRegister = classRegister;
        }

        public void DisplayMenu()
        {
            Console.WriteLine("Class register");
            char keyPressed;
            do
            {
                Console.WriteLine(
                    "Select action: [0]Add student [1]Add course [2]Add Mark [3]List best students [4]List all students [5]Close");
                keyPressed = Console.ReadKey().KeyChar;
                Console.WriteLine();
                Submenus(keyPressed);
            } while (keyPressed != '5');
        }

        private void Submenus(char keyPressed)
        {
            switch (keyPressed)
            {
                case '0':
                {
                    _classRegister.StudentService.AddStudent();
                    break;
                }
                case '1':
                    _classRegister.CourseService.AddCourse();
                    break;
                case '2':
                    _classRegister.StudentService.AddMark();
                    break;
                case '3':
                {
                    _classRegister.StudentService.ListBestStudents();
                    break;
                }
                case '4':
                {
                    _classRegister.StudentService.ListAllStudents();
                    break;
                }
            }
        }
    }
}