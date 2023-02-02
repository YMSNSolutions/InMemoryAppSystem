using InMemoryAppSystem.Interface;
using InMemoryAppSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InMemoryAppSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        readonly ITransactionRepository _transRepository;
        readonly ICustomerRepository _customerRepository;
        public TransactionController(ITransactionRepository transRepository, ICustomerRepository customerRepository)
        {
            _transRepository = transRepository;
            _customerRepository = customerRepository;
        }
     
        [Route("api/Transaction/GetTransctionHistoryDetails")]
        [HttpGet]
        public ActionResult<List<TransactionHistory>> GetTransctionHistoryDetails(Guid BankId)
        {
            return Ok(_transRepository.GetTransctionHistoryDetails(BankId).ToList());
        }

        [Route("api/Transaction/DoAccountTransfer")]
        [HttpGet]
        public string DoAccountTransfer([FromBody] Guid FromBankAccountid, Guid ToBankAccountid, double Amount, string MyRef, string YourRef)
        {
            if (_customerRepository.GetCustomerBalance(FromBankAccountid) >= Amount)
            {
                _transRepository.DoAccountTransfer(FromBankAccountid, ToBankAccountid, Amount, MyRef, YourRef);
                return "Transfer Successfully Completed";
            }
            else
                return "Insufficient Funds";
        }

        [Route("api/Transaction/DoAccountDeposit")]
        [HttpGet]
        public string DoAccountDeposit([FromBody] Guid AccountID, double Amount, string MyRef, string YourRef)
        {      
                _transRepository.DoAccountDeposit(AccountID, Amount, MyRef, YourRef);
                return "Deposit Completed";
        }
    }
}
