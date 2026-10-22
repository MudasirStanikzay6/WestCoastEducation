namespace WestCoastEducation.Models;

public class Course
{
    public required string CourseNumber { get; set; }
    public required string Title { get; set; }
    public int Length { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public required string CourseType { get; set; }

    public override string ToString()
    {
        return
            $"Kursnummer: {CourseNumber}\n" +
            $"Titel:      {Title}\n" +
            $"Längd:      {Length} dagar\n" +
            $"Startdatum: {StartDate:yyyy-MM-dd}\n" +
            $"Slutdatum:  {EndDate:yyyy-MM-dd}\n" +
            $"Kurssätt:   {CourseType}";
    }
}