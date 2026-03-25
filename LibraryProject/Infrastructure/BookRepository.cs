using LibraryProject.classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace LibraryProject.Infrastructure;

internal class BookRepository: IBookRepository
{
    public List<Book> GetAllBooks() 
    {
        List<Book> result = new List<Book>();
        string path = Path.Combine(AppContext.BaseDirectory, "data.csv");
        var lines = File.ReadLines(path);
        foreach (var line in lines)
        {
            var values = line.Split(',');
            Book temp = new Book(values[0], values[1], values[2], new List<Student>(), true);
            result.Add(temp);
        }
        return result;
    }
    public void SetAllBooks(IEnumerable<Book> books) 
    {
        var lines = new List<string>();
        foreach (Book book in books)
        {
            lines.Add($"{book.ISBN},{book.Name},{book.Title}");
        }
        File.WriteAllLines(Path.Combine(AppContext.BaseDirectory, "data.csv"), lines);
    }
}
