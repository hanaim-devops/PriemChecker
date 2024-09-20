using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriemChecker.Domain;

public record PriemCheckResultaat(int PriemKandidaatWaarde, bool IsPriemgetal);