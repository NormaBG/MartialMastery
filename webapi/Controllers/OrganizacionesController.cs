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
    public class OrganizacionesController : ControllerBase
    {
        private readonly MartialMasterContext _context;

        public OrganizacionesController(MartialMasterContext context)
        {
            _context = context;
        }

        // GET: api/Organizaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organizacione>>> GetOrganizaciones()
        {
          if (_context.Organizaciones == null)
          {
              return NotFound();
          }
            return await _context.Organizaciones.ToListAsync();
        }

        // GET: api/Organizaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Organizacione>> GetOrganizacione(int id)
        {
          if (_context.Organizaciones == null)
          {
              return NotFound();
          }
            var organizacione = await _context.Organizaciones.FindAsync(id);

            if (organizacione == null)
            {
                return NotFound();
            }

            return organizacione;
        }

        // PUT: api/Organizaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganizacione(int id, Organizacione organizacione)
        {
            if (id != organizacione.IdOrg)
            {
                return BadRequest();
            }

            _context.Entry(organizacione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizacioneExists(id))
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

        // POST: api/Organizaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Organizacione>> PostOrganizacione(Organizacione organizacione)
        {
          if (_context.Organizaciones == null)
          {
              return Problem("Entity set 'MartialMasterContext.Organizaciones'  is null.");
          }
            _context.Organizaciones.Add(organizacione);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrganizacione", new { id = organizacione.IdOrg }, organizacione);
        }

        // DELETE: api/Organizaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizacione(int id)
        {
            if (_context.Organizaciones == null)
            {
                return NotFound();
            }
            var organizacione = await _context.Organizaciones.FindAsync(id);
            if (organizacione == null)
            {
                return NotFound();
            }

            _context.Organizaciones.Remove(organizacione);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrganizacioneExists(int id)
        {
            return (_context.Organizaciones?.Any(e => e.IdOrg == id)).GetValueOrDefault();
        }
    }
}
