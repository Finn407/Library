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
        public List<Student> WaitingList;

        public Book(string ISBN, string Name,string Title,List<Student> waitingList) 
        {
            this.ISBN = ISBN;
            this.Name = Name;
            this.Title = Title;
            this.WaitingList = waitingList;
        }
    }
}
