// ContactService.cs
//
// © 2021

using Business.DataTransferObjects.Contact;
using Business.Exceptions;
using Business.Infrastructure;
using Business.Services.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Business.Services.Implementation;

public class ContactService : IContactService
{
    private readonly IContactDatabaseContext _contactDatabaseContext;
    private readonly IContactValidationService _contactValidationService;
    private readonly IPersonService _personService;

    public ContactService(
        IContactDatabaseContext contactDatabaseContext,
        IContactValidationService contactValidationService,
        IPersonService personService)
    {
        _contactDatabaseContext = contactDatabaseContext;
        _contactValidationService = contactValidationService;
        _personService = personService;
    }

    public async Task CreateContact(
        CreateContactDto createContactDto,
        CancellationToken cancellationToken)
    {
        _contactValidationService.ValidateContact(createContactDto);

        var person = await _personService.GetPersonDetails(
           createContactDto.FirstName, createContactDto.LastName, cancellationToken
        );

        var contact = new Domain.Contact(
            id: default(int),
            number: createContactDto.Number,
            personId: person.Id
        );

        _contactDatabaseContext.Contacts.Add(contact);

        await _contactDatabaseContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<ContactDetailsDto>> GetPersonContacts(
        string firstName,
        string lastName,
        CancellationToken cancellationToken
    )
    {
        var person = await _personService
            .GetPersonDetails(firstName, lastName, cancellationToken);

        var contacts = await _contactDatabaseContext
            .Contacts
            .AsNoTracking()
            .Select(ContactDetailsDto.Projection)
            .Where(contact => contact.PersonId == person.Id)
            .ToListAsync(cancellationToken);

        return contacts is null ? throw new NotFoundException($"Person ${firstName} ${lastName} does not have contacts!")
            : contacts;
    }
}
