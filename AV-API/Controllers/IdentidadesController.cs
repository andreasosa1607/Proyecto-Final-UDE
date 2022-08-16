using System;
using Microsoft.AspNetCore.Mvc;
using AV.BO;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace AV_API.Controllers
{
    [Route("api_1_0/[controller]")]
    [ApiController]
    public class IdentidadesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<IdentidadesController> _logger;

        public IdentidadesController(IConfiguration configuration, ILogger<IdentidadesController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(Login login)
        {
            try
            {

                //Genera el token
                var token = GenerarToken(login);

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


            return new JwtSecurityToken
            (
                issuer: ValidIssuer,
                audience: ValidAudience,
                expires: dtFechaExpiraToken,
                notBefore: now,
                signingCredentials: new SigningCredentials(IssuerSigningKey, SecurityAlgorithms.HmacSha256)
            );
        }
    }
}