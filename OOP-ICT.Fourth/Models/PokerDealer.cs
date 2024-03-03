using OOP_ICT.Exceptions;

namespace OOP_ICT.Models;

public class PokerDealer
{
    private readonly int _playerId;
    private readonly CardDeck _deck;

    public PokerDealer(CardDeck deck, int playerId)
    {
        _deck = deck;
        _playerId = playerId;
    }

    public CardDeck GetCurrDeck()
    {
        return _deck;
    }

    public CardDeck GetShuffledDeck()
    {
        Shuffle();
        return _deck;
    }
    public void Shuffle()
    {
        var half = _deck.GetCards().Count / 2;
        var tempArray = new List<Card>();
        for (int i = 0; i < _deck.GetCards().Count; ++i)
            tempArray.Add(null);
        for (var i = 0; i < half; i++)
        {
            tempArray[i * 2] = _deck.GetCards()[i + half];
            tempArray[i * 2 + 1] = _deck.GetCards()[i];
        }

        _deck.SetCards(tempArray);
    }

    public Card GiveCard()
    {
        return _deck.GetOneCard();
    }

    public int GetId()
    {
        return _playerId;
    }
    
}