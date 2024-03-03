using OOP_ICT.Second.Exceptions;

namespace OOP_ICT.Second.Models.AccountLogic;

public class CasinoAccount: IAccount
{
    
    
    public uint ChipsBalance { get; private set; }
    public uint IdPlayer { get; private set; }

    public CasinoAccount(uint id)
    {
        IdPlayer = id;
        ChipsBalance = 0;
    }

    public void IncreaseBalance(uint amount)
    {
        ChipsBalance += amount;
    }

    public void DecreaseBalance(uint amount)
    {
        if (amount < ChipsBalance)
            ChipsBalance -= amount;
        else throw new NotEnoughOnBalanceException("There is not enough chips on casino account :(");
    }

    public uint GetBalance()
    {
        return ChipsBalance;
    }
    
}