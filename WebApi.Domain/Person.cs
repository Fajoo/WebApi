namespace WebApi.Domain;

public class Person
{
    public Guid Id { get; set; }
    public string FIO { get; set; }
    public DateTime DateOfBirth { get; set; }
}