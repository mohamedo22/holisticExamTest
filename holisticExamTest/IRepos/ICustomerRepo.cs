using holisticExamTest.DTOs;

namespace holisticExamTest.IRepos
{
    public interface ICustomerRepo
    {
        public bool addCustomer(CustomerPost customer);
        public List<CustomerPost> getAll();
        public CustomerPost getCustomerById(int id);
    }
}
