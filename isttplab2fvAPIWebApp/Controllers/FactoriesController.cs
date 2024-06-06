﻿using System;
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
    public class FactoriesController : ControllerBase
    {
        private readonly isttplab2fvAPIWebAppContext _context;

        public FactoriesController(isttplab2fvAPIWebAppContext context)
        {
            _context = context;
        }

        // GET: api/Factories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factory>>> GetFactories()
        {
            return await _context.Factories.ToListAsync();
        }

        // GET: api/Factories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Factory>> GetFactory(int id)
        {
            var factory = await _context.Factories.FindAsync(id);

            if (factory == null)
            {
                return NotFound();
            }

            return factory;
        }

        // PUT: api/Factories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactory(int id, Factory factory)
        {
            if (id != factory.Id)
            {
                return BadRequest();
            }

            _context.Entry(factory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactoryExists(id))
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

        // POST: api/Factories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Factory>> PostFactory(Factory factory)
        {
            _context.Factories.Add(factory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFactory", new { id = factory.Id }, factory);
        }

        // DELETE: api/Factories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactory(int id)
        {
            var factory = await _context.Factories.FindAsync(id);
            if (factory == null)
            {
                return NotFound();
            }

            _context.Factories.Remove(factory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FactoryExists(int id)
        {
            return _context.Factories.Any(e => e.Id == id);
        }
    }
}
