using PriemChecker.Abstractions;

namespace PriemChecker.Domain;

public class PrimeCheckOperation
{
    public int Id { get; set; }  // Entity Id
    public PriemCheckResultaat? Resultaat { get; set; }  // Value Object
}
