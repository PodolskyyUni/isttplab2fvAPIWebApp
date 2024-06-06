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
    public class FactoryProductsController : ControllerBase
    {
        private readonly isttplab2fvAPIWebAppContext _context;

        public FactoryProductsController(isttplab2fvAPIWebAppContext context)
        {
            _context = context;
        }

        // GET: api/FactoryProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FactoryProduct>>> GetFactoryProducts()
        {
            return await _context.FactoryProducts.ToListAsync();
        }

        // GET: api/FactoryProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FactoryProduct>> GetFactoryProduct(int id)
        {
            var factoryProduct = await _context.FactoryProducts.FindAsync(id);

            if (factoryProduct == null)
            {
                return NotFound();
            }

            return factoryProduct;
        }

        // PUT: api/FactoryProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactoryProduct(int id, FactoryProduct factoryProduct)
        {
            if (id != factoryProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(factoryProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactoryProductExists(id))
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

        // POST: api/FactoryProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FactoryProduct>> PostFactoryProduct(FactoryProduct factoryProduct)
        {
            _context.FactoryProducts.Add(factoryProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFactoryProduct", new { id = factoryProduct.Id }, factoryProduct);
        }

        // DELETE: api/FactoryProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactoryProduct(int id)
        {
            var factoryProduct = await _context.FactoryProducts.FindAsync(id);
            if (factoryProduct == null)
            {
                return NotFound();
            }

            _context.FactoryProducts.Remove(factoryProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FactoryProductExists(int id)
        {
            return _context.FactoryProducts.Any(e => e.Id == id);
        }
    }
}
