namespace PriemChecker.Persistence;

public class PriemDatabaseException : Exception
{
    public PriemDatabaseException(string databaseLijktOffline) : base("Database lijkt offline.")
    {
    }
}