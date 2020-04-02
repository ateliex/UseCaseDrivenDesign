using Microsoft.AspNetCore.Mvc;

namespace Ateliex
{
    [Route("/")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var resource = new HomeResource();

            return Ok(resource);
        }

        [HttpGet("/cadastro")]
        public IActionResult GetCadastro()
        {
            var resource = new CadastroResource();

            return Ok(resource);
        }

        [HttpGet("/decisoes")]
        public IActionResult GetDecisoes()
        {
            var resource = new DecisoesResource();

            return Ok(resource);
        }
    }
}
