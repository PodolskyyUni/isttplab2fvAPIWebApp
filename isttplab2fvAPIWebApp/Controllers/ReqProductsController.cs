using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using isttplab2fvAPIWebApp.Models;

namespace isttplab2fvAPIWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReqProductsController : ControllerBase
    {
        private readonly isttplab2fvAPIWebAppContext _context;

        public ReqProductsController(isttplab2fvAPIWebAppContext context)
        {
            _context = context;
        }

        // GET: api/ReqProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReqProduct>>> GetReqProducts()
        {
            return await _context.ReqProducts.ToListAsync();
        }

        // GET: api/ReqProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReqProduct>> GetReqProduct(int id)
        {
            var reqProduct = await _context.ReqProducts.FindAsync(id);

            if (reqProduct == null)
            {
                return NotFound();
            }

            return reqProduct;
        }

        // PUT: api/ReqProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReqProduct(int id, ReqProduct reqProduct)
        {
            if (id != reqProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(reqProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReqProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ReqProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReqProduct>> PostReqProduct(ReqProduct reqProduct)
        {
            _context.ReqProducts.Add(reqProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReqProduct", new { id = reqProduct.Id }, reqProduct);
        }

        // DELETE: api/ReqProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReqProduct(int id)
        {
            var reqProduct = await _context.ReqProducts.FindAsync(id);
            if (reqProduct == null)
            {
                return NotFound();
            }

            _context.ReqProducts.Remove(reqProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReqProductExists(int id)
        {
            return _context.ReqProducts.Any(e => e.Id == id);
        }
    }
}
