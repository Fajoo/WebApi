using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Api.Controllers.Base;
using WebApi.Api.Models;
using WebApi.Application.People.Commands.CreatePerson;
using WebApi.Application.People.Queries.GetPeopleNames;

namespace WebApi.Api.Controllers;

[Route("api/[controller]")]
public class PersonController : BaseController
{
    private readonly IMapper _mapper;

    public PersonController(IMapper mapper) => _mapper = mapper;

    [HttpGet]
    public async Task<ActionResult<PersonListVm>> GetAll()
    {
        var query = new GetPeopleNamesQuery();
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreatePersonDto createNoteDto)
    {
        var command = _mapper.Map<CreatePersonCommand>(createNoteDto);
        var personId = await Mediator.Send(command);
        return Ok(personId);
    }
}