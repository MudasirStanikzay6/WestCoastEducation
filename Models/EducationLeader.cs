namespace WestCoastEducation.Models;

public class EducationLeader : Teacher
{
    public DateTime EmploymentDate { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName} | Kunskapsområde: {KnowledgeArea} | Anställningsdatum: {EmploymentDate:yyyy-MM-dd}";
    }
}