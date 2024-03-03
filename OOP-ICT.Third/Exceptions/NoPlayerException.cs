namespace OOP_ICT.Exceptions;


public class NoPlayerException: Exception
{
    public NoPlayerException()
    {
    }

    public NoPlayerException(string message) : base(message)
    {
    }
}