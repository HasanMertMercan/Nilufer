using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database;
using ValueTypes.Entity;
using SupplierService;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private ISupplierBusiness _business;

        public SupplierController(ISupplierBusiness business)
        {
            _business = business;
        }

        // GET: api/Supplier
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSupplier()
        {
            return await _business.GetAllSuppliers();
        }

        // GET: api/Supplier/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetSupplierById(int id)
        {
            var supplier = await _business.GetSupplierById(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return supplier;
        }

        // PUT: api/Supplier/edit/5
        [HttpPut("edit/{id}")]
        public ActionResult<IEnumerable<string>> EditSupplier(int id, Supplier supplier)
        {
            if (id != supplier.Id)
            {
                return BadRequest();
            }

            var newSupplier = _business.Update(supplier);
            return new OkObjectResult(newSupplier);
        }

        // POST: api/Supplier/add
        [HttpPost("add")]
        public async Task<ActionResult<Supplier>> AddSupplier(Supplier supplier)
        {
            await _business.Insert(supplier);

            return CreatedAtAction("GetSupplier", new { id = supplier.Id }, supplier);
        }

        // DELETE: api/Supplier/5
        [HttpDelete("delete/{id}")]
        public ActionResult<Supplier> DeleteSupplier(int id)
        {
            var supplier = _business.Delete(id);

            return new OkObjectResult(supplier);
        }
    }
}
