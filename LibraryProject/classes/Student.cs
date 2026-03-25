using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.classes;

public class Student
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateOnly Birthday { get; set; }
    public List<Book> _borrowedBooks { get; set; }
    public bool _isMember { get; set; }
    public string Password { get; set; }
    public Student(Guid id, string name, DateOnly birthday, List<Book> borrowedBooks, bool isMember, string password)
    {
        this.Id = id;
        this.Name = name;
        this.Birthday = birthday;
        _borrowedBooks = borrowedBooks;
        _isMember = isMember;
        this.Password = password;
    }
    public Student() 
    {
        this.Id = new Guid();
        this.Name = "";
        this.Birthday = new DateOnly();
        this._borrowedBooks = new List<Book>();
        this._isMember = false;
        this.Password = "";
    }
    public void BorrowBook(Book book, Library lib)
    {
        if (lib.BookAvailable(book))
        {
            CheckValidBookBorrow(book, lib);
            return;
        }

        if (lib.WaitingAvailable(book, this))
        {
            Console.WriteLine($"Der Schüler: {this.Name} kann das Buch {book.Name} nicht ausleihen und wird auf die Warteliste geschrieben 4");
            lib.AddToWaitingList(book, this);
            return;
        }

        Console.WriteLine($"Der Schüler: {this.Name} kann das Buch {book.Name} nicht ausleihen und steht bereits auf der Warteliste 5");
    }

    private void CheckValidBookBorrow(Book book, Library lib)
    {
        if (_borrowedBooks.Count < 5 && _isMember)
        {
            _borrowedBooks.Add(book);
            lib.ChangeAvailability(book);
            Console.WriteLine($"Der Schüler: {this.Name} kann das Buch {book.Name} ausleihen und ist Mitglied 1");
            return;
        }

        if (_borrowedBooks.Count < 1 && !_isMember)
        {
            lib.ChangeAvailability(book);
            _borrowedBooks.Add(book);
            Console.WriteLine($"Der Schüler: {this.Name} kann das Buch {book.Name} ausleihen und ist kein Mitglied 2");
            return;
        }

        Console.WriteLine($"Der Schüler: {this.Name} kann das Buch {book.Name} nicht ausleihen, da er kein Mitglied ist 3");

    }
    public List<Book> ShowBooks()
    {
        return _borrowedBooks;
    }
}
