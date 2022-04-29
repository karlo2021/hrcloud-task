// ContactValidationService.cs
//
// © 2021

using System.ComponentModel.DataAnnotations;

using Business.DataTransferObjects.Contact;
using Business.Services.Abstraction;
using Domain;

namespace Business.Services.Implementation;

public class ContactValidationService : IContactValidationService
{
    public void ValidateContact(CreateContactDto createContactDto)
    {
        if (string.IsNullOrEmpty(createContactDto.Number))
        {
            throw new ValidationException($"Contact number is empty!");
        }

        if (createContactDto.Number.Length >= Contact.MaxNumberLength)
        {
            var message = $"Phone number is to long. Must be less than ${Contact.MaxNumberLength}";
            throw new ValidationException(message);
        }
    }
}
