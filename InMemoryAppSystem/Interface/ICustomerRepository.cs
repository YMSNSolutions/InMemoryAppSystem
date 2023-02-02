using InMemoryAppSystem.Models;

namespace InMemoryAppSystem.Interface
{
    public interface ICustomerRepository
    {
        public List<PersonalDetail> GetPersonalDetails();
        public double? GetCustomerBalance(Guid BankId);
    }
}
