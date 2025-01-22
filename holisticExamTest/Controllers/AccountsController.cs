using holisticExamTest.DTOs;
using holisticExamTest.IRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace holisticExamTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsRepo accountsRepo;

        public AccountsController(IAccountsRepo accountsRepo)
        {
            this.accountsRepo = accountsRepo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(accountsRepo.getAll());
        }
        [HttpPut("{id}")]
        public IActionResult editAccount(int id,AccountPostTow account) {
            if (accountsRepo.editAccount(id, account)) {
            return Ok();
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult AddAccount(AccountPostTow account)
        {
            if (accountsRepo.addNewAccount(account))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult DeleteAccount(int id) {
            if (accountsRepo.deleteAccount(id)) {
                return Ok();
            }
            return NotFound();
        
        }

    }
}
