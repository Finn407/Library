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
        public string password;
        public Student(Guid id, string name, DateOnly birthday, List<Book> borrowedBooks, bool isMember, string password)
        {
            this.id = id;
            this.name = name;
            this.birthday = birthday;
            this.borrowedBooks = borrowedBooks;
            _isMember = isMember;
            this.password = password;
        }

        public void BorrowBook(Book book, Library lib) 
        {
            if (lib.BookAvailable(book))
            {
                if (this.borrowedBooks.Count < 5 && this._isMember)
                {
                    this.borrowedBooks.Add(book);
                    lib.AddBooksToEntries(this, new List<Book>() { book });
                    lib._booksInStore.Remove(book);
                    Console.WriteLine($"Der Schüler: {this.name} kann das Buch {book.Name} ausleihen und ist Mitglied 1");
                }
                else if (this.borrowedBooks.Count < 1)
                {
                    this.borrowedBooks.Add(book);
                    lib.AddBooksToEntries(this, new List<Book>() { book });
                    lib._booksInStore.Remove(book);
                    Console.WriteLine($"Der Schüler: {this.name} kann das Buch {book.Name} ausleihen und ist kein Mitglied 2");
                }
                else
                {
                    Console.WriteLine($"Der Schüler: {this.name} kann das Buch {book.Name} nicht ausleihen, da er kein Mitglied ist 3");
                }
            }
            else 
            {
                if (lib.WaitingAvailable(book, this))
                {
                    Console.WriteLine($"Der Schüler: {this.name} kann das Buch {book.Name} nicht ausleihen und wird auf die Warteliste geschrieben 4");
                    book.WaitingList.Add(this);
                }
                else 
                {
                    Console.WriteLine($"Der Schüler: {this.name} kann das Buch {book.Name} nicht ausleihen und steht bereits auf der Warteliste 5");
                }
            }
        }
        public Book ReturnBook(Book book, Library lib) 
        {
            lib.RemoveBookFromStudent(this, book);
            if (book.WaitingList.Count >= 1) 
            {
                Console.WriteLine($"Der Schüler: {book.WaitingList[0].name} leiht das Buch {book.Name} als nächstes aus 6");
                book.WaitingList[0].BorrowBook(book, lib);
            }
            return book;
        }
        public List<Book> ShowBooks() 
        {
            return this.borrowedBooks;
        }
    }
}
