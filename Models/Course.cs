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
        return $"{CourseNumber} - {Title} | {Length} dagar | {StartDate:yyyy-MM-dd} till {EndDate:yyyy-MM-dd} | {CourseType}";
    }
}