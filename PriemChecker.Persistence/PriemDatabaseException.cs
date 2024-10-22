namespace PriemChecker.Persistence;

public class PriemDatabaseException : Exception
{
    public PriemDatabaseException() : base("Database lijkt offline.")
    {
    }
}