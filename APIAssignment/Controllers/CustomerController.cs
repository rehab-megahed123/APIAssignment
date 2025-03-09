using API.BLL.Manager.Abstraction;
using API.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerManager customerManager;
        public CustomerController(ICustomerManager customerManager)
        {
            this.customerManager = customerManager;

        }

        [HttpPost("{name:alpha}/{issuccess}")]
        public IActionResult AddCustomer(int? id,string name,bool issuccess)
        {
            Customer customer = new Customer();
            customer.IsSucceed = issuccess;
            customer.Name = name;
            customerManager.AddCustomer(customer);
            return CreatedAtAction("GetById", new {id=id},customer);

        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            customerManager.GetById(id);
            return Ok();
        }
        [HttpPost]
        public IActionResult AddCustomerComplex(Customer customer)
        {
            customerManager.AddCustomer(customer);
            return CreatedAtAction("GetById", new { id = customer.Id }, customer);
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer=customerManager.GetById(id);
            customerManager.DeleteCustomer(customer);
            return NoContent();

        }
        
       

    }
}
