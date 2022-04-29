// IEmailAddressValidationService.cs
//
// © 2021

using Business.DataTransferObjects.Email;

namespace Business.Services.Abstraction;

public interface IEmailAddressValidationService
{
    public void ValidateEmailAddress(CreateEmailAddressDto createEmailAddressDto);
}
