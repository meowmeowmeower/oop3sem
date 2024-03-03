using OOP_ICT.Second.Models.AccountLogic;

namespace OOP_ICT.Second.Models;

public class CasinoAccountFactory: AccountFactory
{
    public override CasinoAccount CreateAccount(uint id)
    {
        return new CasinoAccount(id);
    }
}