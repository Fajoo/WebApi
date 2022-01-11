using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Api.Controllers.Base;
using WebApi.Api.Models;
using WebApi.Application.People.Commands.CreatePerson;
using WebApi.Application.People.Queries.GetPeopleNames;

namespace WebApi.Api.Controllers;

[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Produces("application/json")]
[Route("api/{version:apiVersion}/[controller]")]
public class PersonController : BaseController
{
    private readonly IMapper _mapper;

    public PersonController(IMapper mapper) => _mapper = mapper;

    /// <summary>
    /// Gets the list of people
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /note
    /// </remarks>
    /// <returns>Returns PersonListVm</returns>
    /// <response code="200">Success</response>
    /// <response code="401">If the user is unauthorized</response>
    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<PersonListVm>> GetAll()
    {
        var query = new GetPeopleNamesQuery();
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Creates the person
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// POST /person
    /// {
    ///     FIO: "Pupkin Pup Pupovich",
    ///     DateOfBirth: "01.01.2000"
    /// }
    /// </remarks>
    /// <param name="createPersonDto">createPersonDto object</param>
    /// <returns>Returns id (guid)</returns>
    /// <response code="201">Success</response>
    /// <response code="401">If the user is unauthorized</response>
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> Create([FromBody] CreatePersonDto createPersonDto)
    {
        var command = _mapper.Map<CreatePersonCommand>(createPersonDto);
        var personId = await Mediator.Send(command);
        return Ok(personId);
    }
}