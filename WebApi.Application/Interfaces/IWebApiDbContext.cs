using Microsoft.EntityFrameworkCore;
using WebApi.Domain;

namespace WebApi.Application.Interfaces;

public interface IWebApiDbContext
{
    DbSet<Person> People { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}