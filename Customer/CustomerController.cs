using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ValueTypes.Entity;
using System.Threading.Tasks;

namespace CustomerService
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

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = _business.GetCustomers();
            return new OkObjectResult(customers);
        }
    }
}
