using ClassificaApi.Model;
using Microsoft.IdentityModel.Tokens;
using System.Drawing.Imaging;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClassificaApi.Services
{
    public static class TokenService
    {
        public static string GenerateToken(Usuarios usuarios)
        {
            var tokenManipulador = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(Settings.Secrect);

            var tokenDescricao = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, usuarios.NomeUsuario),
                    new Claim(ClaimTypes.Role, usuarios.Role),
                    new Claim("Teste", "Testando")
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials( new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenManipulador.CreateToken(tokenDescricao);

            return tokenManipulador.WriteToken(token);
        }
    }
}
