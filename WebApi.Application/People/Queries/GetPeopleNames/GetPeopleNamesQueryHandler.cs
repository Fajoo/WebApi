using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApi.Application.Interfaces;

namespace WebApi.Application.People.Queries.GetPeopleNames;

public class GetPeopleNamesQueryHandler : IRequestHandler<GetPeopleNamesQuery, PersonListVm>
{
    private readonly IWebApiDbContext _context;
    private readonly IMapper _mapper;

    public GetPeopleNamesQueryHandler(IWebApiDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PersonListVm> Handle(GetPeopleNamesQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.People
            .ProjectTo<PersonDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new PersonListVm {People = query};
    }
}