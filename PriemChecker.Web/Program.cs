using PriemChecker.Abstractions;
using PriemChecker.Domain;
using PriemChecker.Persistence;

namespace PriemChecker.Web;

using Microsoft.EntityFrameworkCore;

internal class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        Console.WriteLine("Using connection string: '" + connectionString +"'.");

        // TODO: De (DB) connection string gebruikt TrustServerCertificate=True, maar dat kan op productie niet.
        // TODO: Dan moet er een geldig NON self-signed certificate zijn, of we iets regelen dat self signed wel werkt ;)
        builder.Services.AddDbContext<PriemCheckContext>(options =>
            options.UseSqlServer(connectionString));

        // Register PriemCheckRepository
        builder.Services.AddScoped<PriemCheckRepository>();

        // Register the base implementation
        builder.Services.AddScoped<NuGetPriemChecker>();

        // Register the decorator, but make sure it depends on the specific implementation
        builder.Services.AddScoped<IPriemChecker>(sp =>
        {
            var baseChecker = sp.GetRequiredService<NuGetPriemChecker>();
            var context = sp.GetRequiredService<PriemCheckContext>();
            
            // TODO: Add feature toggle voor CDMM 'gemiddeld' niveau.
            var useMemoization = true;
            return useMemoization ? new MemoizingPriemChecker(context, baseChecker) : new PriemCheckerMetSnelheidsMeting(new SimpelPriemChecker());
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapGet("/helloWorld", HelloWorldHandler.SayHello)
            .WithName("Hello World")
            .WithOpenApi();

        app.MapPost("/isPriem", PriemCheckerHandler.IsPriem)
            .WithName("IsPriem")
            .WithOpenApi();

        // Uncomment if you want to add the PriemCheckRepository endpoint
        app.MapGet("/priemGetallem", PriemRepositoryHandler.HaalAllePriemGetallenOpAsync)
            .WithName("PriemGetallen")
            .WithOpenApi();

        app.Run();

    }
}