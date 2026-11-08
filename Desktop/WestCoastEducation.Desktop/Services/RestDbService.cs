
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WestCoastEducation.Desktop.Models;

namespace WestCoastEducation.Desktop.Services;

public class RestDbService
{
    private readonly HttpClient _httpClient;

    public RestDbService(IConfiguration configuration)
    {
        string baseUrl = configuration["RestDb:BaseUrl"]
            ?? throw new InvalidOperationException("RestDB URL is missing.");

        string apiKey = configuration["RestDb:ApiKey"]
            ?? throw new InvalidOperationException("RestDB API key is missing.");

        _httpClient = new HttpClient
        {
            BaseAddress = new Uri($"{baseUrl.TrimEnd('/')}/rest/")
        };

        _httpClient.DefaultRequestHeaders.Add("x-apikey", apiKey);
    }

    // COURSES

    public async Task<List<Course>> GetCoursesAsync()
    {
        string json = await _httpClient.GetStringAsync("courses");

        return JsonSerializer.Deserialize<List<Course>>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }
        ) ?? new List<Course>();
    }

    public async Task AddCourseAsync(Course course)
    {
        var newCourse = new
        {
            course.CourseNumber,
            course.Title,
            course.Length,
            course.StartDate,
            course.EndDate,
            course.CourseType
        };

        HttpResponseMessage response = await _httpClient.PostAsJsonAsync(
            "courses",
            newCourse
        );

        await EnsureSuccessAsync(response);
    }

    public async Task DeleteCourseAsync(string courseId)
    {
        HttpResponseMessage response = await _httpClient.DeleteAsync(
            $"courses/{Uri.EscapeDataString(courseId)}"
        );

        await EnsureSuccessAsync(response);
    }

    // STUDENTS

    public async Task<List<Student>> GetStudentsAsync()
    {
        string json = await _httpClient.GetStringAsync("students");

        return JsonSerializer.Deserialize<List<Student>>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }
        ) ?? new List<Student>();
    }

    public async Task AddStudentAsync(Student student)
    {
        var newStudent = new
        {
            student.FirstName,
            student.LastName,
            student.Phone,
            student.PersonalNumber,
            adress = student.Address,
            student.PostalCode,
            student.City
        };

        HttpResponseMessage response = await _httpClient.PostAsJsonAsync(
            "students",
            newStudent
        );

        await EnsureSuccessAsync(response);
    }

    public async Task DeleteStudentAsync(string studentId)
    {
        HttpResponseMessage response = await _httpClient.DeleteAsync(
            $"students/{Uri.EscapeDataString(studentId)}"
        );

        await EnsureSuccessAsync(response);
    }

    // TEACHERS

    public async Task<List<Teacher>> GetTeachersAsync()
    {
        string json = await _httpClient.GetStringAsync("teachers");

        return JsonSerializer.Deserialize<List<Teacher>>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }
        ) ?? new List<Teacher>();
    }

    public async Task AddTeacherAsync(Teacher teacher)
    {
        var newTeacher = new
        {
            teacher.FirstName,
            teacher.LastName,
            teacher.Phone,
            teacher.PersonalNumber,
            adress = teacher.Address,
            teacher.PostalCode,
            teacher.City,
            teacher.KnowledgeArea
        };

        HttpResponseMessage response = await _httpClient.PostAsJsonAsync(
            "teachers",
            newTeacher
        );

        await EnsureSuccessAsync(response);
    }

    public async Task DeleteTeacherAsync(string teacherId)
    {
        HttpResponseMessage response = await _httpClient.DeleteAsync(
            $"teachers/{Uri.EscapeDataString(teacherId)}"
        );

        await EnsureSuccessAsync(response);
    }

    public async Task UpdateTeacherAsync(Teacher teacher)
    {
        var updatedTeacher = new
        {
            teacher.FirstName,
            teacher.LastName,
            teacher.Phone,
            teacher.PersonalNumber,
            adress = teacher.Address,
            teacher.PostalCode,
            teacher.City,
            teacher.KnowledgeArea
        };

        HttpResponseMessage response = await _httpClient.PutAsJsonAsync(
            $"teachers/{Uri.EscapeDataString(teacher.Id)}",
            updatedTeacher
        );

        await EnsureSuccessAsync(response);
    }

    // ERROR HANDLING

    private static async Task EnsureSuccessAsync(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            string errorMessage = await response.Content.ReadAsStringAsync();

            throw new Exception(
                $"RestDB svarade med {(int)response.StatusCode} " +
                $"({response.StatusCode}). Detaljer: {errorMessage}"
            );
        }
    }
}