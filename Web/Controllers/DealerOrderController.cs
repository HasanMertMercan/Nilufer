using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database;
using ValueTypes.Entity;
using DealerOrderService;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealerOrderController : ControllerBase
    {
        private IDealerOrderBusiness _business;

        public DealerOrderController(IDealerOrderBusiness business)
        {
            _business = business;
        }

        // GET: api/DealerOrder
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DealerOrder>>> GetDealerOrder()
        {
            return await _business.GetDealerOrders();
        }

        // GET: api/DealerOrder/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DealerOrder>> GetDealerOrder(int id)
        {
            var dealerOrder = await _business.GetDealerOrderById(id);

            if (dealerOrder == null)
            {
                return NotFound();
            }

            return dealerOrder;
        }

        // PUT: api/DealerOrder/edit/5
        [HttpPut("edit/{id}")]
        public ActionResult<IEnumerable<string>> EditDealerOrder(int id, DealerOrder dealerOrder)
        {
            if (id != dealerOrder.OrderId)
            {
                return BadRequest();
            }

            var newCustomerOrder =  _business.Update(dealerOrder);
            return new OkObjectResult(dealerOrder);
        }

        // POST: api/DealerOrder/add
        [HttpPost("add")]
        public async Task<ActionResult<DealerOrder>> AddDealerOrder(DealerOrder dealerOrder)
        {
            await _business.Insert(dealerOrder);

            return CreatedAtAction("GetDealerOrder", new { id = dealerOrder.OrderId }, dealerOrder);
        }

        // DELETE: api/DealerOrder/delete/5
        [HttpDelete("delete/{id}")]
        public ActionResult<DealerOrder> DeleteDealerOrder(int id)
        {
            var dealerOrder = _business.Delete(id);

            return new OkObjectResult(dealerOrder);
        }
    }
}
