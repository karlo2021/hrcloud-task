// PersonController.cs
//
// © 2021

using Microsoft.AspNetCore.Mvc;

using Business.DataTransferObjects.Person;
using Business.Services.Abstraction;

namespace WebApi.Controllers;

[ApiController]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;
    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpGet]
    [Route("api/test")]
    public string Test() => "Hello World!";

    [HttpGet]
    [Route("api/persons/{firstName}/{lastName}")]
    public async Task<IActionResult> GetPerson(
        [FromRoute] string firstName,
        [FromRoute] string lastName,
        CancellationToken cancellationToken)
    {
        var person = await _personService
            .GetPersonDetails(
                firstName: firstName,
                lastName: lastName,
                cancellationToken: cancellationToken
            );

        return Ok(person);
    }

    [HttpGet]
    [Route("api/persons")]
    public async Task<IActionResult> GetPerson(
        [FromQuery] int take,
        [FromQuery] int skip,
        CancellationToken cancellationToken)
    {
        var persons = await _personService
            .GetPersons(
                take: take,
                skip: skip,
                cancellationToken: cancellationToken
            );

        return Ok(persons);
    }

    [HttpPost]
    [Route("api/persons")]
    public async Task<IActionResult> CreatePerson(
        [FromBody] CreatePersonDto createPersonDto,
        CancellationToken cancellationToken)
    {
        await _personService.CreatePerson(
            createPersonDto: createPersonDto,
            cancellationToken: cancellationToken);

        return CreatedAtAction(nameof(CreatePerson), createPersonDto);
    }
}
