using PriemCheckerLibrary;

namespace ConsolePrimeChecker
{
    class Program
    {
        public static void Main(string[] args)
        {
            var primeTester = new NuGetPriemChecker();

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

            var isPriem = primeTester.IsPriemgetal(priemKandidaat);
            // int aantalLoops = 0;
            // var isPriem = primeTester.IsPriemgetal(priemKandidaat, aantalLoops);
            Console.WriteLine("Is getal " + priemKandidaat + " een priemgetal? " + (isPriem ? "JA" : "NEE"));
            // Console.WriteLine("Aantal loops: " + aantalLoops);
        }
    }
}