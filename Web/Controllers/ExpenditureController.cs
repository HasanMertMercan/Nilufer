using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database;
using ValueTypes.Entity;
using ExpenditureService;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenditureController : ControllerBase
    {
        private IExpenditureBusiness _business;

        public ExpenditureController(IExpenditureBusiness business)
        {
            _business = business;
        }

        // GET: api/Expenditure
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Expenditure>>> GetExpenditure()
        {
            return await _business.GetAllExpendetures();
        }

        // GET: api/Expenditure/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Expenditure>> GetExpenditureById(int id)
        {
            var expenditure = await _business.GetExpenditureById(id);

            if (expenditure == null)
            {
                return NotFound();
            }

            return expenditure;
        }

        // PUT: api/Expenditure/edit/5
        [HttpPut("edit/{id}")]
        public ActionResult<IEnumerable<string>> EditExpenditure(int id, Expenditure expenditure)
        {
            if (id != expenditure.Id)
            {
                return BadRequest();
            }

            var newExpenditure = _business.Update(expenditure);
            return new OkObjectResult(newExpenditure);
        }

        // POST: api/Expenditure/add
        [HttpPost("add")]
        public async Task<ActionResult<Expenditure>> PostExpenditure(Expenditure expenditure)
        {
            await _business.Insert(expenditure);

            return CreatedAtAction("GetExpenditure", new { id = expenditure.Id }, expenditure);
        }

        // DELETE: api/Expenditure/delete/5
        [HttpDelete("delete/{id}")]
        public ActionResult<Expenditure> DeleteExpenditure(int id)
        {
            var expenditure = _business.Delete(id);

            return new OkObjectResult(expenditure);
        }
    }
}
