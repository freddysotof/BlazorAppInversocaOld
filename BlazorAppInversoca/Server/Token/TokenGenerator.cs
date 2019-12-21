using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using BlazorAppInversoca.Shared.Token___Result_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorAppInversoca.Server.Token
{
    internal static class TokenGenerator
    {
        private static string SecretKey;
        public static string GenerateTokenJwt(string username)
        {
            // Modelo de Token
            TokenViewModel model = new TokenViewModel();

            // Llave Secreta ('Llave secreta Api')
            SecretKey = model.SecretKey;
            //  Quien accede al Api
            var AudienceToken = model.AudienceToken;
            // Quien crea el Token
            var IssuerToken = model.IssuerToken;
            // Duracion de Token
            var ExpireTime = model.ExpireTime;

            var SecurityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(SecretKey));

            // Credenciales de Acceso
            var SigningCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256Signature);

            // Creacion de un claimsIdentity (por que nombre se validara)
            ClaimsIdentity ClaimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) });

            // Manejador de Token
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            // Crear Token
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                    audience: AudienceToken,
                    issuer: IssuerToken,
                    subject: ClaimsIdentity,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddHours(Convert.ToInt32(ExpireTime)),
                    signingCredentials: SigningCredentials);
            IdentityModelEventSource.ShowPII = true;
            // Escribir Token
            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }
    }
}
