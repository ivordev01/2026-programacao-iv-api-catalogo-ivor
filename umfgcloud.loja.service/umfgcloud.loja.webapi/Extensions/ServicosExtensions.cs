using Microsoft.AspNetCore.Identity;
using umfgcloud.loja.aplicacao.service.Classes;
using umfgcloud.loja.dominio.service.Interfaces.Servicos;

namespace umfgcloud.loja.webapi.Extensions
{
    /// <summary>
    /// Define quais as implementações dpara as interfaces criadas ou importadas nasolução
    /// </summary>

    internal static class ServicosExtensions
    {
        internal static void AddServicos(this IServiceCollection services)
        {
            services.AddDefaultIdentity<IdentityUser>()
                    .AddRoles<IdentityRole>()
                    .AddDefaultTokenProviders();

            // AddScoped -> Cada requisição do Front-End cria um objeto na memória e ao final remove
            //AddSingleton -> Compartilha um unico objeto com toda a aplicação
            // AddTransient -> Cada requisição do Front-ENd cria um objeto na memóia e o mantem, precisa gerenciar para não estourar a capacidad do servidor

            services.AddScoped<IUsuarioServico, UsuarioServico>();
        }
    }
}
