using System.Runtime.Serialization;

namespace OOP_ICT.Second.Exceptions;

public class NoSuchAccountException : Exception
{
    public NoSuchAccountException()
    {
    }

    public NoSuchAccountException(string message) : base(message)
    {
    }
}