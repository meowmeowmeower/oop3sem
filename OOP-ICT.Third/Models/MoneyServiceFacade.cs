using OOP_ICT.Models;
using OOP_ICT.Second.Models;

namespace OOP_ICT.Third.Models;

public class MoneyServiceFacade
{
    private BlackjackCasino _casino;
    private List<Player> _players;
    private List<uint> _bets;
    
    public MoneyServiceFacade(BlackjackCasino casino, List<Player> players, List<uint> bets)
    {
        _casino = casino;
        _players = players;
        _bets = bets;
    }
    
    public void WriteOffBets()
    {
        foreach (var player in _players)
        {
            _casino.ExchangeChips(player.GetId(), _bets[_players.IndexOf(player)]);
        }
    }

    public void PayPlayers(List<Player> winners)
    {
        foreach (var winner in winners)
        {
            _casino.BuyChips(winner.GetId(), _bets[_players.IndexOf(winner)]*2);
        }
    }
}