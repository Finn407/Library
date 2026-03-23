using LibraryProject.classes;

internal class Program
{
    static void Main(string[] args) 
    {
        List<Student> students = initStudents();
        List<Book> books = ReadBookCSV("C:\\Users\\f.rademaker\\Documents\\Repo\\LibraryProject\\LibraryProject\\data\\data.csv");
        List<Book> booksDupe = ReadBookCSV("C:\\Users\\f.rademaker\\Documents\\Repo\\LibraryProject\\LibraryProject\\data\\data.csv");
        Library lib = new Library(books, booksDupe, new List<ListEntry>());

        ConsoleKeyInfo key;

        bool loginUser = false;
        bool loginPW = false;
        bool showBooks = false;
        bool getBooks = false;

        string username = "";
        string password = "";
        string ISBN = "";

        string color = "  \u001b[32m";
        int option = 1;

        Console.WriteLine("Bitte geben Sie Ihren vollständigen Namen ein");
        while (!loginUser) 
        {
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter) 
            {
                loginUser = true;
                break;
            } 
            username += key.KeyChar;
        }
        Console.WriteLine("Bitte geben Sie Ihr Passwort ein");
        while (!loginPW) 
        {
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                if (checkPW(username, password, students)) loginPW = true;
                else Console.WriteLine("Sie haben das falsche Passwort eingegeben");
                break;
            }
            password += key.KeyChar;
        }
        while (!showBooks) 
        {
            Console.WriteLine($"{(option == 1 ? color : "    ")}Alle Bücher anzeigen\u001b[0m");
            Console.WriteLine($"{(option == 2 ? color : "    ")}Ausgeliehene Bücher anzeigen\u001b[0m");
            Console.WriteLine($"{(option == 3 ? color : "    ")}Buch ausleihen\u001b[0m");
            key = Console.ReadKey(true);
            switch (key.Key) 
            {
                case ConsoleKey.DownArrow:
                    option = (option == 3 ? 1 : option + 1);
                    break;

                case ConsoleKey.UpArrow:
                    option = (option == 1 ? 3 : option - 1);
                    break;

                case ConsoleKey.Enter:
                    if (option < 3)
                    {
                        BookOptions(option, books, username, students);
                        break;
                    }
                    else 
                    {
                        showBooks = true;
                        break;
                    }
            }
        }
        Console.WriteLine("Bitte geben Sie die ISBN-Nummer des Buches ein, das Sie ausleihen möchten");
        while (!getBooks) 
        {
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                Student temp = getUserByName(username, students);
                temp.BorrowBook(getBookByISBN(ISBN, books), lib);
                getBooks = true;
                break;
            }
            ISBN += key.KeyChar;
        }
    }
    static Student getUserByName(string name, List<Student> users) 
    {
        return users.Where(x=> x.name== name).FirstOrDefault();
    }
    static Book getBookByISBN(string ISBN, List<Book> allBooks) 
    {
        return allBooks.Where(x=>x.ISBN== ISBN).FirstOrDefault();
    }
    static void BookOptions(int option, List<Book> allBooks,string username, List<Student> students) 
    {
        if (option == 1) 
        {
            foreach (Book book in allBooks) 
            {
                Console.WriteLine(book.ISBN+ book.Title+ book.Name + "\n");
            }
        }
        else if (option == 2) 
        {
            Student temp = students.Where(x=> x.name == username).FirstOrDefault();
            foreach (Book book in temp.borrowedBooks) 
            {
                Console.WriteLine(book.ISBN + book.Title + book.Name + "\n");
            }
        }
        else if (option == 3) 
        {

        }
    }
    static bool checkPW(string username, string password, List<Student> students) 
    {
        Student temp = students.Where(x=>x.name==username).FirstOrDefault();
        if (temp.password == password) return true;
        else return false;
    }
    public void test(List<Student> students, List<Book> books, List<Book> booksDupe, Library lib) 
    {

        Random rnd = new Random();
        Random rnd2 = new Random();

        foreach (Student student in students)
        {
            //Verteile Bücher
            int counter = rnd.Next(1, 99);
            int count = rnd2.Next(1, 3);
            Book book = lib._allBooks[counter];
            for (int i = 0; i < count; i++)
            {
                student.BorrowBook(book, lib);
                counter = rnd.Next(1, 99);
            }
        }
        foreach (Student student in students)
        {
            //Gebe Bücher zurück
            for (int i = 0; i < student.borrowedBooks.Count; i++)

            {
                student.ReturnBook(student.borrowedBooks[i], lib);
            }
        }
        WriteBookCSV("C:\\Users\\f.rademaker\\Documents\\Repo\\LibraryProject\\LibraryProject\\data\\data.csv", lib._booksInStore);
    }
    static List<Book> ReadBookCSV(string path) 
    {
        List<Book> result = new List<Book>();
        var lines = File.ReadLines(path);
        foreach (var line in lines) 
        {
            var values = line.Split(',');
            Book temp = new Book(values[0], values[1], values[2], new List<Student>());
            result.Add(temp);
        }
        return result;
    }
    static void WriteBookCSV(string path,List<Book> books) 
    {
        var lines = new List<string>();
        foreach (Book book in books) 
        {
            lines.Add($"{book.ISBN},{book.Name},{book.Title}");
        }
        File.WriteAllLines(path, lines);
    }
    static List<Student> initStudents() 
    {
        List<Student> students = new List<Student>()
        {
            new Student(Guid.NewGuid(), "Max Müller", new DateOnly(2005, 3, 20), new List<Book>(),true,"test"),
            new Student(Guid.NewGuid(), "Anna Schmidt", new DateOnly(2004, 7, 12), new List<Book>(), false, "test"),
            new Student(Guid.NewGuid(), "Lukas Weber", new DateOnly(2006, 1, 5), new List<Book>(), false, "test"),
            new Student(Guid.NewGuid(), "Sophia Fischer", new DateOnly(2005, 11, 18), new List<Book>(),true, "test"),
            new Student(Guid.NewGuid(), "Tim Becker", new DateOnly(2004, 5, 30), new List<Book>(),true, "test"),
            new Student(Guid.NewGuid(), "Laura Wagner", new DateOnly(2006, 9, 25), new List<Book>(),true, "test"),
            new Student(Guid.NewGuid(), "Jonas Hoffmann", new DateOnly(2005, 2, 14), new List<Book>(), false, "test"),
            new Student(Guid.NewGuid(), "Emma Koch", new DateOnly(2004, 12, 3), new List<Book>(),true, "test"),
            new Student(Guid.NewGuid(), "Felix Neumann", new DateOnly(2006, 6, 10), new List<Book>(), false, "test"),
            new Student(Guid.NewGuid(), "Mia Braun", new DateOnly(2005, 8, 8), new List<Book>(),true, "test")
        };
        return students;
    }
    /*
static List<Book> initBooks()
{

List<Book> books = new List<Book>
{
    new Book("9780439708180", "Harry Potter and the Sorcerer's Stone", "J.K. Rowling"),
    new Book("9780439064873", "Harry Potter and the Chamber of Secrets", "J.K. Rowling"),
    new Book("9780439136365", "Harry Potter and the Prisoner of Azkaban", "J.K. Rowling"),
    new Book("9780439139601", "Harry Potter and the Goblet of Fire", "J.K. Rowling"),
    new Book("9780439358071", "Harry Potter and the Order of the Phoenix", "J.K. Rowling"),
    new Book("9780439785969", "Harry Potter and the Half-Blood Prince", "J.K. Rowling"),
    new Book("9780545010221", "Harry Potter and the Deathly Hallows", "J.K. Rowling"),

    new Book("9780547928227", "The Hobbit", "J.R.R. Tolkien"),
    new Book("9780547928210", "The Fellowship of the Ring", "J.R.R. Tolkien"),
    new Book("9780547928203", "The Two Towers", "J.R.R. Tolkien"),
    new Book("9780547928197", "The Return of the King", "J.R.R. Tolkien"),
    new Book("9780618391110", "The Silmarillion", "J.R.R. Tolkien"),

    new Book("9780451524935", "1984", "George Orwell"),
    new Book("9780451526342", "Animal Farm", "George Orwell"),
    new Book("9780156421171", "Homage to Catalonia", "George Orwell"),

    new Book("9780060850524", "Brave New World", "Aldous Huxley"),
    new Book("9780061561795", "Island", "Aldous Huxley"),
    new Book("9780061729072", "The Doors of Perception", "Aldous Huxley"),

    new Book("9780141439518", "Pride and Prejudice", "Jane Austen"),
    new Book("9780141439662", "Sense and Sensibility", "Jane Austen"),
    new Book("9780141439587", "Emma", "Jane Austen"),
    new Book("9780141439808", "Mansfield Park", "Jane Austen"),
    new Book("9780141439792", "Northanger Abbey", "Jane Austen"),
    new Book("9780141439686", "Persuasion", "Jane Austen"),

    new Book("9780307743657", "The Shining", "Stephen King"),
    new Book("9781501142970", "It", "Stephen King"),
    new Book("9781501143106", "Misery", "Stephen King"),
    new Book("9780307743664", "Carrie", "Stephen King"),
    new Book("9780307743688", "The Stand", "Stephen King"),
    new Book("9781501156700", "Pet Sematary", "Stephen King"),
    new Book("9781501160448", "The Green Mile", "Stephen King"),

    new Book("9780553593716", "A Game of Thrones", "George R.R. Martin"),
    new Book("9780553579901", "A Clash of Kings", "George R.R. Martin"),
    new Book("9780553573428", "A Storm of Swords", "George R.R. Martin"),
    new Book("9780553582024", "A Feast for Crows", "George R.R. Martin"),
    new Book("9780553582017", "A Dance with Dragons", "George R.R. Martin"),

    new Book("9780316769488", "The Catcher in the Rye", "J.D. Salinger"),
    new Book("9780316769020", "Franny and Zooey", "J.D. Salinger"),
    new Book("9780316767729", "Nine Stories", "J.D. Salinger"),

    new Book("9780743273565", "The Great Gatsby", "F. Scott Fitzgerald"),
    new Book("9780684801544", "Tender Is the Night", "F. Scott Fitzgerald"),
    new Book("9780743273566", "This Side of Paradise", "F. Scott Fitzgerald"),

    new Book("9781503280786", "Moby Dick", "Herman Melville"),
    new Book("9781503280787", "Bartleby the Scrivener", "Herman Melville"),
    new Book("9781503280788", "Billy Budd", "Herman Melville"),

    new Book("9780061120084", "To Kill a Mockingbird", "Harper Lee"),
    new Book("9780062409850", "Go Set a Watchman", "Harper Lee"),

    new Book("9780684801223", "The Old Man and the Sea", "Ernest Hemingway"),
    new Book("9780684801469", "A Farewell to Arms", "Ernest Hemingway"),
    new Book("9780684803357", "For Whom the Bell Tolls", "Ernest Hemingway"),
    new Book("9780743297332", "The Sun Also Rises", "Ernest Hemingway"),

    new Book("9780061122415", "The Alchemist", "Paulo Coelho"),
    new Book("9780061578953", "Brida", "Paulo Coelho"),
    new Book("9780061124266", "Veronika Decides to Die", "Paulo Coelho"),
    new Book("9780060589288", "Eleven Minutes", "Paulo Coelho"),
    new Book("9780061687457", "The Pilgrimage", "Paulo Coelho"),

    new Book("9780307474278", "The Da Vinci Code", "Dan Brown"),
    new Book("9780743493468", "Angels & Demons", "Dan Brown"),
    new Book("9781400079155", "Inferno", "Dan Brown"),
    new Book("9780312263126", "Digital Fortress", "Dan Brown"),
    new Book("9780312944926", "Deception Point", "Dan Brown"),

    new Book("9780307454546", "The Girl with the Dragon Tattoo", "Stieg Larsson"),
    new Book("9780307454553", "The Girl Who Played with Fire", "Stieg Larsson"),
    new Book("9780307454560", "The Girl Who Kicked the Hornet's Nest", "Stieg Larsson"),

    new Book("9780439023528", "The Hunger Games", "Suzanne Collins"),
    new Book("9780439023498", "Catching Fire", "Suzanne Collins"),
    new Book("9780439023511", "Mockingjay", "Suzanne Collins"),

    new Book("9780142424179", "The Fault in Our Stars", "John Green"),
    new Book("9780142402511", "Looking for Alaska", "John Green"),
    new Book("9780142414934", "Paper Towns", "John Green"),
    new Book("9780142410707", "An Abundance of Katherines", "John Green"),

    new Book("9780316015844", "Twilight", "Stephenie Meyer"),
    new Book("9780316160193", "New Moon", "Stephenie Meyer"),
    new Book("9780316160209", "Eclipse", "Stephenie Meyer"),
    new Book("9780316067928", "Breaking Dawn", "Stephenie Meyer"),

    new Book("9780066238500", "The Chronicles of Narnia", "C.S. Lewis"),
    new Book("9780064471053", "Prince Caspian", "C.S. Lewis"),
    new Book("9780064471077", "The Voyage of the Dawn Treader", "C.S. Lewis"),
    new Book("9780064471091", "The Silver Chair", "C.S. Lewis"),
    new Book("9780064471107", "The Last Battle", "C.S. Lewis"),

    new Book("9780000000036", "The Crystal Maze", "Ida Peters"),
    new Book("9780000000037", "Ghost Protocol", "Theo Lang"),
    new Book("9780000000038", "Fire and Code", "Helena Roth"),
    new Book("9780000000039", "The Dark Web", "Nico Sommer"),
    new Book("9780000000040", "Silent Code", "Finn Jäger"),
    new Book("9780000000041", "The Last Guardian", "Johanna Haas"),
    new Book("9780000000042", "Frozen Time", "Tobias Schuster"),
    new Book("9780000000043", "The Infinite Key", "Sarah Kern"),
    new Book("9780000000044", "Shadows Rising", "Jan Fuchs"),
    new Book("9780000000045", "The Final System", "Marlene Weiß"),
    new Book("9780000000046", "Virtual Reality", "Tom Schmitt"),
    new Book("9780000000047", "The Red Signal", "Alina Dietrich"),
    new Book("9780000000048", "Echo Chamber", "Erik Schmid"),
    new Book("9780000000049", "Binary Dreams", "Lina Conrad"),
    new Book("9780000000050", "The Lost Data", "Simon Werner"),
    new Book("9780000000051", "Cyber Storm", "Paula Voigt"),
    new Book("9780000000052", "The Hidden Node", "Robin Keller"),
    new Book("9780000000053", "Silent Network", "Julia Sauer"),
    new Book("9780000000054", "The Black Code", "Marvin Franke"),
    new Book("9780000000055", "Digital Horizon", "Lena Barth"),
    new Book("9780000000056", "The Final Byte", "Chris Ludwig"),
    new Book("9780000000057", "Neural Path", "Sven Krämer"),
    new Book("9780000000058", "The Data Stream", "Anne Beckmann"),
    new Book("9780000000059", "Lost Connection", "Marc Schreiber"),
    new Book("9780000000060", "The Code Breaker", "Tina Busch"),
    new Book("9780000000061", "Dark Signal", "Kevin Wolff"),
    new Book("9780000000062", "The Last Node", "Vanessa Arndt"),
    new Book("9780000000063", "Hidden System", "Patrick Krüger"),
    new Book("9780000000064", "The Infinite Loop 2", "Laura Weiß"),
    new Book("9780000000065", "Digital Storm", "Daniel Bergmann"),
    new Book("9780000000066", "Silent Protocol", "Julia Klein"),
    new Book("9780000000067", "The Red Code", "Thomas Fuchs"),
    new Book("9780000000068", "Ghost Network", "Maria Lang"),
    new Book("9780000000069", "Cyber Dreams", "Stefan Peters"),
    new Book("9780000000070", "The Hidden Algorithm", "Sophie Maier"),
    new Book("9780000000071", "Binary Storm", "Andreas Otto"),
    new Book("9780000000072", "The Lost Signal", "Nina Frank"),
    new Book("9780000000073", "Dark Protocol", "Julian Wolf"),
    new Book("9780000000074", "Virtual Code", "Hannah Busch"),
    new Book("9780000000075", "The Final Horizon", "Lukas König"),
    new Book("9780000000076", "Silent Byte", "Clara Schmitt"),
    new Book("9780000000077", "The Infinite System", "Tim Berg"),
    new Book("9780000000078", "Hidden Data", "Lea Fuchs"),
    new Book("9780000000079", "Cyber Horizon", "Paul Keller"),
    new Book("9780000000080", "Ghost Code", "Emma Weiß"),
    new Book("9780000000081", "Binary Path", "Jonas Ludwig"),
    new Book("9780000000082", "The Dark Node", "Mia Peters"),
    new Book("9780000000083", "Silent Storm", "Leon Schreiber"),
    new Book("9780000000084", "The Final Key", "Sophia Lang"),
    new Book("9780000000085", "Digital Maze", "Max Otto"),
    new Book("9780000000086", "The Hidden Byte", "Lisa König"),
    new Book("9780000000087", "Cyber Signal", "Noah Klein"),
    new Book("9780000000088", "Ghost Horizon", "Anna Fuchs"),
    new Book("9780000000089", "Binary Code X", "Tom Bergmann"),
    new Book("9780000000090", "The Lost Byte", "Julia Schuster"),
    new Book("9780000000091", "Dark System", "David König"),
    new Book("9780000000092", "Silent Data", "Clara Busch"),
    new Book("9780000000093", "The Infinite Node", "Jan Ludwig"),
    new Book("9780000000094", "Cyber Key", "Marlene Otto"),
    new Book("9780000000095", "Ghost System", "Felix Weiß"),
    new Book("9780000000096", "Binary Signal", "Lea König"),
    new Book("9780000000097", "The Final Protocol", "Simon Berg"),
    new Book("9780000000098", "Hidden Horizon", "Sarah Klein"),
    new Book("9780000000099", "Dark Byte", "Erik Otto"),
    new Book("9780000000100", "The Last Code", "Nina Busch")
};
return books;
}*/
}