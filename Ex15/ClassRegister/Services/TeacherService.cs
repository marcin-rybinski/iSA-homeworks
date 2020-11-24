using System;
using ClassRegister.Models;

namespace ClassRegister.Services
{
    internal class TeacherService
    {
        private readonly ClassRegister _classRegister;

        public TeacherService(ClassRegister classRegister)
        {
            _classRegister = classRegister;
        }

        public Guid AddTeacher(Person newTeacher)
        {
            var newTeacherId = Guid.NewGuid();
            _classRegister.Teachers.Add(new Teacher
            {
                Id = newTeacherId,
                Address = newTeacher.Address,
                Email = new Email(newTeacher.FirstName, newTeacher.Surname),
                FirstName = newTeacher.FirstName,
                Surname = newTeacher.Surname
            });
            return newTeacherId;
        }
    }
}