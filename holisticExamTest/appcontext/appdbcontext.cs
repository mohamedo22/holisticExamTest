using holisticExamTest.models;
using Microsoft.EntityFrameworkCore;

namespace holisticExamTest.appcontext
{
    public class appdbcontext : DbContext
    {
        public appdbcontext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Account> accounts { get; set; }
        public DbSet<BankCard> bankCards { get; set; }
        public DbSet<Branch> branches { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Transiction> transictions { get; set; }
    }
}
