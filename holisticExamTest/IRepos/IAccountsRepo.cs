using holisticExamTest.DTOs;

namespace holisticExamTest.IRepos
{
    public interface IAccountsRepo
    {
        public bool addNewAccount(AccountPostTow account);
        public List<AccountPostTow> getAll();
        public bool editAccount(int id,AccountPostTow account);
        public bool deleteAccount(int id);
    }
}
