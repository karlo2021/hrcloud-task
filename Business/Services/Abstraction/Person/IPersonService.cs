// IPersonService.cs
//
// © 2021

using Business.DataTransferObjects.Person;

namespace Business.Services.Abstraction;

public interface IPersonService
{
    public Task CreatePerson(CreatePersonDto createPersonDto, CancellationToken cancellationToken);
    public Task<PersonDetailsDto> GetPersonDetails(string firstName, string lastName, CancellationToken cancellationToken);
    public Task<IEnumerable<PersonDetailsDto>> GetPersons(int take, int skip, CancellationToken cancellationToken);
    public Task<IEnumerable<PersonDetailsDto>> GetFriendPersons(int take, int skip, CancellationToken cancellationToken);
}
