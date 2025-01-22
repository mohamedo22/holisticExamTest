using holisticExamTest.models;

namespace holisticExamTest.DTOs
{
    public class AccountPostTow
    {
        public string AccountNumber { get; set; }
        public float Balance { get; set; }
        public CustomerPostThrowAccount Customer { get; set; }
        public List<TransictionPost> Transictions { get; set; }
    }
}
