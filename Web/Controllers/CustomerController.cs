using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService;
using Microsoft.AspNetCore.Mvc;
using ValueTypes.Entity;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerBusiness _business;
        public CustomerController(ICustomerBusiness business)
        {
            _business = business;
        }

        // GET api/customer
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var customers = _business.GetCustomers();
            return new OkObjectResult(customers);
        }

        // GET api/customer/{id}
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<string>> GetCustomerById(int id)
        {
            var customers = _business.GetCustomerById(id);
            return new OkObjectResult(customers);
        }

        // GET api/customer/add
        [HttpPost("add")]
        public ActionResult<IEnumerable<string>> AddCustomer(Customer customer)
        {
            var customers = _business.Insert(customer);
            return new OkObjectResult(customers);
        }

        [HttpPut("edit/{id}")]
        public ActionResult<IEnumerable<string>> EditCustomer(int id, Customer customer)
        {
            var customers = _business.Update(customer);
            return new OkObjectResult(customers);
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<IEnumerable<string>> DeleteCustomer(int id)
        {
            var customers = _business.Delete(id);
            return new OkObjectResult(customers);
        }

    }
}