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
        public Library(List<Book> allBooks, List<Book> booksInStore,List<ListEntry> entriesInStore) 
        {
            this._allBooks = allBooks;
            this._booksInStore = booksInStore;
            this._entrysInStore = entriesInStore;
        }
        public void addBooksToEntries(Student student, List<Book> books) 
        {
            ListEntry entry = _entrysInStore.Where(x => x.Student.id == student.id).FirstOrDefault();
            if (entry != null)
            {
                foreach (Book book in books) 
                {
                    entry.Books.Add(book);
                }
            }
            else
            {
                _entrysInStore.Add(new ListEntry(student, books));
            }
        }
        public void removeBookFromStudent(Student student, Book book)
        {
            ListEntry entry = _entrysInStore.Where(x => x.Student.id == student.id).FirstOrDefault();
            if (entry != null)
            {
                entry.Books.Remove(book);
                _booksInStore.Add(book);
            }
        }
    }
}
