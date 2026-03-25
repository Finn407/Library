namespace LibraryProject.classes;

public class Book
{
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Name { get; set; }
    public List<Student> WaitingList { get; set; }
    public bool IsAvailable { get; set; }

    public Book(string ISBN, string Name,string Title,List<Student> waitingList, bool isAvailable) 
    {
        this.ISBN = ISBN;
        this.Name = Name;
        this.Title = Title;
        this.WaitingList = waitingList;
        this.IsAvailable = isAvailable;
    }
    public Book() 
    {
        this.ISBN = "";
        this.Title = "";
        this.Name = "";
        this.WaitingList = new List<Student>();
        this.IsAvailable = true;
    }
    public List<Student> GetWaitingList() 
    {
        return this.WaitingList;
    }
    public void AddToWaitingList(Student student) 
    {
        this.WaitingList.Add(student);
    }
}
