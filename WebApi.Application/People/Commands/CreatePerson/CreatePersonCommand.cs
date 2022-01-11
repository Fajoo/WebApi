using MediatR;

namespace WebApi.Application.People.Commands.CreatePerson;

public class CreatePersonCommand : IRequest<Guid>
{
    public string FIO { get; set; }
    public DateTime DateOfBirth { get; set; }
}