using Ateliex.Cadastro.Modelos.ConsultaDeModelos;
using Microsoft.AspNetCore.Mvc;

namespace Ateliex.Cadastro.Modelos
{
    [Route("/cadastro/modelos")]
    public class ModelosController : Controller
    {
        private readonly IConsultaDeModelos consultaDeModelos;

        public ModelosController(IConsultaDeModelos consultaDeModelos)
        {
            this.consultaDeModelos = consultaDeModelos;
        }

        public IActionResult Index()
        {
            var resource = new ModelosResource();

            return Ok(resource);
        }

        [HttpGet("/consulta-de-modelos")]
        public IActionResult GetConsultaDeModelos()
        {
            var parametros = new ParametrosDeConsultaDeModelos
            {

            };

            return Ok(parametros);
        }

        [HttpPost("/consulta-de-modelos")]
        public IActionResult PostConsultaDeModelos(ParametrosDeConsultaDeModelos parametros)
        {
            var resposta = consultaDeModelos.ConsultaModelos(parametros);



            return Ok(resposta);
        }

        [HttpGet("/cadastro-de-modelos")]
        public IActionResult GetCadastroDeModelos()
        {
            var resource = new ModelosResource();

            return Ok(resource);
        }
    }
}
