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
    public class TiposdeusuariosController : ControllerBase
    {
        private readonly MartialMasterContext _context;

        public TiposdeusuariosController(MartialMasterContext context)
        {
            _context = context;
        }

        // GET: api/Tiposdeusuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tiposdeusuario>>> GetTiposdeusuarios()
        {
          if (_context.Tiposdeusuarios == null)
          {
              return NotFound();
          }
            return await _context.Tiposdeusuarios.ToListAsync();
        }

        // GET: api/Tiposdeusuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tiposdeusuario>> GetTiposdeusuario(int id)
        {
          if (_context.Tiposdeusuarios == null)
          {
              return NotFound();
          }
            var tiposdeusuario = await _context.Tiposdeusuarios.FindAsync(id);

            if (tiposdeusuario == null)
            {
                return NotFound();
            }

            return tiposdeusuario;
        }

        // PUT: api/Tiposdeusuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTiposdeusuario(int id, Tiposdeusuario tiposdeusuario)
        {
            if (id != tiposdeusuario.IdTp)
            {
                return BadRequest();
            }

            _context.Entry(tiposdeusuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiposdeusuarioExists(id))
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

        // POST: api/Tiposdeusuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tiposdeusuario>> PostTiposdeusuario(Tiposdeusuario tiposdeusuario)
        {
          if (_context.Tiposdeusuarios == null)
          {
              return Problem("Entity set 'MartialMasterContext.Tiposdeusuarios'  is null.");
          }
            _context.Tiposdeusuarios.Add(tiposdeusuario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TiposdeusuarioExists(tiposdeusuario.IdTp))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTiposdeusuario", new { id = tiposdeusuario.IdTp }, tiposdeusuario);
        }

        // DELETE: api/Tiposdeusuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTiposdeusuario(int id)
        {
            if (_context.Tiposdeusuarios == null)
            {
                return NotFound();
            }
            var tiposdeusuario = await _context.Tiposdeusuarios.FindAsync(id);
            if (tiposdeusuario == null)
            {
                return NotFound();
            }

            _context.Tiposdeusuarios.Remove(tiposdeusuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TiposdeusuarioExists(int id)
        {
            return (_context.Tiposdeusuarios?.Any(e => e.IdTp == id)).GetValueOrDefault();
        }
    }
}
