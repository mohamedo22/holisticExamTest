using holisticExamTest.DTOs;
using holisticExamTest.IRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace holisticExamTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo employeeRepo;

        public EmployeeController(IEmployeeRepo employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }
        [HttpGet]
        public IActionResult GetAll() {

            return Ok(employeeRepo.getAll());
        
        }
        [HttpPost]
        public IActionResult addNewEmployee(EmployeeDtoTow employee)
        {
            if(employeeRepo.addEmployee(employee))
                return Ok();
            return BadRequest();
        }
        [HttpPut]
        public IActionResult editEmployee(EmployeeDtoTow employee, int id) 
        {

            if(employeeRepo.editEmployee(employee, id))
                return Ok();
            return NotFound();
        
        }

    }
}
