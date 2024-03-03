using OOP_ICT.Second.Exceptions;
using OOP_ICT.Second.Models.AccountLogic;

namespace OOP_ICT.Second.Models;

public class Bank
{
    private readonly List<BankAccount> _accounts = new();
    private readonly BankAccountFactory _accountFactory = new();

    public void CreateNewAccount(uint idClient)
    {
        _accounts.Add(_accountFactory.CreateAccount(idClient));
    }

    public void PutMoney(uint idClient, uint money)
    {
        GetBankAccount(idClient).IncreaseBalance(money);
    }

    public void GetMoney(uint idClient, uint money)
    {
        GetBankAccount(idClient).DecreaseBalance(money);
    }

    public BankAccount GetBankAccount(uint idClient)
    {
        if (_accounts.FirstOrDefault(i => i.IdClient == idClient) is null)
            throw new NoSuchAccountException("There is no such client in bank");
        return _accounts.FirstOrDefault(i => i.IdClient == idClient)!;
    }
    
    public bool IsEnoughMoney(uint idClient, uint money)
    {
        return GetBankAccount(idClient).Balance > money;
    }
}