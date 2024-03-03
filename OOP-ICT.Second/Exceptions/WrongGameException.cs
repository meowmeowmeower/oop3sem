namespace OOP_ICT.Third.Exceptions;

public class WrongGameException: Exception
{
    public WrongGameException()
    {
    }

    public WrongGameException(string message) : base(message)
    {
    }
}