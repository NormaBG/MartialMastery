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
    public class TiposusersController : ControllerBase
    {
        private readonly MartialMasterContext _context;

        public TiposusersController(MartialMasterContext context)
        {
            _context = context;
        }

        // GET: api/Tiposusers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tiposuser>>> GetTiposusers()
        {
          if (_context.Tiposusers == null)
          {
              return NotFound();
          }
            return await _context.Tiposusers.ToListAsync();
        }

        // GET: api/Tiposusers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tiposuser>> GetTiposuser(int id)
        {
          if (_context.Tiposusers == null)
          {
              return NotFound();
          }
            var tiposuser = await _context.Tiposusers.FindAsync(id);

            if (tiposuser == null)
            {
                return NotFound();
            }

            return tiposuser;
        }

        // PUT: api/Tiposusers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTiposuser(int id, Tiposuser tiposuser)
        {
            if (id != tiposuser.IdTp)
            {
                return BadRequest();
            }

            _context.Entry(tiposuser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiposuserExists(id))
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

        // POST: api/Tiposusers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tiposuser>> PostTiposuser(Tiposuser tiposuser)
        {
          if (_context.Tiposusers == null)
          {
              return Problem("Entity set 'MartialMasterContext.Tiposusers'  is null.");
          }
            _context.Tiposusers.Add(tiposuser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTiposuser", new { id = tiposuser.IdTp }, tiposuser);
        }

        // DELETE: api/Tiposusers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTiposuser(int id)
        {
            if (_context.Tiposusers == null)
            {
                return NotFound();
            }
            var tiposuser = await _context.Tiposusers.FindAsync(id);
            if (tiposuser == null)
            {
                return NotFound();
            }

            _context.Tiposusers.Remove(tiposuser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TiposuserExists(int id)
        {
            return (_context.Tiposusers?.Any(e => e.IdTp == id)).GetValueOrDefault();
        }
    }
}
