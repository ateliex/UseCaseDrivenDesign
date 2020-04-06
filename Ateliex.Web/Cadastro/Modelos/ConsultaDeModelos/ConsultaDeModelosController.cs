using Microsoft.AspNetCore.Mvc;

namespace Ateliex.Cadastro.Modelos.ConsultaDeModelos
{
    [Route("/cadastro/modelos/consulta-de-modelos")]
    public class ConsultaDeModelosController : Controller
    {
        private readonly IConsultaDeModelos consultaDeModelos;

        public ConsultaDeModelosController(IConsultaDeModelos consultaDeModelos)
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
            var resource = new ModelosResource();

            return Ok(resource);
        }

        [HttpGet("/cadastro-de-modelos")]
        public IActionResult GetCadastroDeModelos()
        {
            var resource = new ModelosResource();

            return Ok(resource);
        }
    }
}
