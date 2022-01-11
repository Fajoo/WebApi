using FluentValidation;

namespace WebApi.Application.People.Commands.CreatePerson;

public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
{
    public CreatePersonCommandValidator()
    {
        RuleFor(createPersonCommand =>
            createPersonCommand.FIO).NotEmpty().MaximumLength(250);
        RuleFor(createPersonCommand =>
            createPersonCommand.DateOfBirth).NotEmpty();
    }
}