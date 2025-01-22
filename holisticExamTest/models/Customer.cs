namespace holisticExamTest.models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public int BankCardId { get; set; }
        public BankCard BankCard { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
