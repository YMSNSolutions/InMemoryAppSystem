namespace InMemoryAppSystem.Models
{
    public class TransactionHistory
    {
        public Guid PersonalDetailID { get; set; }
        public string FullName { get; set; }
        public Guid BankID { get; set; }
        public string AccountName { get; set; }
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
    }
}
