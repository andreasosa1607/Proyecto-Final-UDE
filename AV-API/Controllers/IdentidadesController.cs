using System;
using Microsoft.AspNetCore.Mvc;
using AV.BO;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Threading.Tasks;
using AV.DA;
using AV_DTO;


namespace AV_API.Controllers
{
    [Route("api_1_0/[controller]")]
    [ApiController]
    public class IdentidadesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<IdentidadesController> _logger;

        private readonly AVDBContext _context;

        //public IdentidadesController(AVDBContext context)
        //{
        //    _context = context;
        //}

        public IdentidadesController(IConfiguration configuration, ILogger<IdentidadesController> logger, AVDBContext context)
        {
            _configuration = configuration;
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LoginDTO>> Login(LoginDTO login)

        {
            var loginExiste = await _context.Logins.FindAsync(login.CorreoElectronico);

            if (loginExiste == null)
            {
                return NotFound();
            }

            try
            {
                //Verifica el usuario y contraseña
                if ( login.CorreoElectronico != loginExiste.CorreoElectronico || login.Contraseña != loginExiste.Contraseña)
                {
                    return BadRequest("Correo Electronico/Contraseña incorrectos");
                }

                //Genera el token
                var token = GenerarToken(loginExiste);

                return Ok(new
                {
                    respuesta = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception e)
            {
                _logger.LogError("Login: " + e.Message, e);
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, e.Message);
            }
        }

        private JwtSecurityToken GenerarToken(Login login)
        {
            string ValidIssuer = _configuration["ApiAuth:Issuer"];
            string ValidAudience = _configuration["ApiAuth:Audience"];
           SymmetricSecurityKey IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["ApiAuth:SecretKey"]));

            //La fecha de expiracion sera el mismo dia a las 12 de la noche
            DateTime dtFechaExpiraToken;
            DateTime now = DateTime.Now;
            dtFechaExpiraToken = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59, 999);



            var claims = new Claim[]
            {
                new Claim("correoElectronico", login.CorreoElectronico),
                new Claim("rol", login.Rol),
                new Claim(JwtRegisteredClaimNames.Iat, (now).ToString(), ClaimValueTypes.Integer64)
            };




            return new JwtSecurityToken
            (
                claims: claims,
                issuer: ValidIssuer,
                audience: ValidAudience,
                expires: dtFechaExpiraToken,
                notBefore: now,
                signingCredentials: new SigningCredentials(IssuerSigningKey, SecurityAlgorithms.HmacSha256)


            );
        }
    }
}