// ContactDetailsDto.cs
//
// © 2021

using System.Linq.Expressions;

namespace Business.DataTransferObjects.Contact;

public class ContactDetailsDto
{
    public int Id { get; private set; }
    public string Number { get; private set; } = string.Empty;
    public int? PersonId { get; private set; }
    public static Expression<Func<Domain.Contact, ContactDetailsDto>> Projection
    {
        get
        {
            return contact => new ContactDetailsDto
            {
                Id = contact.Id,
                Number = contact.Number,
                PersonId = contact.PersonId
            };
        }
    }
}
