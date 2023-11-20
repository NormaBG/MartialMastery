using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using System.Text;


namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly string secretKey; 
        
        public AuthenticationController(IConfiguration config)
        {
            secretKey = config.GetSection("settings").GetSection("secretkey").ToString();
        }

        [HttpPost]
        [Route("Validar")]
        public async Task<IActionResult> Validar([FromBody] Usuario request)
        {
            using(var contextobd = new MartialMasterContext())
            {
                var usuarioEncontrado = await contextobd.Usuarios.FirstOrDefaultAsync(u => u.Usuario1 == request.Usuario1);
                var contraencontrada = await contextobd.Usuarios.FirstOrDefaultAsync(u => u.Contrasena == request.Contrasena);
                
                if (usuarioEncontrado != null && contraencontrada != null)
                {
                    var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                    var claims = new ClaimsIdentity();
                    claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.Usuario1));

                    //creartoken

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        //propiedades del token
                        Subject = claims,
                        Expires = DateTime.UtcNow.AddMinutes(5),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes),SecurityAlgorithms.HmacSha256Signature)
                    };

                    //lectura del token

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                    string tokencreador = tokenHandler.WriteToken(tokenConfig);

                    return StatusCode(StatusCodes.Status200OK, new { token = tokencreador});
                }
                else
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
                }
            }
        }
    }
}