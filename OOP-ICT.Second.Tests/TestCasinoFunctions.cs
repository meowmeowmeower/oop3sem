using OOP_ICT.Second.Exceptions;
using OOP_ICT.Second.Models;
using Xunit;
using Xunit.Abstractions;

namespace OOP_ICT.Second.Tests;


public class TestCasinoFunctions
{
    private readonly ITestOutputHelper _testOutputHelper;

    public TestCasinoFunctions(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    
    [Fact]
    public void Throws_GetCasinoAccount()
    {
        const uint id = 1;
        const uint exchange = 50;
        var casino = new BlackjackCasino(exchange);
        var player = new Player(id, 1000);
        player.CreateCasinoAccount(casino);
        Assert.Equal(id, casino.GetCasinoAccount(id).IdPlayer);
    }    
    
    [Fact]
    public void Throws_GetCasinoAccount_DoesntExist()
    {
        const uint id = 1;
        const uint wrongId = 2;
        const uint exchange = 50;
        var casino = new BlackjackCasino(exchange);
        var player = new Player(id, 1000);
        player.CreateCasinoAccount(casino);
        var ex = Assert.Throws<NoSuchAccountException>(() => casino.GetCasinoAccount(wrongId));
        Assert.Equal("There is no such client in casino", ex.Message);
    }    

    
    [Fact]
    public void IsNotNull_CreateAccount()
    {
        const uint id = 1;
        const uint exchange = 50;
        var casino = new BlackjackCasino(exchange);
        var player = new Player(id, 1000);
        player.CreateCasinoAccount(casino);
        Assert.NotNull(casino.GetCasinoAccount(id));
    }    
    
    [Fact]
    public void AreEquals_BuyChips()
    {
        const uint id = 1;
        const uint exchange = 50;
        const uint cash = 1000;
        var player = new Player(id, cash);
        var casino = new BlackjackCasino(exchange);
        player.CreateCasinoAccount(casino);
        const uint chipsAmount = 2;
        player.BuyChips(casino,chipsAmount);
        var chipsBalance = casino.GetCasinoAccount(id).ChipsBalance;
        var playerBalance = player.GetCashAmount();
        Assert.Equal(chipsAmount, chipsBalance);
        Assert.Equal(cash - chipsAmount*exchange, playerBalance);
    }    
    
    [Fact]
    public void AreEquals_BuyChips_IsNotEnoughCash()
    {
        const uint id = 1;
        const uint exchange = 50;
        const uint cash = 1000;
        var player = new Player(id, cash);
        var casino = new BlackjackCasino(exchange);
        player.CreateCasinoAccount(casino);
        const uint chipsAmount = 22;
        var ex = Assert.Throws<NotEnoughOnBalanceException>(() => player.BuyChips(casino, chipsAmount));
        Assert.Equal("There is not enough cash :(", ex.Message);
    }    
    
    [Fact]
    public void AreEquals_ExchangeChips()
    {
        const uint id = 1;
        const uint exchange = 50;
        const uint cash = 1000;
        var player = new Player(id, cash);
        var casino = new BlackjackCasino(exchange);
        player.CreateCasinoAccount(casino);
        const uint chipsAmountToBuy = 15;
        const uint chipsAmountToExchange = 7;
        player.BuyChips(casino,chipsAmountToBuy);
        player.ExchangeChips(casino, chipsAmountToExchange);
        var chipsBalance = casino.GetCasinoAccount(id).ChipsBalance;
        var playerBalance = player.GetCashAmount();
        Assert.Equal(chipsAmountToBuy-chipsAmountToExchange, chipsBalance);
        Assert.Equal(cash-chipsBalance*exchange, playerBalance);
    }    
    
    
    [Fact]
    public void AreEquals_ExchangeChips_IsNotEnough()
    {
        const uint id = 1;
        const uint exchange = 50;
        const uint cash = 1000;
        var player = new Player(id, cash);
        var casino = new BlackjackCasino(exchange);
        player.CreateCasinoAccount(casino);
        const uint chipsAmountToBuy = 15;
        const uint chipsAmountToExchange = 20;
        player.BuyChips(casino,chipsAmountToBuy);
        var ex = Assert.Throws<NotEnoughOnBalanceException>(() => player.ExchangeChips(casino, chipsAmountToExchange));
        Assert.Equal("There is not enough chips on casino account :(", ex.Message);
    }    
}