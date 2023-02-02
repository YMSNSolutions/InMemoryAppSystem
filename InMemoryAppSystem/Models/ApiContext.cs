using Microsoft.EntityFrameworkCore;

namespace InMemoryAppSystem.Models
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "AuthorDb");
        }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<PersonalDetail> PersonalDetails { get; set; }
        public DbSet<TransactionDetail> TransactionDetails { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }

    }
}
