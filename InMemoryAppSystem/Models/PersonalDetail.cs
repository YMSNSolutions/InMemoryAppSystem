using System.ComponentModel.DataAnnotations;

namespace InMemoryAppSystem.Models
{
    public class PersonalDetail
    {
        public Guid PersonalDetailID { get; set; }
        public string FullName { get; set; }       
        public string IDNumber { get; set; }
        public string AddressInformation { get; set; }
        public List<BankAccount> BankAccounts { get; set; }

    }
}
