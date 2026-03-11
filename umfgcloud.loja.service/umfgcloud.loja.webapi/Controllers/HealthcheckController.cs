using Microsoft.AspNetCore.Mvc;

namespace umfgcloud.loja.webapi.Controllers
{
    /// <summary>
    /// Endpoint(s) de verificaçao de saúde da API
    /// </summary>

    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    [Route("[controller]")] // Toda classe controller deve possuir o sufixo controller

    public sealed class HealthcheckController : ControllerBase
    {
        /// <summary>
        /// Verifica o estado de saúde da API
        /// </summary>
        /// <returns></returns>

        [HttpGet]

        public IActionResult Ping()
        {
            return Ok($"umfgcloud.loja.service -> online | {DateTime.Now}");
        }

        // Exemplo como usando o Route de atributo na classe assume automaticamente a rota na uri implementando o protocolo http

        //[HttpPost]

        //public IActionResult Post()
        //{
        //    return Ok("Teste Post");
        //}
    }
}
