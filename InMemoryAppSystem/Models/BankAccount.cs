using System.ComponentModel.DataAnnotations;

namespace InMemoryAppSystem.Models
{
    public class BankAccount
    {
        public Guid BankAccountID { get; set; }
        public Guid PersonalDetailID { get; set; }   
        public string AcountName { get; set; }
        public string BranchNumber { get; set; }
        public double? AccountBalance { get; set; }
    }
}
