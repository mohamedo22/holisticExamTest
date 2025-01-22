using holisticExamTest.models;
using System.ComponentModel.DataAnnotations;

namespace holisticExamTest.DTOs
{
    public class CustomerPost
    {
        [Required]
        public string CustomerName { get; set; }
        [Required]
        [EmailAddress]
        public string CustomerEmail { get; set; }
        [MaxLength(15)]
        public string CustomerPhone { get; set; }
        public BankCardPost BankCard { get; set; }
        public List<AccountPost> Accounts { get; set; }
    }
}
