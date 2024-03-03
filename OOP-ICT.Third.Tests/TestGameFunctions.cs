using OOP_ICT.Exceptions;
using OOP_ICT.Second.Exceptions;
using OOP_ICT.Second.Models;
using OOP_ICT.Third.Models;
using Xunit;
using Xunit.Abstractions;

namespace OOP_ICT.Third.Tests;


public class TestBankFunctions
{
    private readonly ITestOutputHelper _testOutputHelper;

    public TestBankFunctions(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    
    [Fact]
    public void Equal_AddPlayer_IsAdded()
    {
        uint playerMoney = 500;
        uint exchangeRate = 20;
        uint chipsAmount = 20;
        var player = new Player(1, playerMoney);
        var casino = new BlackjackCasino(exchangeRate);
        var game = new BlackjackGame(casino);
        uint bet = 10;
        player.CreateCasinoAccount(casino);
        player.BuyChips(casino,chipsAmount);
        game.AddPlayer(player, bet);
        Assert.Equal(player, game.GetPlayers()[0]);
        
    }    
    
    [Fact]
    public void Throws_AddPlayer_NotEnough()
    {
        uint playerMoney = 500;
        uint exchangeRate = 20;
        uint chipsAmount = 20;
        var player = new Player(1, playerMoney);
        var casino = new BlackjackCasino(exchangeRate);
        var game = new BlackjackGame(casino);
        uint bet = 40;
        player.CreateCasinoAccount(casino);
        player.BuyChips(casino,chipsAmount);
        var ex = Assert.Throws<NotEnoughOnBalanceException>(() =>  game.AddPlayer(player, bet));
        Assert.Equal("There is not enough chips on casino account :(", ex.Message);
    }    
    
    [Fact]
    public void Equal_StartGame_CardsAre_Ok()
    {
        uint playerMoney = 500;
        uint exchangeRate = 20;
        uint chipsAmount = 20;
        var casino = new BlackjackCasino(exchangeRate);
        var blackjackGame = new BlackjackGame(casino);
        var player = new Player(1,playerMoney);
        player.CreateCasinoAccount(casino);
        player.BuyChips(casino, chipsAmount);
        uint bet = 10;
        blackjackGame.AddPlayer(player, bet);

        blackjackGame.StartGame();
        
        Assert.Single(blackjackGame.GetPlayers());
        Assert.Equal(2, blackjackGame.GetPlayers()[0].GetHand().Count);
    }
    
    
    [Fact]
    public void Throws_DetermineWinner_GameHasntStarted()
    {
        uint playerMoney = 500;
        uint exchangeRate = 20;
        uint chipsAmount = 20;
        var casino = new BlackjackCasino(exchangeRate);
        var blackjackGame = new BlackjackGame(casino);
        var player = new Player(1,playerMoney);
        player.CreateCasinoAccount(casino);
        player.BuyChips(casino, chipsAmount);
        uint bet = 10;
        blackjackGame.AddPlayer(player, bet);
        
        var ex = Assert.Throws<WrongGameException>(() =>  blackjackGame.DetermineWinner());
        Assert.Equal("It isn't blackjack game", ex.Message);
    }
    
    [Fact]
    public void Null_DetermineWinner_DealerWins()
    {
        uint playerMoney = 500;
        uint exchangeRate = 20;
        uint chipsAmount = 20;
        var casino = new BlackjackCasino(exchangeRate);
        var game = new BlackjackGame(casino);
        var player = new Player(1,playerMoney);
        player.CreateCasinoAccount(casino);
        player.BuyChips(casino, chipsAmount);
        uint bet = 10;
        game.AddPlayer(player, bet);
        game.StartGame();
        while (!game.CheckEndGame())
        {
            game.DealerGetsCard();
        }
        Assert.Null(game.DetermineWinner());
    }
    
    [Fact]
    public void Equal_DetermineWinner_PlayerWins()
    {
        uint playerMoney = 500;
        uint exchangeRate = 20;
        uint chipsAmount = 20;
        var casino = new BlackjackCasino(exchangeRate);
        var game = new BlackjackGame(casino);
        var player = new Player(1,playerMoney);
        player.CreateCasinoAccount(casino);
        player.BuyChips(casino, chipsAmount);
        uint bet = 10;
        game.AddPlayer(player, bet);
        game.StartGame();
        game.PlayerGetsCard(player.GetId());
        while (!game.CheckEndGame())
        {
            game.DealerGetsCard();
        }
        Assert.Equal(player.GetId(),game.DetermineWinner()[0].GetId());
    }
    
    [Fact]
    public void Equal_PayWinners()
    {
        uint playerMoney = 500;
        uint exchangeRate = 20;
        uint chipsAmount = 20;
        var casino = new BlackjackCasino(exchangeRate);
        var game = new BlackjackGame(casino);
        var player = new Player(1,playerMoney);
        player.CreateCasinoAccount(casino);
        player.BuyChips(casino, chipsAmount);
        uint bet = 10;
        game.AddPlayer(player, bet);
        game.StartGame();
        game.PlayerGetsCard(player.GetId());
        while (!game.CheckEndGame())
        {
            game.DealerGetsCard();
        }
        game.PayWinners();
        Assert.Equal((uint)30,casino.GetCasinoAccount(player.GetId()).GetBalance());
    }
    
    
    
}