namespace OOP_ICT.Second.Models.AccountLogic;

public class BankAccountFactory: AccountFactory
{
    public override BankAccount CreateAccount(uint id)
    {
        return new BankAccount(id);
    }
}