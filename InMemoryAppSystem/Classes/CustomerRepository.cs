using InMemoryAppSystem.Interface;
using InMemoryAppSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace InMemoryAppSystem.Classes
{
    public class CustomerRepository : ICustomerRepository
    {
        public CustomerRepository()
        {
            //
            using (var context = new ApiContext())
            {
              
                //Seed Transaction Details
                var Transaction_ = new List<TransactionType>
                {
                        new TransactionType
                        {
                            TransactionTypeId  = Guid.NewGuid(),
                            Description = "Debit",
                            TypeID  = 1
                        },
                        new TransactionType
                        {
                            TransactionTypeId  = Guid.NewGuid(),
                            Description = "Credit",
                            TypeID = 2
                        }
                };

                context.TransactionTypes.AddRange(Transaction_);



                //Seed Personal Details
                Guid PerID = Guid.NewGuid();
                var PersonalInfo = new PersonalDetail
                {
                    PersonalDetailID = PerID,
                    FullName = "Ridley Mamphaga",
                    IDNumber = "30303030303030",
                    AddressInformation = "5239 Madrid Street",
                    BankAccounts = new List<BankAccount>()
                    {
                                new BankAccount { BankAccountID  =  Guid.NewGuid(), AcountName = "First National Bank", BranchNumber = "01113", AccountBalance = 5000, PersonalDetailID = PerID},
                                new BankAccount { BankAccountID  =  Guid.NewGuid(), AcountName = "Standard Bank", BranchNumber = "01114", AccountBalance = 5000, PersonalDetailID = PerID},
                                new BankAccount { BankAccountID  =  Guid.NewGuid(), AcountName = "Nedbank Limited", BranchNumber = "01115", AccountBalance = 5000, PersonalDetailID = PerID},
                    }
                };
                context.PersonalDetails.AddRange(PersonalInfo);


                PerID = new Guid();
                PersonalInfo = new PersonalDetail
                {
                    PersonalDetailID = Guid.NewGuid(),
                    FullName = "Joe Doe",
                    IDNumber = "40003030000004",
                    AddressInformation = "403 Lilogwe Street",
                    BankAccounts = new List<BankAccount>()
                    {
                                new BankAccount { BankAccountID  =  Guid.NewGuid(), AcountName = "First National Bank", BranchNumber = "04944", AccountBalance = 20000, PersonalDetailID = PerID}                             
                    }
                };
                context.PersonalDetails.AddRange(PersonalInfo);

                PerID = new Guid();
                PersonalInfo = new PersonalDetail
                {
                    PersonalDetailID = PerID,
                    FullName = "Silver Mokope",
                    IDNumber = "9584484848484",
                    AddressInformation = "45 Polofields",
                    BankAccounts = new List<BankAccount>()
                    {
                                new BankAccount { BankAccountID  =  Guid.NewGuid(), AcountName = "Capitec", BranchNumber = "10000", AccountBalance = 2000, PersonalDetailID = PerID},
                                new BankAccount { BankAccountID  =  Guid.NewGuid(), AcountName = "RMB", BranchNumber = "10001", AccountBalance = 3000, PersonalDetailID = PerID},
                                new BankAccount { BankAccountID  =  Guid.NewGuid(), AcountName = "ABSA limited", BranchNumber = "10002", AccountBalance = 8000, PersonalDetailID = PerID},
                    }
                };
                context.PersonalDetails.AddRange(PersonalInfo);


                PerID = new Guid();
                PersonalInfo = new PersonalDetail
                {
                    PersonalDetailID = PerID,
                    FullName = "Dudu Zuma",
                    IDNumber = "9484848393931",
                    AddressInformation = "3404 Louis Trichardt",
                    BankAccounts = new List<BankAccount>()
                    {
                                new BankAccount { BankAccountID  =  Guid.NewGuid(), AcountName = "First National Bank", BranchNumber = "01113", AccountBalance = 4000, PersonalDetailID = PerID},
                                new BankAccount { BankAccountID  =  Guid.NewGuid(), AcountName = "Standard Bank", BranchNumber = "01114", AccountBalance = 20000, PersonalDetailID = PerID},
                                new BankAccount { BankAccountID  =  Guid.NewGuid(), AcountName = "Nedbank Limited", BranchNumber = "01115", AccountBalance = 4000, PersonalDetailID = PerID},
                    }
                };
                context.PersonalDetails.AddRange(PersonalInfo);


                PerID = new Guid();
                PersonalInfo = new PersonalDetail
                {
                    PersonalDetailID = PerID,
                    FullName = "Sarah Matambule",
                    IDNumber = "600303939999393",
                    AddressInformation = "789 Pretoria West",
                    BankAccounts = new List<BankAccount>()
                    {
                                new BankAccount { BankAccountID  =  Guid.NewGuid(), AcountName = "First National Bank", BranchNumber = "01113", AccountBalance = 3000, PersonalDetailID = PerID},
                                new BankAccount { BankAccountID  =  Guid.NewGuid(), AcountName = "ABSA limited", BranchNumber = "10002", AccountBalance = 2500, PersonalDetailID = PerID},
                    }
                };
                context.PersonalDetails.AddRange(PersonalInfo);

                //Seed Transaction Information
            
                context.SaveChanges();
            }

        }

        public List<PersonalDetail> GetPersonalDetails()
        {    

            using (var context = new ApiContext())
            {
                var list = context.PersonalDetails
                    .Include(a => a.BankAccounts)
                    .ToList();
                return list;
            }
        }

        public double? GetCustomerBalance(Guid BankId)
        {

            using (var context = new ApiContext())
            {
                var bal = (from x in context.PersonalDetails
                           join y in context.BankAccounts on x.PersonalDetailID equals y.PersonalDetailID
                           where y.BankAccountID == BankId
                           select y).FirstOrDefault();

                return bal.AccountBalance;
            }
        }
    }
}
