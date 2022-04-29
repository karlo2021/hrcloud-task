// IContactValidationService.cs
//
// © 2021

using Business.DataTransferObjects.Contact;

namespace Business.Services.Abstraction;

public interface IContactValidationService
{
    public void ValidateContact(CreateContactDto createContactDto);
}
