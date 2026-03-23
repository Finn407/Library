using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.classes
{
    internal class Library
    {
        private List<Book> _allBooks;
        private List<Book> _booksInStore;
        private List<ListEntry> _entrysInStore;
        public Library(List<Book> allBooks, List<Book> booksInStore,List<ListEntry> entriesInStore) 
        {
            this._allBooks = allBooks;
            this._booksInStore = booksInStore;
            this._entrysInStore = entriesInStore;
        }
        public void BorrowBook(Book book,Student student)
        {
            ListEntry entry = _entrysInStore.Where(x => x.Student.id == student.id).FirstOrDefault();
            if (entry != null)
            {
                if (_booksInStore.Contains(book))
                {
                    entry.Books.Add(book);
                    _booksInStore.Remove(book);
                }
                else 
                {
                    Console.WriteLine("Das angeforderte Buch ist nicht in der Liste enthalten");
                }
            }
            else if (entry.Student != null) 
            {

            }
        }
    }
}
