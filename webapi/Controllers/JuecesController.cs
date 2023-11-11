using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JuecesController : ControllerBase
    {
        private readonly MartialMasterContext _context;

        public JuecesController(MartialMasterContext context)
        {
            _context = context;
        }

        // GET: api/Jueces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Juece>>> GetJueces()
        {
          if (_context.Jueces == null)
          {
              return NotFound();
          }
            return await _context.Jueces.ToListAsync();
        }

        // GET: api/Jueces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Juece>> GetJuece(int id)
        {
          if (_context.Jueces == null)
          {
              return NotFound();
          }
            var juece = await _context.Jueces.FindAsync(id);

            if (juece == null)
            {
                return NotFound();
            }

            return juece;
        }

        // PUT: api/Jueces/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJuece(int id, Juece juece)
        {
            if (id != juece.IdJuez)
            {
                return BadRequest();
            }

            _context.Entry(juece).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JueceExists(id))
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

        // POST: api/Jueces
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Juece>> PostJuece(Juece juece)
        {
          if (_context.Jueces == null)
          {
              return Problem("Entity set 'MartialMasterContext.Jueces'  is null.");
          }
            _context.Jueces.Add(juece);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JueceExists(juece.IdJuez))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetJuece", new { id = juece.IdJuez }, juece);
        }

        // DELETE: api/Jueces/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJuece(int id)
        {
            if (_context.Jueces == null)
            {
                return NotFound();
            }
            var juece = await _context.Jueces.FindAsync(id);
            if (juece == null)
            {
                return NotFound();
            }

            _context.Jueces.Remove(juece);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JueceExists(int id)
        {
            return (_context.Jueces?.Any(e => e.IdJuez == id)).GetValueOrDefault();
        }
    }
}
