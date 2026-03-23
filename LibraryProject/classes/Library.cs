using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.classes
{
    internal class Library
    {
        public List<Book> _allBooks;
        public List<Book> _booksInStore;
        public List<ListEntry> _entrysInStore;
        public Library(List<Book> allBooks, List<Book> booksInStore, List<ListEntry> entriesInStore)
        {
            this._allBooks = allBooks;
            this._booksInStore = booksInStore;
            this._entrysInStore = entriesInStore;
        }
        public void AddBooksToEntries(Student student, List<Book> books)
        {
            ListEntry entry = _entrysInStore.Where(x => x.Student.id == student.id).FirstOrDefault();
            if (entry is null)
            {
                _entrysInStore.Add(new ListEntry(student, books));
                return;
            }

            foreach (Book book in books)
            {
                entry.Books.Add(book);
            }

        }
        public void RemoveBookFromStudent(Student student, Book book)
        {
            ListEntry entry = _entrysInStore.Where(x => x.Student.id == student.id).FirstOrDefault();
            if (entry != null)
            {
                entry.Books.Remove(book);
                _booksInStore.Add(book);
            }
        }
        public bool BookAvailable(Book book)
        {
            Book temp = _booksInStore.Where(x => x.ISBN == book.ISBN).FirstOrDefault();
            if (temp != null) return true;
            else return false;
        }
        public bool WaitingAvailable(Book book, Student student)
        {
            Student tempStudent = book.WaitingList.Where(x => x.id == student.id).FirstOrDefault();
            if (tempStudent == null) return true;
            else return false;

        }
    }
}
