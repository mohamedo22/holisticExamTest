using holisticExamTest.DTOs;

namespace holisticExamTest.IRepos
{
    public interface IBranchRepo
    {
        public bool addNewBranch(BranchDto branch);
        public bool removeBranch(int id);
        public List<BranchDto> getAll();
    }
}
