using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.classes
{
    internal class ListEntry
    {
        public Student Student;
        public List<Book> Books;

        public ListEntry(Student student, List<Book> books) 
        {
            this.Student = student;
            this.Books = books;
        }

    }
}
