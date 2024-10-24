using System.Numerics;

namespace PriemChecker.Abstractions;

public record PriemCheckResultaat(
    string PriemKandidaatWaarde,  // Change BigInteger to string
    bool IsPriemgetal,
    double? AantalLoops,
    double? AantalMilliSecondenOmTeBerekenen,
    double? AantalTicksOmTeBerekenen
)
{
    // Constructor overload to accept BigInteger and convert to string
    public PriemCheckResultaat(BigInteger priemKandidaatWaarde, bool isPriemgetal, double? aantalLoops, double? aantalSecondenOmTeBerekenen, double? aantalTicksOmTeBerekenen)
        : this(priemKandidaatWaarde.ToString(), isPriemgetal, aantalLoops, aantalSecondenOmTeBerekenen, aantalTicksOmTeBerekenen)
    {
    }
}