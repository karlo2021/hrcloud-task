// PersonViewService.cs
//
// © 2021

using Business.Services.Abstraction;
using Business.JointObjectView;

namespace Business.Services.Implementation;

public class PersonViewService : IPersonViewService
{
    private readonly IContactService _contactService;
    private readonly IPersonService _personService;
    private readonly IEmailAddressService _emailAddressService;

    public PersonViewService(
        IContactService contactService,
        IPersonService personService,
        IEmailAddressService emailAddressService
    )
    {
        _contactService = contactService;
        _personService = personService;
        _emailAddressService = emailAddressService;
    }

    public async Task<CreatePersonView> GetPersonViewDetails(string firstName, string lastName, CancellationToken cancellationToken)
    {
        var contacts = await _contactService
            .GetPersonContacts(firstName, lastName, cancellationToken);

        var emailAddresses = await _emailAddressService
            .GetPersonEmailAddresses(firstName, lastName, cancellationToken);

        var person = await _personService
            .GetPersonDetails(firstName, lastName, cancellationToken);

        var createPersonView = new CreatePersonView(
            personDetailsDto: person,
            contactDetailsDto: contacts,
            emailAddressDetailsDto: emailAddresses
        );

        return createPersonView;
    }
    public async Task<IEnumerable<CreatePersonView>> GetPersonsView(int take, int skip, CancellationToken cancellationToken)
    {
        var persons = await _personService
            .GetPersons(take: take, skip: skip, cancellationToken: cancellationToken);

        ICollection<CreatePersonView> personsViewCollection = new List<CreatePersonView>();
        IEnumerable<CreatePersonView> personsViewEnumerable;

        foreach (var person in persons)
        {
            var contacts = await _contactService
                .GetPersonContacts(
                    firstName: person.FirstName,
                    lastName: person.LastName,
                    cancellationToken: cancellationToken
                );

            var emailAddresses = await _emailAddressService
                .GetPersonEmailAddresses(
                    firstName: person.FirstName,
                    lastName: person.LastName,
                    cancellationToken: cancellationToken
                );

            var createPersonView = new CreatePersonView(
                personDetailsDto: person,
                contactDetailsDto: contacts,
                emailAddressDetailsDto: emailAddresses
            );

            personsViewCollection.Add(createPersonView);
        }

        personsViewEnumerable = personsViewCollection;

        return personsViewEnumerable;
    }

    public async Task<IEnumerable<CreatePersonView>> GetFriendPersonsView(int take, int skip, CancellationToken cancellationToken)
    {
        var persons = await _personService
            .GetFriendPersons(take: take, skip: skip, cancellationToken: cancellationToken);

        ICollection<CreatePersonView> personsViewCollection = new List<CreatePersonView>();
        IEnumerable<CreatePersonView> personsViewEnumerable;

        foreach (var person in persons)
        {
            var contacts = await _contactService
                .GetPersonContacts(
                    firstName: person.FirstName,
                    lastName: person.LastName,
                    cancellationToken: cancellationToken
                );

            var emailAddresses = await _emailAddressService
                .GetPersonEmailAddresses(
                    firstName: person.FirstName,
                    lastName: person.LastName,
                    cancellationToken: cancellationToken
                );

            var createPersonView = new CreatePersonView(
                personDetailsDto: person,
                contactDetailsDto: contacts,
                emailAddressDetailsDto: emailAddresses
            );

            personsViewCollection.Add(createPersonView);
        }

        personsViewEnumerable = personsViewCollection;

        return personsViewEnumerable;
    }
}