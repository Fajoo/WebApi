using Microsoft.EntityFrameworkCore;
using WebApi.Application.Interfaces;
using WebApi.Domain;
using WebApi.Persistence.EntityTypeConfigurations;

namespace WebApi.Persistence;

/// <summary>
/// Database context
/// </summary>
public class WebApiDbContext : DbContext, IWebApiDbContext
{
    /// <summary>
    /// People table with data
    /// </summary>
    public DbSet<Person> People { get; set; }

    public WebApiDbContext(DbContextOptions<WebApiDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new PersonConfiguration());
        base.OnModelCreating(builder);
    }
}