using holisticExamTest.appcontext;
using holisticExamTest.DTOs;
using holisticExamTest.IRepos;
using holisticExamTest.models;

namespace holisticExamTest.Repos
{
    public class BranchRepo : IBranchRepo
    {
        private readonly appdbcontext appdbcontext;

        public BranchRepo(appdbcontext appdbcontext)
        {
            this.appdbcontext = appdbcontext;
        }

        public bool addNewBranch(BranchDto branch)
        {
            var newBranch = new Branch
            {
                BranchName = branch.BranchName,
                BrnachLocation = branch.BrnachLocation,
                Employees = branch.Employees.Select(i=> new Employee
                {
                    EmployeeName = i.EmployeeName,
                    EmployeePosition = i.EmployeePosition,
                }).ToList(),
            };
            try
            {
                appdbcontext.branches.Add(newBranch);
                appdbcontext.SaveChanges();
                return true;
            }
            catch{
            return false;
            }
        }

        public List<BranchDto> getAll()
        {
            var Branches = appdbcontext.branches.Select(i => new BranchDto { 
                BranchName=i.BranchName,
                BrnachLocation=i.BrnachLocation,
                Employees = i.Employees.Select(i=>new EmployeeDto
                {
                    EmployeeName=i.EmployeeName,
                    EmployeePosition=i.EmployeePosition,
                }).ToList()
            }).ToList();
            return Branches;
        }

        public bool removeBranch(int id)
        {
            var branch = appdbcontext.branches.FirstOrDefault(i=> i.BranchId == id);
            if (branch == null)
                return false;
            appdbcontext.branches.Remove(branch);
            appdbcontext.SaveChanges();
            return true;
        }
    }
}
