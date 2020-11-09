using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Nyous_API.Contexts;
using Nyous_API.Domains;

namespace Nyous_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //Chama nosso contexto do banco
        NyousContext _context = new NyousContext();

        //Capturar as inf do token do appsettings.json
        //Define uma variável para percorrer os métodos com as configurações obtidas no appsettings.json
        private IConfiguration _config;

        //Define um método construtor para poder passar essas configs
        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        private Usuario AuthenticateUser(Usuario login)
        {
            return _context.Usuario
                .Include(a => a.IdAcessoNavigation)
                .FirstOrDefault(u => u.Email == login.Email && u.Senha == login.Senha);
        }

        //Cria nosso método que vai gerar o Token
        private string GenerateJSONWebToken(Usuario userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            //Cria a credencial com a security key criada, passando o alg
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Definimos nossas Claims (dados da sessão) para poderem ser capturadas a qualquer momento enquanto o Token for ativo
            var claims = new[] {
                //NameId, Email e Jti -> são padrões
                new Claim(JwtRegisteredClaimNames.NameId, userInfo.Nome),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                //Pega info de acesso por escrito, ex: Padrao ou Administrador
                new Claim(ClaimTypes.Role, userInfo.IdAcessoNavigation.Tipo)
            };

            //Configura nosso Token e seu tempo de vida
            var token = new JwtSecurityToken
            (
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
             );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //Usamos a anotação "AllowAnonymous" para ignorar a autenticação neste método, já que é ele quem fará isso
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] Usuario login)
        {
            //Definimos logo de cara como Unauthorized (não autorizado)
            IActionResult response = Unauthorized();

            //Autentica o usuário da API
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }
    }
}
