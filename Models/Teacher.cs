namespace WestCoastEducation.Models;

public class Teacher : Person
{
    public required string KnowledgeArea { get; set; }
    public List<Course> Courses { get; set; } = new List<Course>();

    public override string ToString()
    {
        return $"{FirstName} {LastName} | Kunskapsområde: {KnowledgeArea} | Ansvarar för: {Courses.Count} kurser";
    }
}