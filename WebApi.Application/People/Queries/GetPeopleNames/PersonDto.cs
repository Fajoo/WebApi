using AutoMapper;
using WebApi.Application.Common.Mappings;
using WebApi.Domain;

namespace WebApi.Application.People.Queries.GetPeopleNames;

public class PersonDto : IMapWith<Person>
{
    public Guid Id { get; set; }
    public string FIO { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Person, PersonDto>()
            .ForMember(personDto => personDto.Id,
                opt => opt.MapFrom(person => person.Id))
            .ForMember(personDto => personDto.FIO,
                opt => opt.MapFrom(person => person.FIO));
    }
}