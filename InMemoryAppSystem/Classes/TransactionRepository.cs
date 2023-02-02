using InMemoryAppSystem.Interface;
using InMemoryAppSystem.Models;

namespace InMemoryAppSystem.Classes
{
    public class TransactionRepository: ITransactionRepository
    {
        public List<TransactionHistory> GetTransctionHistoryDetails(Guid BankID)
        {

            using (var context = new ApiContext())
            {
                var list = (from x in context.PersonalDetails 
                            join y in context.BankAccounts on x.PersonalDetailID equals y.PersonalDetailID
                            join s in context.TransactionDetails on y.BankAccountID equals s.BankAccountID
                            select new TransactionHistory
                            {
                                PersonalDetailID = x.PersonalDetailID,
                                FullName  = x.FullName,
                                BankID  = y.BankAccountID,
                                AccountName = y.AcountName,
                                Description = s.MyReference,
                                TransactionDate  = s.TransactionDate,
                                Debit = ((s.TypeID  == 1) ? s.TransactionAmount : 0),
                                Credit = ((s.TypeID == 2) ? 0 : s.TransactionAmount)
                            }).ToList();
               
                return list;
            }
        }

        public void DoAccountDeposit(Guid AccountNumberID, double Amount, string MyRef, string YourRef)
        {

            //Credit Account
            UpdateTrasanctionDetails(AccountNumberID, Amount,2, YourRef, MyRef);
            //Update Account balance
            UpdateBankAccountDetails(AccountNumberID, Amount, 2);

        }

        public void DoAccountTransfer(Guid FromBankAccountID, Guid ToBankAccountid, double Amount, string MyRef, string YourRef)
        {

            //Debit Account
            UpdateTrasanctionDetails(FromBankAccountID, Amount, 1, MyRef, YourRef);

            //Update Account balance
            UpdateBankAccountDetails(FromBankAccountID, Amount, 1);


            //Credit Account
            UpdateTrasanctionDetails(ToBankAccountid, Amount, 2, YourRef, MyRef);
            //Update Account balance
            UpdateBankAccountDetails(ToBankAccountid, Amount, 2);
        }

        private void UpdateBankAccountDetails(Guid BankAccountID, double Amount, int TransTypeID)
        {

            using (var context = new ApiContext())
            {
               BankAccount bank = context.BankAccounts.Where(x => x.BankAccountID == BankAccountID).FirstOrDefault();

                if (bank != null)
                {
                    bank.AccountBalance = (TransTypeID == 1) ? bank.AccountBalance - Amount : bank.AccountBalance + Amount;
                    context.SaveChanges();
                }
            }
        }

        private void UpdateTrasanctionDetails(Guid BankAccountID, double Amount, int TransTypeID, string MyRef, string YourRef)
        {

            using (var context = new ApiContext())
            {
                var transaction = new TransactionDetail
                {
                    TransactionDetailID = Guid.NewGuid(),
                    BankAccountID = BankAccountID,
                    TypeID = TransTypeID,
                    MyReference = MyRef,
                    YourReference = YourRef,
                    TransactionDate = DateTime.Now,
                    TransactionAmount = 0
                };
                context.TransactionDetails.AddRange(transaction);
                context.SaveChanges();
            }
        }
    }
}
