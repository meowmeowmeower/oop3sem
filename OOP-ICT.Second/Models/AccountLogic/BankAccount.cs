using OOP_ICT.Second.Exceptions;

namespace OOP_ICT.Second.Models.AccountLogic;

public class BankAccount: IAccount
{
    public uint Balance { get; private set; }
    public uint IdClient { get; private set; }

    public BankAccount(uint id)
    {
        IdClient = id;
        Balance = 0;
    }

    public void IncreaseBalance(uint amount)
    {
        Balance += amount;
    }

    public void DecreaseBalance(uint amount)
    {
        if (amount < Balance)
            Balance -= amount;
        else throw new NotEnoughOnBalanceException("There is not enough money on bank account :(");
    }
    
}