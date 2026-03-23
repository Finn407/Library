using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.classes
{
    internal class Student
    {
        public Guid id;
        public string name;
        public DateOnly birthday;
        public List<Book> borrowedBooks;
        private bool _isMember;

        public Student(Guid id, string name, DateOnly birthday, List<Book> borrowedBooks, bool isMember)
        {
            this.id = id;
            this.name = name;
            this.birthday = birthday;
            this.borrowedBooks = borrowedBooks;
            _isMember = isMember;
        }

        public void BorrowBook(Book book) 
        {
            if (this.borrowedBooks.Count < 5 && _isMember)
            {
                this.borrowedBooks.Add(book);
            }
            else if (this.borrowedBooks.Count < 1) 
            {
                this.borrowedBooks.Add(book);
            }
        }
        public void ReturnBook(Book book) 
        {
            if (this.borrowedBooks.Remove(book)) return;
            else Console.WriteLine("Das Buch konnte nicht zurückgegeben werden");
        }
        public List<Book> ShowBooks() 
        {
            return this.borrowedBooks;
        }
    }
}
