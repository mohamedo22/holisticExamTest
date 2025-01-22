using holisticExamTest.models;

namespace holisticExamTest.DTOs
{
    public class BranchDto
    {
        public string BranchName { get; set; }
        public string BrnachLocation { get; set; }
        public List<EmployeeDto> Employees { get; set; }
    }
}
