using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PriemChecker.Abstractions;
using PriemCheckerLibrary;

namespace ConsolePriemChecker
{
    class Program
    {
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

            // Composition Root - Configureer alle afhankelijkheden via DI.
            var serviceProvider = new ServiceCollection()
                .AddDbContext<PriemCheckContext>(options =>
                    options.UseSqlServer("Server=localhost,1433;Database=PriemCheckDb;User Id=sa;Password=Your_password123;TrustServerCertificate=True;"))

                // Register the base implementation of IPriemChecker
                .AddScoped<NuGetPriemChecker>()

                // Register MemoizingPriemChecker as a decorator, depending on the base implementation
                .AddScoped<IPriemChecker>(sp =>
                {
                    var baseChecker = sp.GetRequiredService<NuGetPriemChecker>();  // Basisimplementatie
                    var context = sp.GetRequiredService<PriemCheckContext>();      // DB context
                    return new MemoizingPriemChecker(context, baseChecker);        // Teruggeven van de decorator
                })
                .BuildServiceProvider();
            
            // Resolve services
            using var scope = serviceProvider.CreateScope();
            var priemChecker = scope.ServiceProvider.GetRequiredService<IPriemChecker>();

            // Voorbeeld: gebruik de service
            var isPriem = priemChecker.IsPriemgetal(priemKandidaat);
            // int aantalLoops = 0;
            // var isPriem = primeTester.IsPriemgetal(priemKandidaat, aantalLoops);
            Console.WriteLine("Is getal " + priemKandidaat + " een priemgetal? " + (isPriem ? "JA" : "NEE"));
            // Console.WriteLine("Aantal loops: " + aantalLoops);
        }
    }
}