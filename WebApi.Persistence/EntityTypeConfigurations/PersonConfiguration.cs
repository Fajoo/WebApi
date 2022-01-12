using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Domain;

namespace WebApi.Persistence.EntityTypeConfigurations;

/// <summary>
/// Class describing entity settings - person
/// </summary>
public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    /// <summary>
    /// Entity customization
    /// </summary>
    /// <param name="builder">Database builder</param>
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(person => person.Id);
        builder.HasIndex(person => person.Id).IsUnique();
        builder.Property(person => person.FIO).HasMaxLength(250);
    }
}