using LibraryProject.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Infrastructure;

internal interface IBookRepository
{
    public List<Book> GetAllBooks();
    public void SetAllBooks(IEnumerable<Book> books);
}
