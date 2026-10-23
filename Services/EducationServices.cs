using WestCoastEducation.Models;

namespace WestCoastEducation.Services;

public class EducationService
{
    private readonly List<Course> _courses = new List<Course>();
    private readonly List<Student> _students = new List<Student>();
    private readonly List<Teacher> _teachers = new List<Teacher>();
    private readonly List<EducationLeader> _educationLeaders = new List<EducationLeader>();
    private readonly List<Administrator> _administrators = new List<Administrator>();

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

    public void AddStudent(Student student)
    {
        _students.Add(student);
    }

    public void ListStudents()
    {
        Console.WriteLine();
        Console.WriteLine("=========== STUDERANDELISTA ===========");

        if (_students.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine("Det finns inga studerande ännu.");
            return;
        }

        Console.WriteLine();

        foreach (Student student in _students)
        {
            Console.WriteLine(student);
            Console.WriteLine("----------------------------------------");
        }

        Console.WriteLine($"Totalt antal studerande: {_students.Count}");
    }

    public void AddTeacher(Teacher teacher)
    {
        _teachers.Add(teacher);
    }

    public void AssignCourseToTeacher(Teacher teacher, Course course)
    {
        teacher.Courses.Add(course);
    }

    public List<Teacher> GetTeachers()
    {
        return _teachers;
    }

    public List<Course> GetCourses()
    {
        return _courses;
    }

    public void ListTeachers()
    {
        Console.WriteLine();
        Console.WriteLine("============== LÄRARLISTA =============");

        if (_teachers.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine("Det finns inga lärare ännu.");
            return;
        }

        Console.WriteLine();

        foreach (Teacher teacher in _teachers)
        {
            Console.WriteLine(teacher);
            Console.WriteLine("----------------------------------------");
        }

        Console.WriteLine($"Totalt antal lärare: {_teachers.Count}");
    }

    public void AddEducationLeader(EducationLeader educationLeader)
    {
        _educationLeaders.Add(educationLeader);
    }

    public void ListEducationLeaders()
    {
        Console.WriteLine();
        Console.WriteLine("========= UTBILDNINGSLEDARE =========");

        if (_educationLeaders.Count == 0)
        {
            Console.WriteLine("Det finns inga utbildningsledare ännu.");
            return;
        }

        foreach (EducationLeader educationLeader in _educationLeaders)
        {
            Console.WriteLine(educationLeader);
            Console.WriteLine("----------------------------------------");
        }
    }

    public void AddAdministrator(Administrator administrator)
    {
        _administrators.Add(administrator);
    }

    public void ListAdministrators()
    {
        Console.WriteLine();
        Console.WriteLine("========== ADMINISTRATÖRER ==========");

        if (_administrators.Count == 0)
        {
            Console.WriteLine("Det finns inga administratörer ännu.");
            return;
        }

        foreach (Administrator administrator in _administrators)
        {
            Console.WriteLine(administrator);
            Console.WriteLine("----------------------------------------");
        }
    }
}