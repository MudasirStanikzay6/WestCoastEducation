namespace WestCoastEducation.Models;

public class Student : Person
{
    public override string ToString()
    {
    return
        $"Förnamn:    {FirstName}\n" +
        $"Efternamn:  {LastName}\n" +
        $"Telefon:    {Phone}\n" +
        $"Personnummer: {PersonalNumber}\n" +
        $"Adress:     {Address}\n" +
        $"Postnummer: {PostalCode}\n" +
        $"Ort:        {City}";
    }   
}