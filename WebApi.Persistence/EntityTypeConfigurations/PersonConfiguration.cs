using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Domain;

namespace WebApi.Persistence.EntityTypeConfigurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(person => person.Id);
        builder.HasIndex(person => person.Id).IsUnique();
        builder.Property(person => person.FIO).HasMaxLength(250);
    }
}