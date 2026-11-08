
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastEducation.Desktop.Models;
using WestCoastEducation.Desktop.Services;

namespace WestCoastEducation.Desktop.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly RestDbService _restDbService;

    public MainViewModel()
    {
        _restDbService = new RestDbService(App.Configuration);
    }

    [ObservableProperty]
    public partial string Greeting { get; set; } =
        "Welcome to WestCoast Education!";

    [ObservableProperty]
    public partial string StatusMessage { get; set; } =
        "Inga uppgifter har hämtats ännu.";

    // COURSES

    public ObservableCollection<Course> Courses { get; } = new();

    public string[] CourseTypes { get; } =
        new[] { "Classroom", "Distance" };

    [ObservableProperty]
    public partial Course? SelectedCourse { get; set; }

    [ObservableProperty]
    public partial string CourseNumber { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string CourseTitle { get; set; } = string.Empty;

    [ObservableProperty]
    public partial int CourseLength { get; set; } = 1;

    [ObservableProperty]
    public partial DateTimeOffset? StartDate { get; set; } =
        DateTimeOffset.Now;

    [ObservableProperty]
    public partial DateTimeOffset? EndDate { get; set; } =
        DateTimeOffset.Now.AddDays(7);

    [ObservableProperty]
    public partial string CourseType { get; set; } = "Classroom";

    // STUDENTS

    public ObservableCollection<Student> Students { get; } = new();

    [ObservableProperty]
    public partial Student? SelectedStudent { get; set; }

    [ObservableProperty]
    public partial string StudentFirstName { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string StudentLastName { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string StudentPhone { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string StudentPersonalNumber { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string StudentAddress { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string StudentPostalCode { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string StudentCity { get; set; } = string.Empty;

    // TEACHERS

    public ObservableCollection<Teacher> Teachers { get; } = new();

    [ObservableProperty]
    public partial Teacher? SelectedTeacher { get; set; }

    [ObservableProperty]
    public partial string TeacherFirstName { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string TeacherLastName { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string TeacherPhone { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string TeacherPersonalNumber { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string TeacherAddress { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string TeacherPostalCode { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string TeacherCity { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string TeacherKnowledgeArea { get; set; } = string.Empty;

    // GET COURSES

    [RelayCommand]
    private async Task GetCoursesAsync()
    {
        try
        {
            StatusMessage = "Hämtar kurser...";

            var courses = await _restDbService.GetCoursesAsync();

            Courses.Clear();

            foreach (var course in courses)
            {
                Courses.Add(course);
            }

            StatusMessage = $"Antal kurser: {Courses.Count}";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Ett fel uppstod: {ex.Message}";
        }
    }

    // ADD COURSE

    [RelayCommand]
    private async Task AddCourseAsync()
    {
        try
        {
            if (string.IsNullOrWhiteSpace(CourseNumber) ||
                string.IsNullOrWhiteSpace(CourseTitle))
            {
                StatusMessage = "Fyll i kursnummer och kursnamn.";
                return;
            }

            if (CourseLength < 1)
            {
                StatusMessage = "Kursens längd måste vara minst en dag.";
                return;
            }

            if (StartDate == null || EndDate == null ||
                EndDate.Value.Date < StartDate.Value.Date)
            {
                StatusMessage = "Kontrollera kursens datum.";
                return;
            }

            var course = new Course
            {
                CourseNumber = CourseNumber.Trim(),
                Title = CourseTitle.Trim(),
                Length = CourseLength,
                StartDate = StartDate.Value.DateTime,
                EndDate = EndDate.Value.DateTime,
                CourseType = CourseType
            };

            await _restDbService.AddCourseAsync(course);

            CourseNumber = string.Empty;
            CourseTitle = string.Empty;
            CourseLength = 1;
            StartDate = DateTimeOffset.Now;
            EndDate = DateTimeOffset.Now.AddDays(7);
            CourseType = "Classroom";

            await GetCoursesAsync();

            StatusMessage = "Kursen har sparats!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Kunde inte spara kursen: {ex.Message}";
        }
    }

    // DELETE COURSE

    [RelayCommand]
    private async Task DeleteCourseAsync()
    {
        try
        {
            if (SelectedCourse == null)
            {
                StatusMessage = "Välj en kurs som du vill ta bort.";
                return;
            }

            string courseNumber = SelectedCourse.CourseNumber;

            await _restDbService.DeleteCourseAsync(SelectedCourse.Id);

            SelectedCourse = null;

            await GetCoursesAsync();

            StatusMessage = $"Kursen {courseNumber} har tagits bort.";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Kunde inte ta bort kursen: {ex.Message}";
        }
    }

    // GET STUDENTS

    [RelayCommand]
    private async Task GetStudentsAsync()
    {
        try
        {
            StatusMessage = "Hämtar studerande...";

            var students = await _restDbService.GetStudentsAsync();

            Students.Clear();

            foreach (var student in students)
            {
                Students.Add(student);
            }

            StatusMessage = $"Antal studerande: {Students.Count}";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Kunde inte hämta studerande: {ex.Message}";
        }
    }

    // ADD STUDENT

    [RelayCommand]
    private async Task AddStudentAsync()
    {
        try
        {
            if (string.IsNullOrWhiteSpace(StudentFirstName) ||
                string.IsNullOrWhiteSpace(StudentLastName) ||
                string.IsNullOrWhiteSpace(StudentPhone) ||
                string.IsNullOrWhiteSpace(StudentPersonalNumber) ||
                string.IsNullOrWhiteSpace(StudentAddress) ||
                string.IsNullOrWhiteSpace(StudentPostalCode) ||
                string.IsNullOrWhiteSpace(StudentCity))
            {
                StatusMessage = "Fyll i alla uppgifter för den studerande.";
                return;
            }

            var student = new Student
            {
                FirstName = StudentFirstName.Trim(),
                LastName = StudentLastName.Trim(),
                Phone = StudentPhone.Trim(),
                PersonalNumber = StudentPersonalNumber.Trim(),
                Address = StudentAddress.Trim(),
                PostalCode = StudentPostalCode.Trim(),
                City = StudentCity.Trim()
            };

            await _restDbService.AddStudentAsync(student);

            StudentFirstName = string.Empty;
            StudentLastName = string.Empty;
            StudentPhone = string.Empty;
            StudentPersonalNumber = string.Empty;
            StudentAddress = string.Empty;
            StudentPostalCode = string.Empty;
            StudentCity = string.Empty;

            await GetStudentsAsync();

            StatusMessage = "Den studerande har sparats!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Kunde inte spara studerande: {ex.Message}";
        }
    }

    // DELETE STUDENT

    [RelayCommand]
    private async Task DeleteStudentAsync()
    {
        try
        {
            if (SelectedStudent == null)
            {
                StatusMessage = "Välj en studerande som du vill ta bort.";
                return;
            }

            string studentName =
                $"{SelectedStudent.FirstName} {SelectedStudent.LastName}";

            await _restDbService.DeleteStudentAsync(SelectedStudent.Id);

            SelectedStudent = null;

            await GetStudentsAsync();

            StatusMessage = $"{studentName} har tagits bort.";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Kunde inte ta bort studerande: {ex.Message}";
        }
    }

    // GET TEACHERS

    [RelayCommand]
    private async Task GetTeachersAsync()
    {
        try
        {
            StatusMessage = "Hämtar lärare...";

            var teachers = await _restDbService.GetTeachersAsync();

            Teachers.Clear();

            foreach (var teacher in teachers)
            {
                Teachers.Add(teacher);
            }

            SelectedTeacher = null;
            TeacherKnowledgeArea = string.Empty;

            StatusMessage = $"Antal lärare: {Teachers.Count}";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Kunde inte hämta lärare: {ex.Message}";
        }
    }

    // ADD TEACHER

    [RelayCommand]
    private async Task AddTeacherAsync()
    {
        try
        {
            if (string.IsNullOrWhiteSpace(TeacherFirstName) ||
                string.IsNullOrWhiteSpace(TeacherLastName) ||
                string.IsNullOrWhiteSpace(TeacherPhone) ||
                string.IsNullOrWhiteSpace(TeacherPersonalNumber) ||
                string.IsNullOrWhiteSpace(TeacherAddress) ||
                string.IsNullOrWhiteSpace(TeacherPostalCode) ||
                string.IsNullOrWhiteSpace(TeacherCity) ||
                string.IsNullOrWhiteSpace(TeacherKnowledgeArea))
            {
                StatusMessage = "Fyll i alla uppgifter för läraren.";
                return;
            }

            var teacher = new Teacher
            {
                FirstName = TeacherFirstName.Trim(),
                LastName = TeacherLastName.Trim(),
                Phone = TeacherPhone.Trim(),
                PersonalNumber = TeacherPersonalNumber.Trim(),
                Address = TeacherAddress.Trim(),
                PostalCode = TeacherPostalCode.Trim(),
                City = TeacherCity.Trim(),
                KnowledgeArea = TeacherKnowledgeArea.Trim()
            };

            await _restDbService.AddTeacherAsync(teacher);

            TeacherFirstName = string.Empty;
            TeacherLastName = string.Empty;
            TeacherPhone = string.Empty;
            TeacherPersonalNumber = string.Empty;
            TeacherAddress = string.Empty;
            TeacherPostalCode = string.Empty;
            TeacherCity = string.Empty;
            TeacherKnowledgeArea = string.Empty;

            await GetTeachersAsync();

            StatusMessage = "Läraren har sparats!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Kunde inte spara läraren: {ex.Message}";
        }
    }

    // DELETE TEACHER

    [RelayCommand]
    private async Task DeleteTeacherAsync()
    {
        try
        {
            if (SelectedTeacher == null)
            {
                StatusMessage = "Välj en lärare som du vill ta bort.";
                return;
            }

            string teacherName =
                $"{SelectedTeacher.FirstName} {SelectedTeacher.LastName}";

            await _restDbService.DeleteTeacherAsync(SelectedTeacher.Id);

            SelectedTeacher = null;
            TeacherKnowledgeArea = string.Empty;

            await GetTeachersAsync();

            StatusMessage = $"{teacherName} har tagits bort.";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Kunde inte ta bort läraren: {ex.Message}";
        }
    }

    // UPDATE TEACHER

    partial void OnSelectedTeacherChanged(Teacher? value)
    {
        TeacherKnowledgeArea = value?.KnowledgeArea ?? string.Empty;
    }

    [RelayCommand]
    private async Task UpdateTeacherAsync()
    {
        try
        {
            if (SelectedTeacher == null)
            {
                StatusMessage = "Välj en lärare som du vill ändra.";
                return;
            }

            if (string.IsNullOrWhiteSpace(TeacherKnowledgeArea))
            {
                StatusMessage = "Ange ett kompetensområde.";
                return;
            }

            SelectedTeacher.KnowledgeArea = TeacherKnowledgeArea.Trim();

            await _restDbService.UpdateTeacherAsync(SelectedTeacher);

            await GetTeachersAsync();

            StatusMessage = "Lärarens kompetensområde har uppdaterats!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Kunde inte uppdatera läraren: {ex.Message}";
        }
    }
}