// EmailAddressValidationService.cs
//
// © 2021

using System.ComponentModel.DataAnnotations;

using Business.DataTransferObjects.Email;
using Business.Services.Abstraction;
namespace Business.Services.Implementation;

public class EmailAddressValidationService : IEmailAddressValidationService
{
    public void ValidateEmailAddress(CreateEmailAddressDto createEmailAddressDto)
    {
        if (string.IsNullOrEmpty(createEmailAddressDto.Email))
        {
            var message = $"Email address is empty!";
            throw new ValidationException(message);
        }

        if (!createEmailAddressDto.Email.Contains('@'))
        {
            var message = $"Invalid email address sintax!";
            throw new ValidationException(message);
        }

        if (createEmailAddressDto.Email.Length >= Domain.EmailAddress.MaxEmailLength)
        {
            var message = $"Email address is to long. Must be less than ${Domain.EmailAddress.MaxEmailLength}";
            throw new ValidationException(message);
        }
    }
}
