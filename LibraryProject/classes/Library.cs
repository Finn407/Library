using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.classes;

public class Library
{
    private List<Book> _allBooks;
    private List<Student> _allStudents;  

    public Library(List<Book> allBooks,  List<Student> allStudents)
    {
        this._allBooks = allBooks;
        this._allStudents = allStudents;    
    }
    public IReadOnlyCollection<Book> GetAllBooks() => _allBooks.AsReadOnly();
    public IReadOnlyCollection<Student> GetAllStudents() => _allStudents.AsReadOnly();

    public bool BookAvailable(Book book)
    {
        Book availableBook = _allBooks.FirstOrDefault(b => b.ISBN == book.ISBN)?? new Book();
        return availableBook.IsAvailable;
    }
    public void AddToWaitingList(Book book, Student student) 
    {
        book.AddToWaitingList(student);
    }
    public bool WaitingAvailable(Book book, Student student)
    {
        return !book.WaitingList.Contains(student);
    }
    public Student GetStudentByName(string name)
    {
        return _allStudents.FirstOrDefault(x => x.Name == name) ?? new Student();
    }
    public Book GetBookByISBN(string ISBN)
    {
        return _allBooks.FirstOrDefault(x => x.ISBN == ISBN) ?? new Book();
    }
    public bool CheckPW(string username, string password)
    {
        Student temp = _allStudents.FirstOrDefault(x => x.Name == username)?? new Student();
        if (temp.Password == password) return true;
        else return false;
    }
    public void ChangeAvailability(Book book) 
    {
        Book temp = _allBooks.FirstOrDefault(x => x.ISBN == book.ISBN) ?? new Book();
        temp.IsAvailable = !temp.IsAvailable;
    }
}
