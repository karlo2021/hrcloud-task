// PersonViewController.cs
//
// © 2021

using Microsoft.AspNetCore.Mvc;

using Business.Services.Abstraction;

namespace WebApi.Controllers;

[ApiController]
public class PersonViewController : ControllerBase
{
    private readonly IPersonViewService _personViewService;
    public PersonViewController(IPersonViewService personViewService)
    {
        _personViewService = personViewService;
    }

    [HttpGet]
    [Route("api/application/{firstName}/{lastName}")]
    public async Task<IActionResult> GetPersonView(
        [FromRoute] string firstName,
        [FromRoute] string lastName,
        CancellationToken cancellationToken)
    {
        var person = await _personViewService
            .GetPersonViewDetails(
                firstName: firstName,
                lastName: lastName,
                cancellationToken: cancellationToken
            );

        return Ok(person);
    }

    [HttpGet]
    [Route("api/application")]
    public async Task<IActionResult> GetPersonView(
        [FromQuery] int take,
        [FromQuery] int skip,
        CancellationToken cancellationToken)
    {
        var persons = await _personViewService
            .GetPersonsView(
                take: take,
                skip: skip,
                cancellationToken: cancellationToken
            );

        return Ok(persons);
    }

    [HttpGet]
    [Route("api/application/friend")]
    public async Task<IActionResult> GetFriendPersonView(
        [FromQuery] int take,
        [FromQuery] int skip,
        CancellationToken cancellationToken)
    {
        var persons = await _personViewService
            .GetFriendPersonsView(
                take: take,
                skip: skip,
                cancellationToken: cancellationToken
            );

        return Ok(persons);
    }
}
