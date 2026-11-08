using System;
using System.Text.Json.Serialization;

namespace WestCoastEducation.Desktop.Models;

public class Course
{
    [JsonPropertyName("_id")]
    public string Id { get; set; } = string.Empty;

    public string CourseNumber { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public int Length { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string CourseType { get; set; } = string.Empty;
}