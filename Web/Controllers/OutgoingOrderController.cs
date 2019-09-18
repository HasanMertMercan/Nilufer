using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database;
using ValueTypes.Entity;
using OutgoingOrderService;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutgoingOrderController : ControllerBase
    {
        private IOutgoingOrderBusiness _business;

        public OutgoingOrderController(IOutgoingOrderBusiness business)
        {
            _business = business;
        }

        // GET: api/OutgoingOrder
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OutgoingOrder>>> GetOutgoingOrder()
        {
            return await _business.GetAllOutgoingOrders();
        }

        // GET: api/OutgoingOrder/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OutgoingOrder>> GetOutgoingOrder(int id)
        {
            var outgoingOrder = await _business.GetOutgoingOrderById(id);

            if (outgoingOrder == null)
            {
                return NotFound();
            }

            return outgoingOrder;
        }

        // PUT: api/OutgoingOrder/edit/5
        [HttpPut("edit/{id}")]
        public ActionResult<IEnumerable<string>> EditOutgoingOrder(int id, OutgoingOrder outgoingOrder)
        {
            if (id != outgoingOrder.OrderId)
            {
                return BadRequest();
            }

            var newOutgoingOrder = _business.Update(outgoingOrder);
            return new OkObjectResult(newOutgoingOrder);

        }

        // POST: api/OutgoingOrder/add
        [HttpPost("add")]
        public async Task<ActionResult<OutgoingOrder>> PostOutgoingOrder(OutgoingOrder outgoingOrder)
        {
            await _business.Insert(outgoingOrder);

            return CreatedAtAction("GetOutgoingOrder", new { id = outgoingOrder.OrderId }, outgoingOrder);
        }

        // DELETE: api/OutgoingOrder/delete/5
        [HttpDelete("delete/{id}")]
        public ActionResult<OutgoingOrder> DeleteOutgoingOrder(int id)
        {
            var outgoingOrder = _business.Delete(id);

            return new OkObjectResult(outgoingOrder);
        }
    }
}
