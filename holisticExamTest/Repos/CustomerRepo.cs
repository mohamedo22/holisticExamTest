using holisticExamTest.appcontext;
using holisticExamTest.DTOs;
using holisticExamTest.IRepos;
using holisticExamTest.models;
using Microsoft.EntityFrameworkCore;

namespace holisticExamTest.Repos
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly appdbcontext appdbcontext;

        public CustomerRepo(appdbcontext appdbcontext)
        {
            this.appdbcontext = appdbcontext;
        }

        public bool addCustomer(CustomerPost customer)
        {
            Customer newCustomer = new Customer{
                CustomerName = customer.CustomerName,
                CustomerEmail = customer.CustomerEmail,
                CustomerPhone = customer.CustomerPhone,
                BankCard = new BankCard
                {
                    BankCardNumber = customer.BankCard.BankCardNumber,
                    ExpiryDate = customer.BankCard.ExpiryDate
                },
                Accounts = customer.Accounts.Select(i=> new Account
                {
                    AccountNumber = i.AccountNumber,
                    Balance = i.Balance,
                    Transictions = i.Transictions.Select(t=> new Transiction
                    {
                        Amount = t.Amount,
                        Date = t.Date,
                    }).ToList()
                }).ToList(),
            };
            try
            {
                appdbcontext.customers.Add(newCustomer);
                appdbcontext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public List<CustomerPost> getAll()
        {
            var Customers = appdbcontext.customers.Select(i => new CustomerPost
            {
                CustomerEmail = i.CustomerEmail,
                CustomerPhone = i.CustomerPhone,    
                CustomerName = i.CustomerName,
                Accounts = i.Accounts.Select(a=> new AccountPost
                {
                    AccountNumber=a.AccountNumber,
                    Balance = a.Balance,
                    Transictions = a.Transictions.Select(t=> new TransictionPost
                    {
                        Date = t.Date,
                        Amount = t.Amount,
                    }).ToList()
                }).ToList(),
                BankCard = new BankCardPost { 
                    BankCardNumber = i.BankCard.BankCardNumber,
                    ExpiryDate = i.BankCard.ExpiryDate,
                }
            }
            ).ToList();
            return Customers;
        }

        public CustomerPost getCustomerById(int id)
        {
            var Customer = appdbcontext.customers.Include(i=>i.BankCard).Include(i => i.Accounts).ThenInclude(x=>x.Transictions).FirstOrDefault(i=>i.CustomerId == id);
            if (Customer != null)
            {
                return new CustomerPost
                {
                    CustomerEmail= Customer.CustomerEmail,
                    CustomerPhone= Customer.CustomerPhone,
                    CustomerName = Customer.CustomerName,
                    Accounts = Customer.Accounts.Select(a=> new AccountPost
                    {
                        AccountNumber = a.AccountNumber,
                        Balance = a.Balance,
                        Transictions = a.Transictions.Select(t=> new TransictionPost
                        {
                            Amount = t.Amount,
                            Date = t.Date,
                        }).ToList()
                    }).ToList(),
                    BankCard = new BankCardPost
                    {
                        BankCardNumber= Customer.BankCard.BankCardNumber,
                        ExpiryDate = Customer.BankCard.ExpiryDate,
                    }
                };
            }
            else
            {
                return null;
            }
        }
    }
}
