using LibraryProject.classes;

namespace LibraryProject.Test
{
    public class LibraryTests
    {
        /*
        [Fact]
        public void BoolAviablable_ShoulReturnTrue_WhenBookIsAvialable()
        {
            // Arrange
            Book booktoSearch = new Book("123456789", "Buch 1", "Titel 1", new List<Student>(),true);
            Library library = new Library(
                new List<Book>
                {
                   booktoSearch,
                    new Book("123456789","Buch 2", "Titel 2", new List<Student>(),true),
                }, new List<Book>
                {
                    booktoSearch,
                    new Book("123456789","Buch 2", "Titel 2", new List<Student>(),true),
                },new List<ListEntry>());
            // Act
            bool result = library.BookAvailable(booktoSearch);
            // Assert

            Assert.True(result);
        }*/
        [Fact]
        public void BorrowBook_ShouldDistributeBookToStudent_WhenBookAvailable() 
        {
            //Arrange
            Student studentToBorrowBook = new Student();
            Book bookToBorrow = new Book("123456789","","",new List<Student>(),true);
            Library testLib = new Library(new List<Book> {bookToBorrow},new List<Student> { studentToBorrowBook });
            //Act
            studentToBorrowBook.BorrowBook(bookToBorrow,testLib);
            //Assert
            Assert.True(studentToBorrowBook?._borrowedBooks.Contains(bookToBorrow));
        }

        [Fact]
        public void getAllBooks_ShouldReturnAllBooks() 
        {
            //Arrange
            List<Book> books = new List<Book>
            {
                new Book("9780439708180", "Harry Potter and the Sorcerer's Stone", "J.K. Rowling",new List<Student>(),true),
                new Book("9780439064873", "Harry Potter and the Chamber of Secrets", "J.K. Rowling",new List<Student>(),true),
                new Book("9780439136365", "Harry Potter and the Prisoner of Azkaban", "J.K. Rowling",new List<Student>(),true),
                new Book("9780439139601", "Harry Potter and the Goblet of Fire", "J.K. Rowling",new List < Student >(), true),
                new Book("9780439358071", "Harry Potter and the Order of the Phoenix", "J.K. Rowling",new List < Student >(), true),
                new Book("9780439785969", "Harry Potter and the Half-Blood Prince", "J.K. Rowling",new List < Student >(), true),
                new Book("9780545010221", "Harry Potter and the Deathly Hallows", "J.K. Rowling",new List < Student >(), true)
            };
            Library testLib = new Library(books, new List<Student> {});
            //Act
            List<Book> result = testLib.GetAllBooks().ToList<Book>();
            //Assert
            Assert.Equal(books, result);
        }
        [Fact]
        public void checkPW_ShouldReturnTrue_WhenUserIsAuthenticated() 
        {
            //Arrange
            Student student = new Student();
            student.Name= "Test";
            student.Password= "password";
            Library testLib = new Library(new List<Book>(),new List<Student> { student });
            //Act
            bool result = testLib.CheckPW(student.Name,student.Password);
            //Assert
            Assert.True(result);
        }
        [Fact]
        public void getBookByISBN_ShouldReturnBook_WhenISBNIsEqual() 
        {
            //Arrange
            Book book = new Book();
            book.ISBN = "123456789";
            Library testLib = new Library(new List<Book> { book}, new List<Student>());
            //Act
            Book result = testLib.GetBookByISBN(book.ISBN);
            //Assert
            Assert.Equal(book.ISBN,result.ISBN);
        }
        [Fact]
        public void ChangeAvailability_ShouldChangeBookAvailability_WhenCalled() 
        {
            Book book = new Book();
            book.ISBN = "123456789";
            Library testLib = new Library(new List<Book> { book }, new List<Student>());
            //Act
            testLib.ChangeAvailability(book);
            //Assert
            Assert.True(!testLib.GetAllBooks().FirstOrDefault(x => x.ISBN == book.ISBN)?.IsAvailable);
        }
        [Fact]
        public void WaitingAvailable_ShouldReturnWaitingAvailability_WhenStudentIsNotInWaitingList() 
        {
            Book book = new Book();
            book.ISBN = "123456789";
            Student student = new Student();
            student.Id = new Guid();
            Library testLib = new Library(new List<Book> { book }, new List<Student>());
            //Act
            bool result = testLib.WaitingAvailable(book, student);
            //Assert
            Assert.True(result);
        }
        [Fact]
        public void WaitingAvailable_ShouldReturnWaitingAvailability_WhenStudentIsInWaitingList()
        {
            Book book = new Book();
            book.ISBN = "123456789";
            Student student = new Student();
            student.Id = new Guid();
            book.WaitingList = new List<Student> { student };
            Library testLib = new Library(new List<Book> { book }, new List<Student> { student });
            //Act
            bool result = testLib.WaitingAvailable(book, student);
            //Assert
            Assert.True((!result));
        }
        [Fact]
        public void BookAvailable_ShouldReturnBookAvailability_WhenBookIsAvailable() 
        {
            Book book = new Book();
            book.ISBN = "123456789";
            Library testLib = new Library(new List<Book> { book }, new List<Student>());
            //Act
            bool result = testLib.BookAvailable(book);
            //Assert
            Assert.True(result);
        }
        [Fact]
        public void BookAvailable_ShouldReturnBookAvailability_WhenBookIsNotAvailable()
        {
            Book book = new Book();
            book.ISBN = "123456789";
            book.IsAvailable = false;
            Library testLib = new Library(new List<Book> { book }, new List<Student>());
            //Act
            bool result = testLib.BookAvailable(book);
            //Assert
            Assert.True(!result);
        }


    }
}