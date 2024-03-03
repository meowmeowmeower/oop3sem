namespace OOP_ICT.Exceptions;


public class WrongGameException: Exception
{
    public WrongGameException()
    {
    }

    public WrongGameException(string message) : base(message)
    {
    }
}