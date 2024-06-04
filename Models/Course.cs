namespace Models;

public class Course 
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public List<Student> Students { get; set; } = new List<Student>();
}