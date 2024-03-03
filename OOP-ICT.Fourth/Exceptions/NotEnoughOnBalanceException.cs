namespace OOP_ICT.Fourth.Exceptions;

public class NotEnoughOnBalanceException: Exception
{
    public NotEnoughOnBalanceException()
    {
    }

    public NotEnoughOnBalanceException(string message) : base(message)
    {
    }
}