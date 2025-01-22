namespace holisticExamTest.models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountNumber { get; set; }
        public float Balance { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<Transiction> Transictions { get; set; }
    }
}
