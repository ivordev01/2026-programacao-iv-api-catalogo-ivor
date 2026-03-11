using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using umfgcloud.loja.aplicacao.service.Classes;
using umfgcloud.loja.dominio.service.DTO;
using umfgcloud.loja.dominio.service.Interfaces.Servicos;

namespace umfgcloud.loja.webapi.Controllers
{
    /// <summary>
    /// Endpoint(s) de verificaçao de saúde da API
    /// </summary>

    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    [Route("[controller]")] // Toda classe controller deve possuir o sufixo controller

    public class SignupController : ControllerBase
    {
        // A palavra readonly permite que a variável tenha seu valor manipulado apenas em sua definição ou dentro do método construtor

        private readonly IUsuarioServico _servico;

        public SignupController(IUsuarioServico servico)
        {
            _servico = servico ?? throw new ArgumentNullException(nameof(servico));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>

        public async Task<IActionResult> SignupAsync (UsuarioDTO.SingInRequest dto)
        {
            try
            {
                await _servico.CadastrarAsync(dto);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
    }
}
