using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using webapi.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly MartialMasterContext _context;

        public class ApplicationUser : IdentityUser
        {
            // Propiedades adicionales si las necesitas
        }

        public UsuariosController(MartialMasterContext context, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
          if (_context.Usuarios == null)
          {
              return NotFound();
          }

            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
          if (_context.Usuarios == null)
          {
              return NotFound();
          }
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.IdUser)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost()]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {           
            if (_context.Usuarios == null)
            {
              return Problem("Entity set 'MartialMasterContext.Usuarios'  is null.");
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.IdUser }, usuario);
        
        }

        private string GenerateJwtToken(Usuario usuario)
        {
            // Lógica para generar el token JWT
            // Clave secreta utilizada para firmar el token (debes guardarla de manera segura)
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TuClaveSecretaSuperSegura"));

            // Credenciales para firmar el token
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // Definir las claims (datos del usuario) que se incluirán en el token
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Usuario1),  // Nombre de usuario
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())  // Identificador único
            };

            // Configuración del token
            var token = new JwtSecurityToken(
                issuer: "TuIssuer",     // Quién emite el token
                audience: "TuAudience", // Quién puede consumir el token
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),  // Duración del token (1 hora en este ejemplo)
                signingCredentials: credentials
            );

            // Generar el token como una cadena
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }

        private readonly UserManager<Usuario> _userManager;

        [HttpPost("login")]
        public async Task<ActionResult<Usuario>> Login(UserLoginModel model)
        {
            //verificar credenciales
            var user = await _userManager.FindByNameAsync(model.username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.password))
            {
                //generar y devolver token
                var token = GenerateJwtToken(user);
                return Ok(new { token });
            }

            return BadRequest("Credenciales Incorrectas");

        }

        public class UserLoginModel
        {
            public string username { get; set; }
            public string password { get; set; }

            public UserLoginModel(string username, string password)
            {
                this.username = username;
                this.password = password;
            }
        }


        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {

            var usuario = await _context.Usuarios.FindAsync(id);
            
            if (_context.Usuarios == null)
            {
                return NotFound();
            }

            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return (_context.Usuarios?.Any(e => e.IdUser == id)).GetValueOrDefault();
        }

    }
}
