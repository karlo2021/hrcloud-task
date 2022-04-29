// EmailAddressService.cs
//
// © 2021

using Microsoft.EntityFrameworkCore;

using Business.DataTransferObjects.Email;
using Business.Infrastructure;
using Business.Services.Abstraction;
using Business.Exceptions;

namespace Business.Services.Implementation;

public class EmailAddressService : IEmailAddressService
{
    private readonly IEmailAddressDatabaseContext _emailAddressDatabaseContext;
    private readonly IEmailAddressValidationService _emailAddressValidationService;
    private readonly IPersonService _personService;

    public EmailAddressService(
        IEmailAddressDatabaseContext emailAddressDatabaseContext,
        IEmailAddressValidationService emailAddressValidationService,
        IPersonService personService
    )
    {
        _emailAddressDatabaseContext = emailAddressDatabaseContext;
        _emailAddressValidationService = emailAddressValidationService;
        _personService = personService;
    }

    public async Task CreateEmailAddress(
        CreateEmailAddressDto createEmailAddressDto,
        CancellationToken cancellationToken)
    {
        _emailAddressValidationService.ValidateEmailAddress(createEmailAddressDto);

        var person = await _personService.GetPersonDetails(
            createEmailAddressDto.FirstName, createEmailAddressDto.LastName, cancellationToken
        );

        var email = new Domain.EmailAddress(
            id: default(int),
            email: createEmailAddressDto.Email,
            personId: person.Id
        );

        _emailAddressDatabaseContext.EmailAddresses.Add(email);

        await _emailAddressDatabaseContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<EmailAddressDetailsDto>> GetPersonEmailAddresses(
        string firstName,
        string lastName,
        CancellationToken cancellationToken
    )
    {
        var person = await _personService
            .GetPersonDetails(firstName, lastName, cancellationToken);

        var emails = await _emailAddressDatabaseContext
            .EmailAddresses
            .AsNoTracking()
            .Select(EmailAddressDetailsDto.Projection)
            .Where(email => email.PersonId == person.Id)
            .ToListAsync(cancellationToken);

        return emails is null ? throw new NotFoundException($"Person ${firstName} ${lastName} does not have emails!")
            : emails;
    }
}
