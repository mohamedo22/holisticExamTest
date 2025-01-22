using System.ComponentModel.DataAnnotations;

namespace holisticExamTest.DTOs
{
    public class BankCardPost
    {
        [Required]
        public string BankCardNumber { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
    }
}
