// ContactController.cs
//
// © 2021

using Microsoft.AspNetCore.Mvc;

using Business.Services.Abstraction;
using Business.DataTransferObjects.Contact;

namespace WebApi.Controllers;

[ApiController]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;
    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet]
    [Route("api/contacts/{firstName}/{lastName}")]
    public async Task<IActionResult> GetPersonContacts(
        [FromRoute] string firstName,
        [FromRoute] string lastName,
        CancellationToken cancellationToken)
    {
        var contacts = await _contactService
            .GetPersonContacts(
                firstName: firstName,
                lastName: lastName,
                cancellationToken: cancellationToken
            );

        return Ok(contacts);
    }

    [HttpPost]
    [Route("api/contacts")]
    public async Task<IActionResult> CreateContact(
        [FromBody] CreateContactDto createContactDto,
        CancellationToken cancellationToken)
    {
        await _contactService.CreateContact(
            createContactDto: createContactDto,
            cancellationToken: cancellationToken);

        return CreatedAtAction(nameof(CreateContact), createContactDto);

    }
}
