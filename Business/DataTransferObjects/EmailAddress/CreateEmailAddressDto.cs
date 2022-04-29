// CreateEmailAddressDto.cs
//
// © 2021

namespace Business.DataTransferObjects.Email;

public class CreateEmailAddressDto
{
    public string Email { get; }
    public string FirstName { get; } = string.Empty;
    public string LastName { get; } = string.Empty;
    public CreateEmailAddressDto(string email, string firstName, string lastName)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }
}
