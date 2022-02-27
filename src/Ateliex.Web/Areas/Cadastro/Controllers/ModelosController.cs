using Ateliex.Areas.Cadastro.Models;
using Ateliex.Modules.Cadastro.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Web;

namespace Ateliex.Areas.Cadastro.Controllers
{
    [Area("Cadastro")]
    //[Route("/cadastro/modelos")]
    public class ModelosController : Controller
    {
        private readonly IConsultaDeModelos consultaDeModelos;

        private readonly ICadastroDeModelos cadastroDeModelos;

        public ModelosController(IConsultaDeModelos consultaDeModelos, ICadastroDeModelos cadastroDeModelos)
        {
            this.consultaDeModelos = consultaDeModelos;

            this.cadastroDeModelos = cadastroDeModelos;
        }

        public IActionResult Index(SolicitacaoDeConsultaDeModelos solicitacao)
        {
            var modelos = consultaDeModelos.ConsultaModelos(solicitacao);

            var data = modelos
                .Select(modelo => new Resource<ModeloResource>
                {
                    Title = $"Modelo #{modelo.Codigo}",
                    HRef = $"/cadastro/modelos/{modelo.Codigo}",
                    Data = new ModeloResource
                    {
                        Id = modelo.Codigo,
                        Nome = modelo.Nome,
                        CustoDeProducao = modelo.CustoDeProducao
                    },
                    Links = new Link[]
                    {
                        new Link {Rel = "detalhes-de-modelo", HRef = $"/cadastro/modelos/{modelo.Codigo}", Text = "Detalhar"},
                        new Link {Rel = "alteracao-de-modelos", HRef = $"/cadastro/modelos/{modelo.Codigo}/alteracao-de-modelos", Text = "Alterar"},
                        new Link {Rel = "exclusao-de-modelos", HRef = $"/cadastro/modelos/{modelo.Codigo}/exclusao-de-modelos", Text = "Excluir"}
                    }
                })
                .ToArray();

            var resource = new ResourceCollection<ModeloResource>
            {
                Title = "Modelos",
                HRef = "/cadastro/modelos",
                Data = data,
                Links = new Link[]
                {
                    new Link {Rel = "consulta-de-modelos", HRef = "/cadastro/modelos/consulta-de-modelos", Text = "Consulta de Modelos"},
                    new Link {Rel = "cadastro-de-modelos", HRef = "/cadastro/modelos/cadastro-de-modelos", Text = "Cadastro de Modelos"}
                }
            };

            return View(resource);
        }
    }
}
