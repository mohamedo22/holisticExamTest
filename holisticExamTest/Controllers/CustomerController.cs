using holisticExamTest.DTOs;
using holisticExamTest.IRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace holisticExamTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepo customerRepo;

        public CustomerController(ICustomerRepo customerRepo)
        {
            this.customerRepo = customerRepo;
        }
        [HttpGet]
        public IActionResult GetAll() {
            return Ok(customerRepo.getAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            var CustomerData = customerRepo.getCustomerById(id);
            if (CustomerData != null)
            {
                return Ok(CustomerData);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult AddCustomer(CustomerPost customer)
        {
            if (customerRepo.addCustomer(customer))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
