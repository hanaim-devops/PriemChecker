using System.Numerics;

namespace PriemChecker.Abstractions;

public interface IPriemChecker
{
    PriemCheckResultaat IsPriemgetal(BigInteger kandidaat);
}