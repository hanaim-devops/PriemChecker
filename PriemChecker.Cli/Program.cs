using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using PriemChecker.Abstractions;
using PriemChecker.Domain;
using PriemChecker.Persistence;

namespace PriemChecker.Cli
{
    static class Program
    {
        // TODO: Command line parameters zoals --memoisation false parsen.
        // Dit kan met behulp van System.Commandline package; zie: https://learn.microsoft.com/en-us/dotnet/standard/commandline/
        public static void Main(string[] args)
        {
            Console.WriteLine("Args length: " + args.Length.ToString());
            if (args.Length >= 2)
            {
                throw new ArgumentException("Je moet precies 1 argument geven, niet " + args.Length+ " argumenten");
            }

            if (args.Length==0)
            {
                int priemKandidaat = new Random(0).Next();
                Console.WriteLine("Geen getal meegegeven, we gebruiken random integer getal '" + priemKandidaat + "'.");
            }
            
            // Bouw de configuratie door het 'appsettings.json' bestand te laden
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()  // Voor eventueel omgevingsvariabelen
                .Build();

            // Lees waarden uit de configuratie
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var useMemoisation = bool.Parse(configuration["AppSettings:UseMemoisation"] ?? "False");

            // Console.WriteLine($"Connection String: {connectionString}");
            Console.WriteLine($"UseMemoisation: {useMemoisation}");

            // Composition Root - Configureer alle afhankelijkheden via DI.
            var serviceProvider = new ServiceCollection()
                .AddDbContext<PriemCheckContext>(options =>
                    options.UseSqlServer(connectionString))

                // Register the SimpelPriemChecker
                .AddScoped<SimpelPriemChecker>() 

                // Register the PriemCheckerMetSnelheidsMeting, which depends on SimpelPriemChecker
                .AddScoped(sp => 
                    new PriemCheckerMetSnelheidsMeting(sp.GetRequiredService<SimpelPriemChecker>()))

                // Register MemoizingPriemChecker or PriemCheckerMetSnelheidsMeting depending on useMemoisation
                .AddScoped<IPriemChecker>(sp =>
                {
                    var baseChecker = sp.GetRequiredService<PriemCheckerMetSnelheidsMeting>();  // Base implementation
                    var context = sp.GetRequiredService<PriemCheckContext>();                   // DB context

                    if (useMemoisation)
                    {
                        // Return MemoizingPriemChecker if memoisation is enabled
                        return new MemoizingPriemChecker(context, baseChecker);
                    }
                    else
                    {
                        // Return just the PriemCheckerMetSnelheidsMeting if memoisation is disabled
                        return baseChecker;
                    }
                })
                .BuildServiceProvider();
            
            // Resolve services
            using var scope = serviceProvider.CreateScope();
            var priemChecker = scope.ServiceProvider.GetRequiredService<IPriemChecker>();

            PriemCheckResultaat resultaat;
            // Voorbeeld: gebruik de service.
            if (!Int32.TryParse(args[0], out var parsedPriemKandidaat))
            {
                var grotePriemKandidaat = System.Numerics.BigInteger.Parse(args[0]);
                resultaat = priemChecker.IsPriemgetal(grotePriemKandidaat);
            }
            else
            {
                resultaat = priemChecker.IsPriemgetal(parsedPriemKandidaat);
            }
            
            Console.WriteLine($"Is getal {parsedPriemKandidaat} een priemgetal? {(resultaat.IsPriemgetal ? "JA" : "NEE")}");
            Console.WriteLine($"Aantal loops: {resultaat.AantalLoops ?? 0}, aantal milliseconden: {resultaat.AantalMilliSecondenOmTeBerekenen ?? 0}");

        }
    }
}