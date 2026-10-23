using WestCoastEducation.Helpers;
using WestCoastEducation.Models;
using WestCoastEducation.Services;

namespace WestCoastEducation.UI;

public class MenuHandler
{
    private readonly EducationService _educationService = new EducationService();

    public void Run()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine("       WESTCOAST EDUCATION");
            Console.WriteLine("========================================");
            Console.WriteLine("  1. Lista kurser");
            Console.WriteLine("  2. Lägg till kurs");
            Console.WriteLine("  3. Lista studerande");
            Console.WriteLine("  4. Lägg till studerande");
            Console.WriteLine("  5. Lista lärare");
            Console.WriteLine("  6. Lägg till lärare");
            Console.WriteLine("  7. Koppla lärare till kurs");
            Console.WriteLine("  8. Lägg till utbildningsledare");
            Console.WriteLine("  9. Lista utbildningsledare");
            Console.WriteLine(" 10. Lägg till administratör");
            Console.WriteLine(" 11. Lista administratörer");
            Console.WriteLine(" 12. Avsluta");
            Console.WriteLine("----------------------------------------");
            Console.Write("Välj ett alternativ: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _educationService.ListCourses();
                    break;

                case "2":
                    AddCourse();
                    break;

                case "3":
                    _educationService.ListStudents();
                    break;

                case "4":
                    AddStudent();
                    break;

                case "5":
                    _educationService.ListTeachers();
                    break;

                case "6":
                    AddTeacher();
                    break;

                case "7":
                    AssignTeacherToCourse();
                    break;

                case "8":
                    AddEducationLeader();
                    break;

                case "9":
                    _educationService.ListEducationLeaders();
                    break;

                case "10":
                    AddAdministrator();
                    break;

                case "11":
                    _educationService.ListAdministrators();
                    break;

                case "12":
                    running = false;
                    Console.WriteLine();
                    Console.WriteLine("Programmet avslutas. Tack för besöket!");
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    break;
            }
        }
    }

    private void AddCourse()
    {
        Console.WriteLine();
        Console.WriteLine("------------ LÄGG TILL KURS ------------");
        Console.WriteLine();

        string courseNumber = InputHelper.ReadRequiredText("Kursnummer: ");
        string title = InputHelper.ReadRequiredText("Kurstitel: ");

        int length;

        while (true)
        {
            Console.Write("Längd i dagar: ");

            if (int.TryParse(Console.ReadLine(), out length) && length > 0)
            {
                break;
            }

            Console.WriteLine("Ange ett heltal större än 0.");
        }

        DateTime startDate = InputHelper.ReadDate("Startdatum (ÅÅÅÅ-MM-DD): ");
        DateTime endDate;

        while (true)
        {
            endDate = InputHelper.ReadDate("Slutdatum (ÅÅÅÅ-MM-DD): ");

            if (endDate >= startDate)
            {
                break;
            }

            Console.WriteLine("Slutdatumet får inte vara före startdatumet.");
        }

        string courseType;

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Välj kurssätt:");
            Console.WriteLine("  1. Klassrum");
            Console.WriteLine("  2. Distans");
            Console.Write("Ditt val: ");

            string? typeChoice = Console.ReadLine();

            if (typeChoice == "1")
            {
                courseType = "Klassrum";
                break;
            }

            if (typeChoice == "2")
            {
                courseType = "Distans";
                break;
            }

            Console.WriteLine("Ogiltigt val. Välj 1 eller 2.");
        }

        Course course = new Course
        {
            CourseNumber = courseNumber,
            Title = title,
            Length = length,
            StartDate = startDate,
            EndDate = endDate,
            CourseType = courseType
        };

        _educationService.AddCourse(course);

        Console.WriteLine();
        Console.WriteLine("Kursen har registrerats!");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine(course);
        Console.WriteLine("----------------------------------------");
    }

    private void AddStudent()
    {
        Console.WriteLine();
        Console.WriteLine("--------- LÄGG TILL STUDERANDE ---------");
        Console.WriteLine();

        Student student = new Student
        {
            FirstName = InputHelper.ReadRequiredText("Förnamn: "),
            LastName = InputHelper.ReadRequiredText("Efternamn: "),
            Phone = InputHelper.ReadRequiredText("Telefon: "),
            PersonalNumber = InputHelper.ReadRequiredText("Personnummer: "),
            Address = InputHelper.ReadRequiredText("Adress: "),
            PostalCode = InputHelper.ReadRequiredText("Postnummer: "),
            City = InputHelper.ReadRequiredText("Ort: ")
        };

        _educationService.AddStudent(student);

        Console.WriteLine();
        Console.WriteLine("Studeranden har registrerats!");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine(student);
        Console.WriteLine("----------------------------------------");
    }

    private void AddTeacher()
    {
        Console.WriteLine();
        Console.WriteLine("----------- LÄGG TILL LÄRARE -----------");
        Console.WriteLine();

        Teacher teacher = new Teacher
        {
            FirstName = InputHelper.ReadRequiredText("Förnamn: "),
            LastName = InputHelper.ReadRequiredText("Efternamn: "),
            Phone = InputHelper.ReadRequiredText("Telefon: "),
            PersonalNumber = InputHelper.ReadRequiredText("Personnummer: "),
            Address = InputHelper.ReadRequiredText("Adress: "),
            PostalCode = InputHelper.ReadRequiredText("Postnummer: "),
            City = InputHelper.ReadRequiredText("Ort: "),
            KnowledgeArea = InputHelper.ReadRequiredText("Kunskapsområde: ")
        };

        _educationService.AddTeacher(teacher);

        Console.WriteLine();
        Console.WriteLine("Läraren har registrerats!");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine(teacher);
        Console.WriteLine("----------------------------------------");
    }

    private void AddEducationLeader()
    {
        Console.WriteLine();
        Console.WriteLine("------ LÄGG TILL UTBILDNINGSLEDARE ------");
        Console.WriteLine();

        EducationLeader educationLeader = new EducationLeader
        {
            FirstName = InputHelper.ReadRequiredText("Förnamn: "),
            LastName = InputHelper.ReadRequiredText("Efternamn: "),
            Phone = InputHelper.ReadRequiredText("Telefon: "),
            PersonalNumber = InputHelper.ReadRequiredText("Personnummer: "),
            Address = InputHelper.ReadRequiredText("Adress: "),
            PostalCode = InputHelper.ReadRequiredText("Postnummer: "),
            City = InputHelper.ReadRequiredText("Ort: "),
            KnowledgeArea = InputHelper.ReadRequiredText("Kunskapsområde: "),
            EmploymentDate = InputHelper.ReadDate("Anställningsdatum (ÅÅÅÅ-MM-DD): ")
        };

        _educationService.AddEducationLeader(educationLeader);

        Console.WriteLine();
        Console.WriteLine("Utbildningsledaren har registrerats!");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine(educationLeader);
        Console.WriteLine("----------------------------------------");
    }

    private void AddAdministrator()
    {
        Console.WriteLine();
        Console.WriteLine("--------- LÄGG TILL ADMINISTRATÖR --------");
        Console.WriteLine();

        Administrator administrator = new Administrator
        {
            FirstName = InputHelper.ReadRequiredText("Förnamn: "),
            LastName = InputHelper.ReadRequiredText("Efternamn: "),
            Phone = InputHelper.ReadRequiredText("Telefon: "),
            PersonalNumber = InputHelper.ReadRequiredText("Personnummer: "),
            Address = InputHelper.ReadRequiredText("Adress: "),
            PostalCode = InputHelper.ReadRequiredText("Postnummer: "),
            City = InputHelper.ReadRequiredText("Ort: "),
            KnowledgeArea = InputHelper.ReadRequiredText("Kunskapsområde: "),
            EmploymentDate = InputHelper.ReadDate("Anställningsdatum (ÅÅÅÅ-MM-DD): ")
        };

        _educationService.AddAdministrator(administrator);

        Console.WriteLine();
        Console.WriteLine("Administratören har registrerats!");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine(administrator);
        Console.WriteLine("----------------------------------------");
    }

    private void AssignTeacherToCourse()
    {
        List<Teacher> teachers = _educationService.GetTeachers();
        List<Course> courses = _educationService.GetCourses();

        Console.WriteLine();
        Console.WriteLine("--------- KOPPLA LÄRARE TILL KURS ---------");

        if (teachers.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine("Det finns inga lärare ännu.");
            return;
        }

        if (courses.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine("Det finns inga kurser ännu.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Välj lärare:");

        for (int i = 0; i < teachers.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {teachers[i].FirstName} {teachers[i].LastName}");
        }

        Console.Write("Ditt val: ");

        if (!int.TryParse(Console.ReadLine(), out int teacherChoice) ||
            teacherChoice < 1 ||
            teacherChoice > teachers.Count)
        {
            Console.WriteLine("Ogiltigt val.");
            return;
        }

        Teacher selectedTeacher = teachers[teacherChoice - 1];

        Console.WriteLine();
        Console.WriteLine("Välj kurs:");

        for (int i = 0; i < courses.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {courses[i].CourseNumber} - {courses[i].Title}");
        }

        Console.Write("Ditt val: ");

        if (!int.TryParse(Console.ReadLine(), out int courseChoice) ||
            courseChoice < 1 ||
            courseChoice > courses.Count)
        {
            Console.WriteLine("Ogiltigt val.");
            return;
        }

        Course selectedCourse = courses[courseChoice - 1];

        _educationService.AssignCourseToTeacher(selectedTeacher, selectedCourse);

        Console.WriteLine();
        Console.WriteLine("Kursen har kopplats till läraren!");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"Lärare: {selectedTeacher.FirstName} {selectedTeacher.LastName}");
        Console.WriteLine($"Kurs:   {selectedCourse.CourseNumber} - {selectedCourse.Title}");
        Console.WriteLine("----------------------------------------");
    }
}