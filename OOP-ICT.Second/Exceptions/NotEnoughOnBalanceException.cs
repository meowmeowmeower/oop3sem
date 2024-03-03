namespace OOP_ICT.Second.Exceptions;

public class NotEnoughOnBalanceException: Exception
{
    public NotEnoughOnBalanceException()
    {
    }

    public NotEnoughOnBalanceException(string message) : base(message)
    {
    }
}