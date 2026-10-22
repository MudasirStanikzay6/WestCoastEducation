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
        Console.WriteLine("  3. Avsluta");
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
    }
}