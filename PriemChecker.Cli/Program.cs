using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using PriemChecker.Abstractions;
using PriemChecker.Domain;
using PriemChecker.Persistence;

namespace PriemChecker.Cli
{
    class Program
    {
        // TODO: Command line parameters zoals --memoisation false parsen
        // Dit kan met behulp van System.Commandline package; zie: https://learn.microsoft.com/en-us/dotnet/standard/commandline/
        public static void Main(string[] args)
        {
            int priemKandidaat = 0;
            if (args.Length >= 2)
            {
                throw new ArgumentException("Je moet precies 1 argument geven, niet " + args.Length+ " argumenten");
            }
            if (args.Length==0)
            {
                priemKandidaat = new Random(0).Next();
                Console.WriteLine("Geen getal meegegeven, we gebruiken random getal '" + priemKandidaat + "'.");
            }
            else
            {
                if (!Int32.TryParse(args[0], out priemKandidaat))
                {
                    throw new ArgumentException("Input " + args[0] + " is geen geldig integer getal.");
                    // var grotePriemKandidaat = System.Numerics.BigInteger.Parse(args[0]);
                    // var isGrotePriem = primeTester.IsPriemgetal(grotePriemKandidaat);
                }
            }
            
            // Bouw de configuratie door het appsettings.json bestand te laden
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

                // Register the base implementation of IPriemChecker
                .AddScoped<NuGetPriemChecker>()

                // Register MemoizingPriemChecker as a decorator, depending on the base implementation
                .AddScoped<IPriemChecker>(sp =>
                {
                    var baseChecker = sp.GetRequiredService<NuGetPriemChecker>();  // Basisimplementatie
                    var context = sp.GetRequiredService<PriemCheckContext>();      // DB context
                    IPriemChecker priemChecker = useMemoisation ? 
                        new MemoizingPriemChecker(context, baseChecker) 
                        : new NuGetPriemChecker();
                    return priemChecker;
                })
                .BuildServiceProvider();
            
            // Resolve services
            using var scope = serviceProvider.CreateScope();
            var priemChecker = scope.ServiceProvider.GetRequiredService<IPriemChecker>();

            // Voorbeeld: gebruik de service
            var isPriem = priemChecker.IsPriemgetal(priemKandidaat);

            // int aantalLoops = 0;
            // var isPriem = primeTester.IsPriemgetal(priemKandidaat, aantalLoops);
            System.Console.WriteLine("Is getal " + priemKandidaat + " een priemgetal? " + (isPriem.IsPriemgetal ? "JA" : "NEE"));
            Console.WriteLine("Aantal loops: " + isPriem.AantalLoops + "aantal millisecs: " + isPriem.AantalSecondenOmTeBerekenen);
            
        }
    }
}