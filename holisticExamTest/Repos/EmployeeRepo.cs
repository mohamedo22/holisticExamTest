using holisticExamTest.appcontext;
using holisticExamTest.DTOs;
using holisticExamTest.IRepos;
using holisticExamTest.models;

namespace holisticExamTest.Repos
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly appdbcontext appdbcontext;

        public EmployeeRepo(appdbcontext appdbcontext)
        {
            this.appdbcontext = appdbcontext;
        }

        public bool addEmployee(EmployeeDtoTow employee)
        {
            var newEmployee = new Employee
            {
                EmployeeName = employee.EmployeeName,
                EmployeePosition = employee.EmployeePosition,
                Branches = employee.Branches.Select(i=> new Branch
                {
                    BranchName = i.BranchName,
                    BrnachLocation = i.BrnachLocation,
                }).ToList()
            };
            try
            {
                appdbcontext.employees.Add(newEmployee);
                appdbcontext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool editEmployee(EmployeeDtoTow employee, int id)
        {
            var realEmployee = appdbcontext.employees.FirstOrDefault(i=>i.EmployeeId == id);
            if (realEmployee == null)
            {
                return false;
            }
            realEmployee.EmployeeName = employee.EmployeeName;
            realEmployee.EmployeePosition = employee.EmployeePosition;
            realEmployee.Branches = employee.Branches.Select(i=>new Branch {
                BranchName = i.BranchName,
                BrnachLocation=i.BrnachLocation
            }).ToList();
            try
            {
                appdbcontext.employees.Update(realEmployee);
                appdbcontext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<EmployeeDtoTow> getAll()
        {
            var employees = appdbcontext.employees.Select(i=> new EmployeeDtoTow { 
                EmployeeName = i.EmployeeName,
                EmployeePosition = i.EmployeePosition,
                Branches = i.Branches.Select(i=> new BranchDtoThrowEmployee
                {
                    BranchName=i.BranchName,
                    BrnachLocation = i.BrnachLocation
                }).ToList()
                
            }).ToList();
            return employees;
        }
    }
}
