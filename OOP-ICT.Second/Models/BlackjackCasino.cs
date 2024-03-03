using OOP_ICT.Second.Exceptions;
using OOP_ICT.Second.Models.AccountLogic;

namespace OOP_ICT.Second.Models;

public class BlackjackCasino
{
    private readonly uint _exchangeRate;
    private readonly List<CasinoAccount> _accounts = new();
    private readonly CasinoAccountFactory _accountFactory = new();

    public BlackjackCasino(uint exchangeRate)
    {
        _exchangeRate = exchangeRate;
    }
    public void CreateNewAccount(uint idClient)
    {
        _accounts.Add(_accountFactory.CreateAccount(idClient));
    }

    public void BuyChips(uint idClient, uint amount)
    {
        GetCasinoAccount(idClient).IncreaseBalance(amount);
    }

    public void ExchangeChips(uint idClient, uint amount)
    {
        GetCasinoAccount(idClient).DecreaseBalance(amount);
    }

    public CasinoAccount GetCasinoAccount(uint idClient)
    {
        if (_accounts.FirstOrDefault(i => i.IdPlayer == idClient) is null)
            throw new NoSuchAccountException("There is no such client in casino");
        return _accounts.FirstOrDefault(i => i.IdPlayer == idClient)!;
    }

    public bool IsEnoughChips(uint idClient, uint amount)
    {
        return GetCasinoAccount(idClient).ChipsBalance > amount;
    }

    public uint GetExchangeRate()
    {
        return _exchangeRate;
    }
}