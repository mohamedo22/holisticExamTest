namespace holisticExamTest.models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeePosition { get; set; }
        public List<Branch> Branches { get; set; }
    }
}
