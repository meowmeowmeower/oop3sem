namespace OOP_ICT.Models;

public class CardDeck
{
    private List<Card> _cards;
    
    public CardDeck()
    {
        _cards = (
            from Suit suit in Enum.GetValues(typeof(Suit))
            from Rank rank in Enum.GetValues(typeof(Rank))
            select new Card(suit, rank)
        ).ToList();
    }

    public void SetCards(List<Card> cards)
    {
        _cards = cards;
    }

    public List<Card> GetCards()
    {
        return _cards;
    }

    public Card GetOneCard()
    {
        var card = _cards[_cards.Count-1];
        _cards.RemoveAt(_cards.Count-1);
        return card;
    }
    
    public void PrintString()
    {
        foreach (var c in _cards)
        {
            Console.WriteLine(c.ToString());
        }
    }
}
