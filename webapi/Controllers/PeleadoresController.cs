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
    public class PeleadoresController : ControllerBase
    {
        private readonly MartialMasterContext _context;

        public PeleadoresController(MartialMasterContext context)
        {
            _context = context;
        }

        // GET: api/Peleadores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Peleadore>>> GetPeleadores()
        {
          if (_context.Peleadores == null)
          {
              return NotFound();
          }
            return await _context.Peleadores.ToListAsync();
        }

        // GET: api/Peleadores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Peleadore>> GetPeleadore(int id)
        {
          if (_context.Peleadores == null)
          {
              return NotFound();
          }
            var peleadore = await _context.Peleadores.FindAsync(id);

            if (peleadore == null)
            {
                return NotFound();
            }

            return peleadore;
        }

        // PUT: api/Peleadores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPeleadore(int id, Peleadore peleadore)
        {
            if (id != peleadore.IdPeleador)
            {
                return BadRequest();
            }

            _context.Entry(peleadore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeleadoreExists(id))
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

        // POST: api/Peleadores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Peleadore>> PostPeleadore(Peleadore peleadore)
        {
          if (_context.Peleadores == null)
          {
              return Problem("Entity set 'MartialMasterContext.Peleadores'  is null.");
          }

            //atriburos null

            _context.Peleadores.Add(peleadore);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PeleadoreExists(peleadore.IdPeleador))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPeleadore", new { id = peleadore.IdPeleador }, peleadore);
        }

        // DELETE: api/Peleadores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeleadore(int id)
        {
            if (_context.Peleadores == null)
            {
                return NotFound();
            }
            var peleadore = await _context.Peleadores.FindAsync(id);
            if (peleadore == null)
            {
                return NotFound();
            }

            _context.Peleadores.Remove(peleadore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PeleadoreExists(int id)
        {
            return (_context.Peleadores?.Any(e => e.IdPeleador == id)).GetValueOrDefault();
        }
    }
}
