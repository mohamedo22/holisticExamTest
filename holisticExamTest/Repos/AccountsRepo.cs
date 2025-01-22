using holisticExamTest.appcontext;
using holisticExamTest.DTOs;
using holisticExamTest.IRepos;
using holisticExamTest.models;
using Microsoft.EntityFrameworkCore;

namespace holisticExamTest.Repos
{
    public class AccountsRepo : IAccountsRepo
    {
        private readonly appdbcontext appdbcontext;

        public AccountsRepo(appdbcontext appdbcontext)
        {
            this.appdbcontext = appdbcontext;
        }

        public bool addNewAccount(AccountPostTow account)
        {
            var newAccount = new Account
            {
                AccountNumber = account.AccountNumber,
                Balance = account.Balance,
                Customer = new Customer {
                    CustomerEmail = account.Customer.CustomerEmail,
                    CustomerName = account.Customer.CustomerName,
                    CustomerPhone = account.Customer.CustomerPhone,
                    BankCard = new BankCard
                    {
                        BankCardNumber = account.Customer.BankCard.BankCardNumber,
                        ExpiryDate = account.Customer.BankCard.ExpiryDate,
                    }
                },
                Transictions = account.Transictions.Select(i=>new Transiction
                {
                    Amount = i.Amount,
                    Date = i.Date,
                }).ToList()
            };
            try
            {
                appdbcontext.accounts.Add(newAccount);
                appdbcontext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<AccountPostTow> getAll()
        {
            var accounts = appdbcontext.accounts.Select(i=>new AccountPostTow
            {
                Balance = i.Balance,
                AccountNumber = i.AccountNumber,
                Customer = new CustomerPostThrowAccount
                {
                    CustomerEmail= i.Customer.CustomerEmail,
                    CustomerName = i.Customer.CustomerName,
                    CustomerPhone = i.Customer.CustomerPhone,
                    BankCard = new BankCardPost
                    {
                        BankCardNumber = i.Customer.BankCard.BankCardNumber,
                        ExpiryDate = i.Customer.BankCard.ExpiryDate,
                    }
                },
                Transictions = i.Transictions.Select(t=>new TransictionPost
                {
                    Amount= t.Amount,
                    Date = t.Date,
                }).ToList()
            }).ToList();
            return accounts;
        }

        public bool editAccount(int id , AccountPostTow account)
        {
            var realAccount = appdbcontext.accounts.Include(i=>i.Transictions).Include(i=>i.Customer).ThenInclude(i=>i.BankCard).FirstOrDefault(i=>i.AccountId == id);
            if (realAccount == null)
            {
                return false;
            }
            realAccount.Balance = account.Balance;
            realAccount.AccountNumber = account.AccountNumber;
            realAccount.Customer = new Customer
            {
                CustomerEmail = account.Customer.CustomerEmail,
                CustomerName = account.Customer.CustomerName,
                CustomerPhone = account.Customer.CustomerPhone,
                BankCard = new BankCard
                {
                    BankCardNumber = account.Customer.BankCard.BankCardNumber,
                    ExpiryDate = account.Customer.BankCard.ExpiryDate,
                    
                },
                

            };
            realAccount.Transictions = account.Transictions.Select(i => new Transiction
            {
                Amount = i.Amount,
                Date = i.Date,
            }).ToList();
            try
            {
                appdbcontext.accounts.Update(realAccount);
                appdbcontext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool deleteAccount(int id)
        {
            Account account = appdbcontext.accounts.FirstOrDefault(i=> i.AccountId == id);
            if (account == null) { return false; }
            appdbcontext.accounts.Remove(account);
            appdbcontext.SaveChanges();
            return true;
        }
    }
}
