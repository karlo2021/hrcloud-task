// EmailAddress.cs
//
// © 2021

namespace Domain;

public class EmailAddress
{
    public int Id { get; private set; }
    public string Email { get; private set; } = string.Empty;
    public int? PersonId { get; private set; }
    public Person Person { get; private set; } = null!;
    public EmailAddress(int id, string email, int? personId)
    {
        Id = id;
        Email = email;
        PersonId = personId;
    }
    public const int MaxEmailLength = 50;
}