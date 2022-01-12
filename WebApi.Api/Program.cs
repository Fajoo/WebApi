using Serilog;
using Serilog.Events;
using WebApi.Persistence;

namespace WebApi.Api;

    public class Program
    {
        public static void Main(string[] args)
        {
            var logging = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .WriteTo.File("WebApiWebAppLog-.txt", rollingInterval:
                    RollingInterval.Day)
                .CreateLogger();

        var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<WebApiDbContext>();
                    var initializer = new DbInitializer(serviceProvider.GetRequiredService<ILogger<DbInitializer>>());
                    initializer.Initialize(context);
                }
                catch (Exception exception)
                {
                    Log.Fatal(exception, "An error occurred while app initialization");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog((context, configuration) => configuration
                        .Enrich.FromLogContext()
                        .MinimumLevel.Information()
                        .WriteTo.Console(),
                    preserveStaticLogger: true)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
