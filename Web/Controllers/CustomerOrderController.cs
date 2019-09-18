using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database;
using ValueTypes.Entity;
using CustomerOrderService;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerOrderController : ControllerBase
    {
        private ICustomerOrderBusiness _business;

        public CustomerOrderController(CustomerOrderBusiness business)
        {
            _business = business;
        }

        // GET: api/CustomerOrder
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerOrder>>> GetCustomerOrder()
        {
            return await _business.GetCustomerOrders();
        }

        // GET: api/CustomerOrder/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerOrder>> GetCustomerOrder(int id)
        {
            var customerOrder = await _business.GetCustomerOrderById(id);

            return customerOrder;
        }

        // PUT: api/CustomerOrder/edit/5
        [HttpPut("edit/{id}")]
        public ActionResult<IEnumerable<string>> EditCustomerOrder(int id, CustomerOrder customerOrder)
        {
            if (id != customerOrder.OrderId)
            {
                return BadRequest();
            }

            var newCustomerOrder = _business.Update(customerOrder);
            return new OkObjectResult(newCustomerOrder);
        }

        // POST: api/CustomerOrder/add
        [HttpPost("add")]
        public async Task<ActionResult<CustomerOrder>> PostCustomerOrder(CustomerOrder customerOrder)
        {
            await _business.Insert(customerOrder);

            return CreatedAtAction("GetCustomerOrder", new { id = customerOrder.OrderId }, customerOrder);
        }

        // DELETE: api/CustomerOrder/delete/5
        [HttpDelete("delete/{id}")]
        public ActionResult<CustomerOrder> DeleteCustomerOrder(int id)
        {
            var customerOrder = _business.Delete(id);

            return new OkObjectResult(customerOrder);
        }
    }
}
