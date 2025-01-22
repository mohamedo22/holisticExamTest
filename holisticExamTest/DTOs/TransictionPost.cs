using holisticExamTest.models;
using System.ComponentModel.DataAnnotations;

namespace holisticExamTest.DTOs
{
    public class TransictionPost
    {
        [Required]
        public float Amount { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
