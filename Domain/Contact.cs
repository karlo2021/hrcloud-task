// Contact.cs
//
// © 2021

namespace Domain;

public class Contact
{
    public int Id { get; private set; }
    public string Number { get; private set; } = string.Empty;
    public int? PersonId { get; private set; }
    public Person Person { get; private set; } = null!;
    public Contact(int id, string number, int? personId)
    {
        Id = id;
        Number = number;
        PersonId = personId;
    }
    public const int MaxNumberLength = 25;
}
