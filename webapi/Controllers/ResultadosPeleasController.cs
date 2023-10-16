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
    public class ResultadosPeleasController : ControllerBase
    {
        private readonly MartialMasterContext _context;

        public ResultadosPeleasController(MartialMasterContext context)
        {
            _context = context;
        }

        // GET: api/ResultadosPeleas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResultadosPelea>>> GetResultadosPeleas()
        {
          if (_context.ResultadosPeleas == null)
          {
              return NotFound();
          }
            return await _context.ResultadosPeleas.ToListAsync();
        }

        // GET: api/ResultadosPeleas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResultadosPelea>> GetResultadosPelea(int id)
        {
          if (_context.ResultadosPeleas == null)
          {
              return NotFound();
          }
            var resultadosPelea = await _context.ResultadosPeleas.FindAsync(id);

            if (resultadosPelea == null)
            {
                return NotFound();
            }

            return resultadosPelea;
        }

        // PUT: api/ResultadosPeleas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResultadosPelea(int id, ResultadosPelea resultadosPelea)
        {
            if (id != resultadosPelea.IdResultado)
            {
                return BadRequest();
            }

            _context.Entry(resultadosPelea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResultadosPeleaExists(id))
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

        // POST: api/ResultadosPeleas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResultadosPelea>> PostResultadosPelea(ResultadosPelea resultadosPelea)
        {
          if (_context.ResultadosPeleas == null)
          {
              return Problem("Entity set 'MartialMasterContext.ResultadosPeleas'  is null.");
          }
            _context.ResultadosPeleas.Add(resultadosPelea);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ResultadosPeleaExists(resultadosPelea.IdResultado))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetResultadosPelea", new { id = resultadosPelea.IdResultado }, resultadosPelea);
        }

        // DELETE: api/ResultadosPeleas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResultadosPelea(int id)
        {
            if (_context.ResultadosPeleas == null)
            {
                return NotFound();
            }
            var resultadosPelea = await _context.ResultadosPeleas.FindAsync(id);
            if (resultadosPelea == null)
            {
                return NotFound();
            }

            _context.ResultadosPeleas.Remove(resultadosPelea);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResultadosPeleaExists(int id)
        {
            return (_context.ResultadosPeleas?.Any(e => e.IdResultado == id)).GetValueOrDefault();
        }
    }
}
