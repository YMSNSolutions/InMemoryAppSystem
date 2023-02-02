using InMemoryAppSystem.Models;

namespace InMemoryAppSystem.Interface
{
    public interface ITransactionRepository
    {
        public List<TransactionHistory> GetTransctionHistoryDetails(Guid BankID);
        public void DoAccountDeposit(Guid AccountNumberID, double Amount, string MyRef, string YourRef);
        public void DoAccountTransfer(Guid FromBankAccountID, Guid ToBankAccountid, double Amount, string MyRef, string YourRef);
    }
}
