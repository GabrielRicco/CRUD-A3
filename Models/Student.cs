namespace Models;

public class Student : IEquatable<Student>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public Guid? CourseId { get; set; }

    public bool Equals(Student? other)
    {
        if (other == null)
            return false;

        return this.Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;

        if (obj is not Student studentObj)
            return false;

        return Equals(studentObj);
    }

    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }
}