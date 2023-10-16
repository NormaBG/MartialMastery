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
    public class ParticipacionsController : ControllerBase
    {
        private readonly MartialMasterContext _context;

        public ParticipacionsController(MartialMasterContext context)
        {
            _context = context;
        }

        // GET: api/Participacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participacion>>> GetParticipacions()
        {
          if (_context.Participacions == null)
          {
              return NotFound();
          }
            return await _context.Participacions.ToListAsync();
        }

        // GET: api/Participacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Participacion>> GetParticipacion(int id)
        {
          if (_context.Participacions == null)
          {
              return NotFound();
          }
            var participacion = await _context.Participacions.FindAsync(id);

            if (participacion == null)
            {
                return NotFound();
            }

            return participacion;
        }

        // PUT: api/Participacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipacion(int id, Participacion participacion)
        {
            if (id != participacion.IdParticipacion)
            {
                return BadRequest();
            }

            _context.Entry(participacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipacionExists(id))
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

        // POST: api/Participacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Participacion>> PostParticipacion(Participacion participacion)
        {
          if (_context.Participacions == null)
          {
              return Problem("Entity set 'MartialMasterContext.Participacions'  is null.");
          }
            _context.Participacions.Add(participacion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ParticipacionExists(participacion.IdParticipacion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetParticipacion", new { id = participacion.IdParticipacion }, participacion);
        }

        // DELETE: api/Participacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipacion(int id)
        {
            if (_context.Participacions == null)
            {
                return NotFound();
            }
            var participacion = await _context.Participacions.FindAsync(id);
            if (participacion == null)
            {
                return NotFound();
            }

            _context.Participacions.Remove(participacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParticipacionExists(int id)
        {
            return (_context.Participacions?.Any(e => e.IdParticipacion == id)).GetValueOrDefault();
        }
    }
}
