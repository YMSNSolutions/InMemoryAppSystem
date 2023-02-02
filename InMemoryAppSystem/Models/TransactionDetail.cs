using System.ComponentModel.DataAnnotations;

namespace InMemoryAppSystem.Models
{
    public class TransactionDetail
    {
        public Guid TransactionDetailID { get; set; }
        public Guid BankAccountID { get; set; }
        public int TypeID { get; set; }
        public string MyReference { get; set; }
        public string YourReference { get; set; }        
        public DateTime TransactionDate { get; set; }
        public double TransactionAmount { get; set; }

    }
}
