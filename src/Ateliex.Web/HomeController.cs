using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace Ateliex
{
    [ApiController]
    [Route("/api")]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// Sumário
        /// </summary>
        /// <returns>Retorno</returns>
        [HttpGet(Name = "Home")]
        public ActionResult<Resource> Index()
        {
            var resource = new Resource
            {
                Title = "Home",
                HRef = "/api",
                Links = new Link[]
                {
                    new Link {Rel = "cadastro", HRef = "/api/cadastro", Text = "Cadastro"},
                    new Link {Rel = "decisoes", HRef = "/api/decisoes", Text = "Decisões"}
                }
            };

            return resource;
        }

        [HttpGet("cadastro")]
        public ActionResult<Resource> GetCadastro()
        {
            var resource = new Resource
            {
                Title = "Cadastro",
                HRef = "/api/cadastro",
                Links = new Link[]
                {
                    new Link {Rel = "modelos", HRef = "/api/cadastro/modelos", Text = "Modelos"}
                }
            };

            return resource;
        }

        [HttpGet("decisoes")]
        public ActionResult<Resource> GetDecisoes()
        {
            var resource = new Resource
            {
                Title = "Decisões",
                HRef = "/api/decisoes",
                Links = new Link[]
                {
                    new Link {Rel = "comerciais", HRef = "/api/decisoes/comerciais", Text = "Comerciais"}
                }
            };

            return resource;
        }
    }
}
