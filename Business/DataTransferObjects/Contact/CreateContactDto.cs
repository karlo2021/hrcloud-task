// CreateContactDto.cs
//
// © 2021

namespace Business.DataTransferObjects.Contact;

public class CreateContactDto
{
    public string Number { get; }
    public string FirstName { get; }
    public string LastName { get; }

    public CreateContactDto(string number, string firstName, string lastName)
    {
        Number = number;
        FirstName = firstName;
        LastName = lastName;
    }
}