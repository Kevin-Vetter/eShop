using DAL.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Service;

namespace API.Controllers
{
    public class CustomerController : ControllerBase
    {
        private readonly IRepo _repo;

        public CustomerController(IRepo repo)
        {
            _repo = repo;
        }



        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            Customer? customer = _repo.GetCustomerById(id);
            if (customer != null)
                return Ok(_repo.GetCustomerById(id));
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddCustomer(string firstName, string lastName, string adress, string email)
        {

            try
            {
                _repo.CreateNewCustomer(firstName, lastName, adress, email);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return Ok();
        }

        [HttpPatch]
        public IActionResult UpdateCustomer(int id, [FromBody] JsonPatchDocument<Customer> newCustomer)
        {
            try
            {
                _repo.UpdateCustomer(id, newCustomer);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok();
        }
    }
}
