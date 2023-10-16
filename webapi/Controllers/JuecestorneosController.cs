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
    public class JuecestorneosController : ControllerBase
    {
        private readonly MartialMasterContext _context;

        public JuecestorneosController(MartialMasterContext context)
        {
            _context = context;
        }

        // GET: api/Juecestorneos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Juecestorneo>>> GetJuecestorneos()
        {
          if (_context.Juecestorneos == null)
          {
              return NotFound();
          }
            return await _context.Juecestorneos.ToListAsync();
        }

        // GET: api/Juecestorneos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Juecestorneo>> GetJuecestorneo(int id)
        {
          if (_context.Juecestorneos == null)
          {
              return NotFound();
          }
            var juecestorneo = await _context.Juecestorneos.FindAsync(id);

            if (juecestorneo == null)
            {
                return NotFound();
            }

            return juecestorneo;
        }

        // PUT: api/Juecestorneos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJuecestorneo(int id, Juecestorneo juecestorneo)
        {
            if (id != juecestorneo.IdAsignacion)
            {
                return BadRequest();
            }

            _context.Entry(juecestorneo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JuecestorneoExists(id))
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

        // POST: api/Juecestorneos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Juecestorneo>> PostJuecestorneo(Juecestorneo juecestorneo)
        {
          if (_context.Juecestorneos == null)
          {
              return Problem("Entity set 'MartialMasterContext.Juecestorneos'  is null.");
          }
            _context.Juecestorneos.Add(juecestorneo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JuecestorneoExists(juecestorneo.IdAsignacion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetJuecestorneo", new { id = juecestorneo.IdAsignacion }, juecestorneo);
        }

        // DELETE: api/Juecestorneos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJuecestorneo(int id)
        {
            if (_context.Juecestorneos == null)
            {
                return NotFound();
            }
            var juecestorneo = await _context.Juecestorneos.FindAsync(id);
            if (juecestorneo == null)
            {
                return NotFound();
            }

            _context.Juecestorneos.Remove(juecestorneo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JuecestorneoExists(int id)
        {
            return (_context.Juecestorneos?.Any(e => e.IdAsignacion == id)).GetValueOrDefault();
        }
    }
}
