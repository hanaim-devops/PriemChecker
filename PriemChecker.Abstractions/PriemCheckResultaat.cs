using System.Numerics;

namespace PriemChecker.Abstractions;

public record PriemCheckResultaat(
    BigInteger PriemKandidaatWaarde,
    bool IsPriemgetal,
    double? AantalLoops,
    double? AantalSecondenOmTeBerekenen
    );