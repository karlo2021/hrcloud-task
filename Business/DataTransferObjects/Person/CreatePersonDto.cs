// CreatePersonDto.cs
//
// © 2021

namespace Business.DataTransferObjects.Person;

public class CreatePersonDto
{
    public string Address { get; } = string.Empty;
    public string FirstName { get; } = string.Empty;
    public string LastName { get; } = string.Empty;
    public string Tag { get; } = string.Empty;
    public CreatePersonDto(string address, string firstName, string lastName, string tag = "Regular")
    {
        Address = address;
        FirstName = firstName;
        LastName = lastName;
        Tag = tag;
    }
}
