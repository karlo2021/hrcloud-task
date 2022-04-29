// IEmailAddressService.cs
//
// © 2021

using Business.DataTransferObjects.Email;

namespace Business.Services.Abstraction;

public interface IEmailAddressService
{
    public Task CreateEmailAddress(
        CreateEmailAddressDto createEmailAddressDto,
        CancellationToken cancellationToken
    );
    public Task<IEnumerable<EmailAddressDetailsDto>> GetPersonEmailAddresses(
        string firstName,
        string lastName,
        CancellationToken cancellationToken
    );
}
