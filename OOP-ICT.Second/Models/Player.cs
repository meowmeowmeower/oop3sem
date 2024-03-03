using OOP_ICT.Exceptions;
using OOP_ICT.Models;
using OOP_ICT.Second.Exceptions;

namespace OOP_ICT.Second.Models;

public class Player
{
    private readonly uint _id;
    private uint _cash;
    private readonly List<Card> _hand;

    public Player(uint id, uint cash)
    {
        _id = id;
        _cash = cash;
        _hand = new List<Card>();
    }

    public void CreateBankAccount(Bank bank)
    {
        bank.CreateNewAccount(_id);
    }

    public void CreateCasinoAccount(BlackjackCasino casino)
    {
        casino.CreateNewAccount(_id);
    }

    public void PutMoneyInBank(Bank bank, uint money)
    {
        if (!IsEnoughCash(money)) throw new NotEnoughOnBalanceException("There is not enough cash :(");
        bank.PutMoney(_id, money);
        _cash -= money;
    }
    
    public void BuyChips(BlackjackCasino casino, uint amount)
    {
        if (!IsEnoughCash(amount*casino.GetExchangeRate())) throw new NotEnoughOnBalanceException("There is not enough cash :(");
        casino.BuyChips(_id, amount);
        _cash -= amount * casino.GetExchangeRate();
    }

    public void GetMoneyFromBank(Bank bank, uint money)
    {
        if (!bank.IsEnoughMoney(_id,money)) throw new NotEnoughOnBalanceException("There is not enough money in bank :(");
        bank.GetMoney(_id,money);
        _cash += money;
    }

    public void ExchangeChips(BlackjackCasino casino, uint amount)
    {
        if (!casino.IsEnoughChips(_id, amount)) throw new NotEnoughOnBalanceException("There is not enough chips on casino account :(");
        casino.ExchangeChips(_id,amount);
        _cash += amount * casino.GetExchangeRate();
    }

    private bool IsEnoughCash(uint money)
    {
        return _cash > money;
    }

    public uint GetCashAmount()
    {
        return _cash;
    }
    
    public void GetCard(Card card)
    {
        _hand.Add(card);
    }

    public uint GetId()
    {
        return _id;
    }

    public List<Card> GetHand()
    {
        return _hand;
    }
}