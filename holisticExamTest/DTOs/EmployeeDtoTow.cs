using holisticExamTest.models;

namespace holisticExamTest.DTOs
{
    public class EmployeeDtoTow
    {
        public string EmployeeName { get; set; }
        public string EmployeePosition { get; set; }
        public List<BranchDtoThrowEmployee> Branches { get; set; }
    }
}
