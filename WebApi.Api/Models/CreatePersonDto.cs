using AutoMapper;
using WebApi.Application.Common.Mappings;
using WebApi.Application.People.Commands.CreatePerson;

namespace WebApi.Api.Models;

public class CreatePersonDto : IMapWith<CreatePersonCommand>
{
    public string FIO { get; set; }
    public DateTime DateOfBirth { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreatePersonDto, CreatePersonCommand>()
            .ForMember(personCommand => personCommand.FIO,
                opt => opt.MapFrom(personDto => personDto.FIO))
            .ForMember(personCommand => personCommand.DateOfBirth,
                opt => opt.MapFrom(personDto => personDto.DateOfBirth));
    }
}