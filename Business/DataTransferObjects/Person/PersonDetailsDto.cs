// PersonDetailsDto.cs
//
// © 2021

using System.Linq.Expressions;

namespace Business.DataTransferObjects.Person;

public class PersonDetailsDto
{
    private PersonDetailsDto() { }
    public int Id { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Address { get; private set; } = string.Empty;
    public string Tag { get; private set; } = string.Empty;

    public static Expression<Func<Domain.Person, PersonDetailsDto>> Projection
    {
        get
        {
            return person => new PersonDetailsDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Address = person.Address,
                Tag = person.Tag.ToString()
            };
        }
    }
}
