using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DealerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValueTypes.Entity;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealerController : ControllerBase
    {
        private IDealerBusiness _business;
        public DealerController(IDealerBusiness business)
        {
            _business = business;
        }
        // GET: api/Dealer
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var dealers = _business.GetDealers();
            return new OkObjectResult(dealers);
        }

        // GET: api/Dealer/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<IEnumerable<string>> GetDealerById(int id)
        {
            var dealer = _business.GetDealerById(id);
            return new OkObjectResult(dealer);
        }

        // POST: api/Dealer/add
        [HttpPost("add")]
        public ActionResult<IEnumerable<string>> AddDealer(Dealer dealer)
        {
            var newDealer = _business.Insert(dealer);
            return new OkObjectResult(newDealer);
        }

        // PUT: api/Dealer/edit/5
        [HttpPut("edit/{id}")]
        public ActionResult<IEnumerable<string>> EditDealer(int id, Dealer dealer)
        {
            var newDealer = _business.Update(dealer);
            return new OkObjectResult(newDealer);
        }

        // DELETE: api/Dealer/delete/5
        [HttpDelete("delete/{id}")]
        public ActionResult<IEnumerable<string>> Delete(int id)
        {
            var dealer = _business.Delete(id);
            return new OkObjectResult(dealer);
        }
    }
}
