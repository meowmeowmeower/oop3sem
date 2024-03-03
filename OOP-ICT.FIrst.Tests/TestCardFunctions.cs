using  OOP_ICT.Models;
using Xunit;

namespace OOP_ICT.FIrst.Tests;

public class TestCardFunctions
{
    [Fact]
    public void AreEquals_NumberOfCards()
    {
        var cd = new CardDeck();
        const int cardAmount = 52;
        Assert.Equal(cardAmount, cd.GetCards().Count);
    }    
    
    [Fact]
    public void AreEquals_NewCard()
    {
        const Suit suit = Suit.Hearts;
        const Rank rank = Rank.Ace;
        var newCard = new Card(suit, rank);
    
        Assert.Equal($"{rank} of {suit}", newCard.ToString());
    }

    
    [Fact]
    public void AreNotEquals_Shuffled()
    {
        var cd = new CardDeck();
        var dealer = new Dealer(cd);
        Assert.NotEqual(new CardDeck(), dealer.GetShuffledDeck());
    }    
    
}