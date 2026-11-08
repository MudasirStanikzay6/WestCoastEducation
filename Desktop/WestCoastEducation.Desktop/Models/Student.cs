using System.Text.Json.Serialization;

namespace WestCoastEducation.Desktop.Models;

public class Student
{
    [JsonPropertyName("_id")]
    public string Id { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string PersonalNumber { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string PostalCode { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;
}
