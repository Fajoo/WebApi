using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WebApi.Persistence;

public sealed class DbInitializer
{
    private readonly ILogger<DbInitializer> _logger;

    public DbInitializer(ILogger<DbInitializer> _logger)
    {
        this._logger = _logger;
    }

    public void Initialize(WebApiDbContext context)
    {
        var db = context.Database;

        var pendingMigrations = db.GetPendingMigrations().ToArray();
        var appliedMigrations = db.GetAppliedMigrations().ToArray();

        if (appliedMigrations.Length == 0 && pendingMigrations.Length == 0)
        {
            if (db.EnsureCreated())
                _logger.LogInformation("DB successfully created");
        }
        else if (pendingMigrations.Length > 0)
        {
            _logger.LogInformation(
                "DB exists. Migrations applied {0}. Required to apply {1} migrations",
                appliedMigrations.Length, pendingMigrations.Length);
            if (appliedMigrations.Length > 0)
                _logger.LogInformation("Applied migrations: {0}", string.Join(",", appliedMigrations));

            db.Migrate();
            _logger.LogInformation("Applied migrations: {0}", string.Join(",", pendingMigrations));
        }

        _logger.LogInformation("Initialization DB done");
    }

    public bool DeInitialize(WebApiDbContext context)
    {
        var db = context.Database;

        if (!db.EnsureDeleted()) return false;
        _logger.LogInformation("БД удалена");
        return true;
    }
}