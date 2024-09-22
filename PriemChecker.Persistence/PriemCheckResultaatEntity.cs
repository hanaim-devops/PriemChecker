using System.Numerics;
using Microsoft.EntityFrameworkCore.Migrations.Internal;

namespace PriemChecker.Persistence;

public class PriemCheckResultaatEntity
{
    public double Id { get; set; }  // Identity column for persistence
    public BigInteger PriemKandidaatWaarde { get; set; }
    public bool IsPriemgetal { get; set; }
    
    public double? AantalLoops { get; set; }
    
    public double? MilliSecondenOmTeBerekenen { get; set; }

    public DateTime UitgerekendOp { get; set; }

    // Parameterless constructor for EF Core
    public PriemCheckResultaatEntity() {}
    
    // Optional constructor for manual instantiation
    public PriemCheckResultaatEntity(BigInteger number, bool result, DateTime uitgerekendOp, double? aantalLoops, double? milliSecondenOmTeBerekenen)
    {
        PriemKandidaatWaarde = number;
        IsPriemgetal = result;
        AantalLoops = aantalLoops;
        MilliSecondenOmTeBerekenen = milliSecondenOmTeBerekenen;
        UitgerekendOp = uitgerekendOp;
    }
}
