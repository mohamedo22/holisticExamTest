namespace holisticExamTest.models
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string BrnachLocation { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
