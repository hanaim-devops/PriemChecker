namespace PriemChecker.Web;

public class HelloWorldHandler
{
    public static IResult SayHello()
    {
        return Results.Ok("Hello World!");
    }
}