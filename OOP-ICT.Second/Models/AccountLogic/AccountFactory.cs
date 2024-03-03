namespace OOP_ICT.Second.Models;

public abstract class AccountFactory
{
    public abstract IAccount CreateAccount(uint id);
}