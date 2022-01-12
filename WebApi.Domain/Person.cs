namespace WebApi.Domain;

/// <summary>
/// Test entity person
/// </summary>
public class Person
{
    /// <summary>
    /// Unique id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Full Name
    /// </summary>
    public string FIO { get; set; }
    /// <summary>
    /// Date of Birth
    /// </summary>
    public DateTime DateOfBirth { get; set; }
}