using LibraryProject.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Infrastructure
{
    internal class StudentRepository : IStudentRepository
    {
        public List<Student> GetAllStudents()
        {
            return new List<Student>()
            {
                new Student(Guid.NewGuid(), "Max Müller", new DateOnly(2005, 3, 20), new List<Book>(),true,"test"),
                new Student(Guid.NewGuid(), "Anna Schmidt", new DateOnly(2004, 7, 12), new List<Book>(), false, "test"),
                new Student(Guid.NewGuid(), "Lukas Weber", new DateOnly(2006, 1, 5), new List<Book>(), false, "test"),
                new Student(Guid.NewGuid(), "Sophia Fischer", new DateOnly(2005, 11, 18), new List<Book>(),true, "test"),
                new Student(Guid.NewGuid(), "Tim Becker", new DateOnly(2004, 5, 30), new List<Book>(),true, "test"),
                new Student(Guid.NewGuid(), "Laura Wagner", new DateOnly(2006, 9, 25), new List<Book>(),true, "test"),
                new Student(Guid.NewGuid(), "Jonas Hoffmann", new DateOnly(2005, 2, 14), new List<Book>(), false, "test"),
                new Student(Guid.NewGuid(), "Emma Koch", new DateOnly(2004, 12, 3), new List<Book>(),true, "test"),
                new Student(Guid.NewGuid(), "Felix Neumann", new DateOnly(2006, 6, 10), new List<Book>(), false, "test"),
                new Student(Guid.NewGuid(), "Mia Braun", new DateOnly(2005, 8, 8), new List<Book>(),true, "test")
            };
        }
    }
}
