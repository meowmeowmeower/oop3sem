using OOP_ICT.Second.Exceptions;
using OOP_ICT.Second.Models;
using Xunit;
using Xunit.Abstractions;

namespace OOP_ICT.Second.Tests;


public class TestBankFunctions
{
    private readonly ITestOutputHelper _testOutputHelper;

    public TestBankFunctions(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    
    [Fact]
    public void Throws_GetBankAccount()
    {
        const uint id = 1;
        var bank = new Bank();
        var player = new Player(id, 1000);
        player.CreateBankAccount(bank);
        Assert.Equal(id, bank.GetBankAccount(id).IdClient);
    }    
    
    [Fact]
    public void Throws_GetBankAccount_DoesntExist()
    {
        const uint id = 1;
        const uint wrongId = 2;
        var bank = new Bank();
        var player = new Player(id, 1000);
        player.CreateBankAccount(bank);
        var ex = Assert.Throws<NoSuchAccountException>(() => bank.GetBankAccount(wrongId));
        Assert.Equal("There is no such client in bank", ex.Message);
    }    

    
    [Fact]
    public void IsNotNull_CreateAccount()
    {
        const uint id = 1;
        var bank = new Bank();
        var player = new Player(id, 1000);
        player.CreateBankAccount(bank);
        Assert.NotNull(bank.GetBankAccount(id));
    }    
    
    [Fact]
    public void AreEquals_PutMoneyInBank()
    {
        const uint id = 1;
        const uint cash = 1000;
        var player = new Player(id, cash);
        var bank = new Bank();
        player.CreateBankAccount(bank);
        const uint moneyForBank = 100;
        player.PutMoneyInBank(bank, moneyForBank);
        var bankBalance = bank.GetBankAccount(id).Balance;
        var playerBalance = player.GetCashAmount();
        Assert.Equal(moneyForBank, bankBalance);
        Assert.Equal(cash - moneyForBank, playerBalance);
    }    
    
    [Fact]
    public void AreEquals_PutMoneyInBank_IsNotEnoughCash()
    {
        const uint id = 1;
        const uint cash = 100;
        var player = new Player(id, cash);
        var bank = new Bank();
        player.CreateBankAccount(bank);
        const uint moneyForBank = 200;
        var ex = Assert.Throws<NotEnoughOnBalanceException>(() => player.PutMoneyInBank(bank, moneyForBank));
        Assert.Equal("There is not enough cash :(", ex.Message);
    }    

    
    
    [Fact]
    public void AreEquals_GetMoneyFromBank()
    {
        const uint id = 1;
        const uint cash = 1000;
        var player = new Player(id, cash);
        var bank = new Bank();
        player.CreateBankAccount(bank);
        const uint moneyForBank = 100;
        const uint moneyFromBank = 50;
        player.PutMoneyInBank(bank, moneyForBank);
        player.GetMoneyFromBank(bank, moneyFromBank);
        var bankBalance = bank.GetBankAccount(id).Balance;
        var playerBalance = player.GetCashAmount();
        Assert.Equal(moneyForBank-moneyFromBank, bankBalance);
        Assert.Equal(cash - moneyForBank+moneyFromBank, playerBalance);
    }    
    
    
    [Fact]
    public void Throws_GetMoneyFromBank_IsNotEnough()
    {
        const uint id = 1;
        const uint cash = 1000;
        var player = new Player(id, cash);
        var bank = new Bank();
        player.CreateBankAccount(bank);
        const uint moneyForBank = 50;
        const uint moneyFromBank = 100;
        player.PutMoneyInBank(bank, moneyForBank);
        var ex = Assert.Throws<NotEnoughOnBalanceException>(() => player.GetMoneyFromBank(bank, moneyFromBank));
        Assert.Equal("There is not enough money in bank :(", ex.Message);
    }    
    
}