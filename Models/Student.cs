namespace WestCoastEducation.Models;

public class Student : Person
{
    public override string ToString()
    {
        return $"{FirstName} {LastName} | Telefon: {Phone} | Personnummer: {PersonalNumber} | Adress: {Address}, {PostalCode} {City}";
    }
}