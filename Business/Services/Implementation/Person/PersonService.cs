// PersonService.cs
//
// © 2021

using Microsoft.EntityFrameworkCore;

using Business.DataTransferObjects.Person;
using Business.Exceptions;
using Business.Infrastructure;
using Business.Services.Abstraction;
using Domain.Enumeration;

namespace Business.Services.Implementation;

public class PersonService : IPersonService
{
    private readonly IPersonDatabaseContext _personDatabaseContext;
    private readonly IPersonValidationService _personValidationService;

    public PersonService(
        IPersonDatabaseContext personDatabaseContext,
        IPersonValidationService personValidationService
    )
    {
        _personDatabaseContext = personDatabaseContext;
        _personValidationService = personValidationService;
    }
    public async Task CreatePerson(CreatePersonDto createPersonDto, CancellationToken cancellationToken)
    {
        _personValidationService.ValidatePerson(createPersonDto);

        var person = new Domain.Person(
            id: default(int),
            firstName: createPersonDto.FirstName,
            lastName: createPersonDto.LastName,
            address: createPersonDto.Address,
            tag: (Tag)Enum.Parse(typeof(Tag), createPersonDto.Tag)
        );

        _personDatabaseContext.Persons.Add(person);
        await _personDatabaseContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<PersonDetailsDto> GetPersonDetails(
        string firstName,
        string lastName,
        CancellationToken cancellationToken)
    {
        var person = await _personDatabaseContext
            .Persons
            .AsNoTracking()
            .Select(PersonDetailsDto.Projection)
            .FirstOrDefaultAsync(
                person => person.FirstName == firstName && person.LastName == lastName,
                cancellationToken
            );

        return person is null ? throw new NotFoundException($"Person ${firstName} ${lastName} not found")
            : person;
    }

    public async Task<IEnumerable<PersonDetailsDto>> GetPersons(
        int take,
        int skip,
        CancellationToken cancellationToken)
    {
        var persons = await _personDatabaseContext
            .Persons
            .AsNoTracking()
            .Select(PersonDetailsDto.Projection)
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);

        return persons;
    }

    public async Task<IEnumerable<PersonDetailsDto>> GetFriendPersons(
        int take,
        int skip,
        CancellationToken cancellationToken)
    {
        var friendPersons = await _personDatabaseContext
            .Persons
            .AsNoTracking()
            .Where(person => person.Tag == Tag.Friend)
            .Select(PersonDetailsDto.Projection)
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);

        return friendPersons;
    }
}
