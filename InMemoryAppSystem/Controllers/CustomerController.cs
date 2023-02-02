using InMemoryAppSystem.Interface;
using InMemoryAppSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Cryptography;

namespace InMemoryAppSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository authorRepository)
        {
            _customerRepository = authorRepository;
        }


        [HttpGet]
        public ActionResult<List<PersonalDetail>> Get()
        {
            return Ok(_customerRepository.GetPersonalDetails().ToList());
        }

        [Route("api/Customer/GetCustomerBalance")]
        [HttpGet]
        public ActionResult<double> GetCustomerBalance(Guid PersonalID, Guid BankID)
        {

            return Ok(_customerRepository.GetCustomerBalance(BankID));
        }

    }
}
