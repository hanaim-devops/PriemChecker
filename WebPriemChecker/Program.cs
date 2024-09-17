using PriemCheckerLibrary;

namespace WebPriemChecker;

using Microsoft.EntityFrameworkCore;
using PriemChecker.Abstractions;

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
        Console.WriteLine("Using connection string: '" + connectionString +"'."); // Tijdelijke log.

        // TODO: De (DB) connection string gebruikt TrustServerCertificate=True, maar dat kan op productie niet.
        // Dan moet er een geldig NON self-signed certificate zijn, of we iets regelen dat self signed wel werkt ;)
        builder.Services.AddDbContext<PriemCheckContext>(options =>
            options.UseSqlServer("connectionString"));

        // Register the base implementation
        builder.Services.AddScoped<NuGetPriemChecker>();

        // Register the decorator, but make sure it depends on the specific implementation
        builder.Services.AddScoped<IPriemChecker>(sp =>
        {
            var baseChecker = sp.GetRequiredService<NuGetPriemChecker>();
            var context = sp.GetRequiredService<PriemCheckContext>();
            return new MemoizingPriemChecker(context, baseChecker);
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapPost("/isPriem", (IPriemChecker priemgetalChecker, int getal) =>
            {
                return priemgetalChecker.IsPriemgetal(getal);
            })
            .WithName("IsPriem")
            .WithOpenApi();

        app.MapPost("helloWorld", () => "Hello World!")
            .WithName("Hello World")
            .WithOpenApi();
        
        app.Run();
    }
}