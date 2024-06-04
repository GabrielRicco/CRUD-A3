namespace Models;

public class Student
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public Course Course { get; set; } = new Course();
}