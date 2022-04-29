// IContactService.cs
//
// © 2021

using Business.DataTransferObjects.Contact;

namespace Business.Services.Abstraction;

public interface IContactService
{
    public Task CreateContact(CreateContactDto createContactDto, CancellationToken cancellationToken);
    public Task<IEnumerable<ContactDetailsDto>> GetPersonContacts(string firstName, string lastName, CancellationToken cancellationToken);

}
