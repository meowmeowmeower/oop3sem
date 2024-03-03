namespace OOP_ICT.Models;

public class Card
{
    private Suit Suit { get; }
    private Rank Rank { get; }
    private int _value;
    

    public Card(Suit suit, Rank rank)
    {
        Suit = suit;
        Rank = rank;
        _value = (int)Rank;
    }
    
    
    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }
    

    public override bool Equals(object other)
        {
            return Equals(other as Card);
        }
    public virtual bool Equals(Card other)
    {
        return Suit == other.Suit && Rank == other.Rank;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine((int)Suit, (int)Rank);
    }

    public Rank GetRank()
    {
        return Rank;
    }
    
    public Suit GetSuit()
    {
        return Suit;
    }

    public void SetValue(int value)
    {
        _value = value;
    }

    public int GetValue()
    {
        return _value;
    }
    
}