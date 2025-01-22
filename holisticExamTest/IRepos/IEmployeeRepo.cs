using holisticExamTest.DTOs;

namespace holisticExamTest.IRepos
{
    public interface IEmployeeRepo
    {
        public List<EmployeeDtoTow> getAll();
        public bool addEmployee(EmployeeDtoTow employee);
        public bool editEmployee(EmployeeDtoTow employee, int id);
    }
}
