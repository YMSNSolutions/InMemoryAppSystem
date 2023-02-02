using InMemoryAppSystem.Controllers;
using InMemoryAppSystem.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryAppSystem.Tests.Mock
{
    public  class TransactionControllerTests
    {

        private TransactionController _controller;
        private ITransactionRepository _repository;

    }

    //[TestInitialize]
    //public void Setup()
    //{
    //    _repository = GetInMemoryRepository();
    //    _controller = new TransactionController(_repository);
    //}
}
