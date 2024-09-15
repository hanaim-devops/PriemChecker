// See https://aka.ms/new-console-template for more information
// Zie de README.md voor meer informatie.
namespace ConsolePrimeTester
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
                }
            }

            var primeTester = new PriemgetalChecker();
            var isPriem = primeTester.testPrime(priemKandidaat);
            Console.WriteLine("Is getal " + priemKandidaat + " een priemgetal? " + (isPriem ? "JA" : "NEE"));
        }
    }
}