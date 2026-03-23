using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.classes
{
    internal class Book
    {
        public string ISBN;
        public string Title;
        public string Name;

        public Book(string ISBN, string Name,string Title) 
        {
            this.ISBN = ISBN;
            this.Name = Name;
            this.Title = Title;
        }
    }
}
