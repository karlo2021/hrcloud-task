// EmailAddressDetailsDto.cs
//
// © 2021

using System.Linq.Expressions;

namespace Business.DataTransferObjects.Email;

public class EmailAddressDetailsDto
{
    public int Id { get; private set; }
    public string Email { get; private set; } = string.Empty;
    public int? PersonId { get; private set; }
    public static Expression<Func<Domain.EmailAddress, EmailAddressDetailsDto>> Projection
    {
        get
        {
            return email => new EmailAddressDetailsDto
            {
                Id = email.Id,
                Email = email.Email,
                PersonId = email.PersonId
            };
        }
    }
}
