using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService;
using Microsoft.AspNetCore.Mvc;

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
            return new OkObjectResult
                (customers);
        }
    }
}