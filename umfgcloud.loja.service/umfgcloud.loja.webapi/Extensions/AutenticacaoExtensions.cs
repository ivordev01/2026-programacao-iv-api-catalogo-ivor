using Microsoft.IdentityModel.Tokens;
using System.Text;
using umfgcloud.loja.dominio.service.Classes;

namespace umfgcloud.loja.webapi.Extensions
{
    internal static class AutenticacaoExtensions
    {
        internal static void AddAutenticacao(this IServiceCollection services,
            IConfiguration configuration)
        {
            var confirurationSectionJwtOptions =
                configuration.GetSection(nameof(JwtOptions)).GetChildren();

            var issuer = confirurationSectionJwtOptions
                .FirstOrDefault(x => x.Key == nameof(JwtOptions.Issuer))?.Value ?? string.Empty;
            var audiance = confirurationSectionJwtOptions
                .FirstOrDefault(x => x.Key == nameof(JwtOptions.Audiance))?.Value ?? string.Empty;
            var securityKey = confirurationSectionJwtOptions
                .FirstOrDefault(x => x.Key == nameof(JwtOptions.SecurityKey))?.Value ?? string.Empty;

            //ASCII: a letra K = 107
            var symmetricSecurityKey = 
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(securityKey));

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidIssuer = issuer,

                ValidateAudience = false,
                ValidAudience = audiance,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = symmetricSecurityKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero,
            };


            services.Configure<JwtOptions>(options =>
            {
                options.Issuer = issuer;
                options.Audiance = audiance;
                options.AcessTokenExpiration = int.Parse(
                    confirurationSectionJwtOptions
                    .FirstOrDefault(x => x.Key == nameof(JwtOptions.AcessTokenExpiration))?.Value ?? string.Empty);
                options.RefreshTokenExpiration = int.Parse(
                    confirurationSectionJwtOptions
                    .FirstOrDefault(x => x.Key == nameof(JwtOptions.RefreshTokenExpiration))?.Value ?? string.Empty);
                options.SigningCredentials =
                    new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
            });
        }
    }
}