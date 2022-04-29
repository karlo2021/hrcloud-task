// CreatePersonView.cs
//
// © 2021

using Business.DataTransferObjects.Contact;
using Business.DataTransferObjects.Email;
using Business.DataTransferObjects.Person;

namespace Business.JointObjectView;

public class CreatePersonView
{
    public PersonDetailsDto Person { get; private set; } = null!;
    public IEnumerable<ContactDetailsDto> Contacts { get; set; } = null!;
    public IEnumerable<EmailAddressDetailsDto> EmailAddresses { get; set; } = null!;
    public CreatePersonView(
        PersonDetailsDto personDetailsDto,
        IEnumerable<ContactDetailsDto> contactDetailsDto,
        IEnumerable<EmailAddressDetailsDto> emailAddressDetailsDto)
    {
        Person = personDetailsDto;
        Contacts = contactDetailsDto;
        EmailAddresses = emailAddressDetailsDto;
    }
}
