using holisticExamTest.DTOs;
using holisticExamTest.IRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace holisticExamTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchRepo branchRepo;

        public BranchController(IBranchRepo branchRepo)
        {
            this.branchRepo = branchRepo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(branchRepo.getAll());
        }
        [HttpPost]
        public IActionResult addBranch(BranchDto branch)
        {
            if (branchRepo.addNewBranch(branch))
            {
                return Ok();
            }
            return BadRequest();

        }
        [HttpDelete]
        public IActionResult deleteBranch(int id)
        {
            if (branchRepo.removeBranch(id))
                return Ok();
            return NotFound();
        }
    }
}
