// See https://aka.ms/new-console-template for more information


using OOP_ICT.Models;

var cards = new List<Card>();
cards.Add(new Card(Suit.Clubs,Rank.Eight));
cards.Add(new Card(Suit.Diamonds,Rank.Five));
cards.Add(new Card(Suit.Hearts,Rank.King));
cards.Add(new Card(Suit.Spades,Rank.Four));
cards.Add(new Card(Suit.Clubs,Rank.Six));
cards.Add(new Card(Suit.Hearts,Rank.Nine));
cards.Add(new Card(Suit.Spades,Rank.Ace));
Straight(cards);

int Straight(List<Card> cards)
{
    var allCards = cards.OrderByDescending(card => card.GetValue()).ToList();
    var combs = Combinations(allCards, 5);
    foreach (var set in combs)
    {
        var s = set.ToList();
        Console.WriteLine( s[0] + " "+s[1]+" "+s[2]+" "+s[3]+" "+s[4]);
    }
    return 0;
}

static IEnumerable<IEnumerable<T>> Combinations<T>(IEnumerable<T> elements, int k)
{
    var elem = elements.ToArray();
    var size = elem.Length;
 
    if (k > size) yield break;
 
    var numbers = new int[k];
 
    for (var i = 0; i < k; i++)
        numbers[i] = i;
 
    do
    {
        yield return numbers.Select(n => elem[n]);
    } while (NextCombination(numbers, size, k));
}
    
static bool NextCombination(IList<int> num, int n, int k)
{
    bool finished;
 
    var changed = finished = false;
 
    if (k <= 0) return false;
 
    for (var i = k - 1; !finished && !changed; i--)
    {
        if (num[i] < n - 1 - (k - 1) + i)
        {
            num[i]++;
 
            if (i < k - 1)
                for (var j = i + 1; j < k; j++)
                    num[j] = num[j - 1] + 1;
            changed = true;
        }
        finished = i == 0;
    }
 
    return changed;
}
