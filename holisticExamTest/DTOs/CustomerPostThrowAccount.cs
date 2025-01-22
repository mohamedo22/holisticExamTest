using holisticExamTest.models;

namespace holisticExamTest.DTOs
{
    public class CustomerPostThrowAccount
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public BankCardPost BankCard { get; set; }
    }
}
