using Ex13_MR.Models;
using Microsoft.EntityFrameworkCore;

namespace Ex13_MR.Services
{
    public class AppContext : DbContext
    {
        private const string ConnectionString = @"Server=(localdb)\Ex13_MarcinRybinski_Db;Database=Ex13_Db;Trusted_Connection=True;";

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().Property(teacher => teacher.Subject).HasMaxLength(50);
            modelBuilder.Entity<Teacher>().Property(teacher => teacher.FullName).HasMaxLength(50);
            modelBuilder.Entity<Grade>().Property(grade => grade.Weight).HasMaxLength(50);
            modelBuilder.Entity<Grade>().Property(grade => grade.Category).HasMaxLength(50);
            modelBuilder.Entity<Student>().Property(student => student.FullName).HasMaxLength(50);

            var teacherSeedData = TeachersGenerator.GenerateTeachers(3);
            foreach (var teacher in teacherSeedData)
            {
                modelBuilder.Entity<Teacher>().HasData(teacher);
            }
        }
    }
}
