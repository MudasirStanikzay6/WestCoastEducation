using System.Globalization;
using WestCoastEducation.Models;
using WestCoastEducation.Services;

EducationService educationService = new EducationService();

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
    Console.WriteLine("  5. Avsluta");
    Console.WriteLine("----------------------------------------");
    Console.Write("Välj ett alternativ: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            educationService.ListCourses();
            break;

        case "2":
            Console.WriteLine();
            Console.WriteLine("------------ LÄGG TILL KURS ------------");
            Console.WriteLine();

            string courseNumber = ReadRequiredText("Kursnummer: ");
            string title = ReadRequiredText("Kurstitel: ");

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

            DateTime startDate = ReadDate("Startdatum (ÅÅÅÅ-MM-DD): ");
            DateTime endDate;

            while (true)
            {
                endDate = ReadDate("Slutdatum (ÅÅÅÅ-MM-DD): ");

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

            educationService.AddCourse(course);

            Console.WriteLine();
            Console.WriteLine("Kursen har registrerats!");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine(course);
            Console.WriteLine("----------------------------------------");
            break;

        case "3":
            educationService.ListStudents();
            break;

        case "4":
            Console.WriteLine();
            Console.WriteLine("--------- LÄGG TILL STUDERANDE ---------");
            Console.WriteLine();

            string firstName = ReadRequiredText("Förnamn: ");
            string lastName = ReadRequiredText("Efternamn: ");
            string phone = ReadRequiredText("Telefon: ");
            string personalNumber = ReadRequiredText("Personnummer: ");
            string address = ReadRequiredText("Adress: ");
            string postalCode = ReadRequiredText("Postnummer: ");
            string city = ReadRequiredText("Ort: ");

            Student student = new Student
            {
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
                PersonalNumber = personalNumber,
                Address = address,
                PostalCode = postalCode,
                City = city
            };

            educationService.AddStudent(student);

            Console.WriteLine();
            Console.WriteLine("Studeranden har registrerats!");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine(student);
            Console.WriteLine("----------------------------------------");
            break;

        case "5":
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

static string ReadRequiredText(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(input))
        {
            return input.Trim();
        }

        Console.WriteLine("Fältet får inte vara tomt.");
    }
}

static DateTime ReadDate(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();

        if (DateTime.TryParseExact(
            input,
            "yyyy-MM-dd",
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out DateTime date))
        {
            return date;
        }

        Console.WriteLine(
            "Ogiltigt datum. Exempel på korrekt format: 2026-10-22.");
    }
}