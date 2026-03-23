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
        public bool _isMember;

        public Student(Guid id, string name, DateOnly birthday, List<Book> borrowedBooks, bool isMember)
        {
            this.id = id;
            this.name = name;
            this.birthday = birthday;
            this.borrowedBooks = borrowedBooks;
            _isMember = isMember;
        }

        public void BorrowBook(Book book, Library lib) 
        {
            if (this.borrowedBooks.Count < 5 && this._isMember)
            {
                this.borrowedBooks.Add(book);
                lib.AddBooksToEntries(this, new List<Book>() { book });
                lib._booksInStore.Remove(book);
            }
            else if (this.borrowedBooks.Count < 1)
            {
                this.borrowedBooks.Add(book);
                lib.AddBooksToEntries(this, new List<Book>() { book });
                lib._booksInStore.Remove(book);
            }
            else 
            {
                Console.WriteLine($"Der Schüler: {this.name} kann das Buch {book.Name} nicht ausleihen");
            }
        }
        public Book ReturnBook(Book book, Library lib) 
        {
            lib.RemoveBookFromStudent(this, book);
            return book;
        }
        public List<Book> ShowBooks() 
        {
            return this.borrowedBooks;
        }
    }
}
