namespace WebApi.Persistence;

public sealed class DbInitializer
{
    public static void Initialize(WebApiDbContext context)
    {
        context.Database.EnsureCreated();
    }
}