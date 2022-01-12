using Microsoft.EntityFrameworkCore;
using WebApi.Domain;

namespace WebApi.Application.Interfaces;

/// <summary>
/// Interface describing the database context
/// </summary>
public interface IWebApiDbContext
{
    DbSet<Person> People { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}