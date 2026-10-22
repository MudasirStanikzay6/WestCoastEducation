namespace WestCoastEducation.Models;

public class Administrator : EducationLeader
{
    public override string ToString()
    {
        return $"{FirstName} {LastName} | Kunskapsområde: {KnowledgeArea} | Anställningsdatum: {EmploymentDate:yyyy-MM-dd}";
    }
}