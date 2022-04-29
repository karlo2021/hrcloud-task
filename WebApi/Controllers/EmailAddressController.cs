// EmailAddressController.cs
//
// © 2021

using Microsoft.AspNetCore.Mvc;

using Business.Services.Abstraction;
using Business.DataTransferObjects.Email;

namespace WebApi.Controllers;

public class EmailAddressController : ControllerBase
{
    private readonly IEmailAddressService _emailAddressService;
    public EmailAddressController(IEmailAddressService emailAddressService)
    {
        _emailAddressService = emailAddressService;
    }

    [HttpPost]
    [Route("api/emails")]
    public async Task<IActionResult> CreateEmail(
        [FromBody] CreateEmailAddressDto createEmailAddressDto,
        CancellationToken cancellationToken)
    {
        await _emailAddressService.CreateEmailAddress(
            createEmailAddressDto: createEmailAddressDto,
            cancellationToken: cancellationToken);

        return CreatedAtAction(nameof(CreateEmail), createEmailAddressDto);
    }
    [HttpGet]
    [Route("api/emails/{firstName}/{lastName}")]
    public async Task<IActionResult> GetPersonEmails(
        [FromRoute] string firstName,
        [FromRoute] string lastName,
        CancellationToken cancellationToken)
    {
        var emails = await _emailAddressService
            .GetPersonEmailAddresses(
                firstName: firstName,
                lastName: lastName,
                cancellationToken: cancellationToken
            );

        return Ok(emails);
    }
}
