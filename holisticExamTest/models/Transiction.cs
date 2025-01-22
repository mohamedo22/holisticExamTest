namespace holisticExamTest.models
{
    public class Transiction
    {
        public int TransictionId {  get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
