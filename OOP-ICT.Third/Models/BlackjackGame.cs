using OOP_ICT.Exceptions;
using OOP_ICT.Models;
using OOP_ICT.Second.Exceptions;
using OOP_ICT.Second.Models;

namespace OOP_ICT.Third.Models;

public class BlackjackGame
{
    private const int DealerMin = 17;
    private List<Player> _players;
    private List<uint> _bets;
    private CardDeck _deck;
    private Dealer _dealer;
    private BlackjackCasino _casino;
    private MoneyServiceFacade _facade;
    

    public BlackjackGame(BlackjackCasino casino)
    {
        _players = new List<Player>();
        _bets = new List<uint>();
        _deck = new CardDeck();
        _dealer = new Dealer(_deck);
        _casino = casino;
    }

    public void AddPlayer(Player player, uint bet)
    {
        if (!_casino.IsEnoughChips(player.GetId(),bet))
        {
            throw new NotEnoughOnBalanceException("There is not enough chips on casino account :(");
        }
        _players.Add(player);
        _bets.Add(bet);
    }
    
    public int GetSumHandOfPlayer(List<Card> hand)
    {
        if (hand.Count == 0  || hand[0].GetValue() == null)
        {
            throw new WrongGameException("It isn't blackjack game");
        }

        var blackjackmax = 21;
        var ace = 11;
        var values = hand.Select( card => card.GetValue()).ToList();
        for (int ind = 0; ind < values.Count;ind++)
        {
            switch (values[ind])
            {
                case 11:
                    values[ind] = 10;
                    break;
                case 12:
                    values[ind] = 10;
                    break;
                case 13:
                    values[ind] = 10;
                    break;
                case 14:
                    values[ind] = 11;
                    break;
            }
        }
        if (values.Sum() > blackjackmax && values.Contains(ace))
        {
            values[values.IndexOf(ace)] = 1;
        }

        return values.Sum();
    }

    public void StartGame()
    {
        _facade = new MoneyServiceFacade(_casino, _players, _bets);
        _dealer.Shuffle();
        foreach (var player in _players) {
                player.GetCard(_dealer.GiveCard());
        }
        
        foreach (var player in _players)
        {
            player.GetCard(_dealer.GiveCard());
        }
        _dealer.GetCard();
        _facade.WriteOffBets();
    }

    public bool CheckEndGame()
    {
        return (GetSumHandOfPlayer(_dealer.GetHand()) > DealerMin);
    }

    public void DealerGetsCard()
    {
        _dealer.GetCard();
    }

    public void PlayerGetsCard(uint id)
    {
        if (_players.FirstOrDefault(player => player.GetId() == id) is null)
            throw new NoPlayerException("This player doesn't take part in a game");
        _players.FirstOrDefault(player => player.GetId() == id).GetCard(_dealer.GiveCard());
    }

    public List<Player>? DetermineWinner()
    {
        var dealerSum = GetSumHandOfPlayer(_dealer.GetHand());
        var playersSum = _players.Select(player => GetSumHandOfPlayer(player.GetHand())).ToList();
        return dealerSum > playersSum.Max() ? null : _players.FindAll((player) => GetSumHandOfPlayer(player.GetHand()) == playersSum.Max());
    }

    public void PayWinners()
    {
        if (this.DetermineWinner() != null)
        {
            _facade.PayPlayers(this.DetermineWinner());
        }
    }

    public List<Player> GetPlayers()
    {
        return _players;
    }
}