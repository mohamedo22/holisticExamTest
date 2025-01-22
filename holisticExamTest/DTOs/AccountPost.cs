using holisticExamTest.models;
using System.ComponentModel.DataAnnotations;

namespace holisticExamTest.DTOs
{
    public class AccountPost
    {
        [Required]
        [MaxLength(20)]
        public string AccountNumber { get; set; }
        [Required]
        public float Balance { get; set; }
        public List<TransictionPost> Transictions { get; set; }
    }
}
