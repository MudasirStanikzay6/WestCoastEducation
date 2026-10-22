using WestCoastEducation.Models;

namespace WestCoastEducation.Services;

public class EducationService
{
    private readonly List<Course> _courses = new List<Course>();
    private readonly List<Student> _students = new List<Student>();

    public void AddCourse(Course course)
    {
        _courses.Add(course);
    }

    public void ListCourses()
    {
        Console.WriteLine();
        Console.WriteLine("============== KURSLISTA ==============");

        if (_courses.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine("Det finns inga kurser ännu.");
            return;
        }

        Console.WriteLine();

        foreach (Course course in _courses)
        {
            Console.WriteLine(course);
            Console.WriteLine("----------------------------------------");
        }

        Console.WriteLine($"Totalt antal kurser: {_courses.Count}");
    }
}