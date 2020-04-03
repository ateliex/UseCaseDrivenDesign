using Ateliex.Cadastro.Modelos.CadastroDeModelos;
using Ateliex.Cadastro.Modelos.ConsultaDeModelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Web;

namespace Ateliex.Cadastro.Modelos
{
    [Route("/cadastro/modelos")]
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
                .Select(modelo => new Resource<Modelo>
                {
                    Title = $"Modelo #{modelo.Codigo}",
                    HRef = $"/cadastro/modelos/{modelo.Codigo}",
                    Data = modelo,
                    Links = new Link[]
                    {
                        new Link {Rel = "visualizacao-de-modelo", HRef = $"/cadastro/modelos/{modelo.Codigo}", Text = "Visualizar"},
                        new Link {Rel = "alteracao-de-modelos", HRef = $"/cadastro/modelos/{modelo.Codigo}/alteracao-de-modelos", Text = "Alterar"},
                        new Link {Rel = "exclusao-de-modelo", HRef = $"/cadastro/modelos/{modelo.Codigo}/exclusao-de-modelos", Text = "Excluir"}
                    }
                })
                .ToArray();

            var resource = new ResourceCollection<Modelo>
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

            return Ok(resource);
        }

        [HttpGet("consulta-de-modelos")]
        public IActionResult GetConsultaDeModelos()
        {
            var solicitacao = new SolicitacaoDeConsultaDeModelos
            {
                Nome = null,
                PrimeiraPagina = 1,
                TamanhoDaPagina = 10
            };

            var resource = new ResourceForm<SolicitacaoDeConsultaDeModelos>
            {
                Title = "Consulta de Modelos",
                HRef = "/cadastro/modelos/consulta-de-modelos",
                Data = solicitacao,
                Method = "GET",
                Action = "/cadastro/modelos",
                Links = new Link[] { }
            };

            return Ok(resource);
        }

        [HttpGet("{id}")]
        public IActionResult GetModelo(string id)
        {
            var codigo = new CodigoDeModelo(id);

            var modelo = consultaDeModelos.ObtemModelo(codigo);

            var resource = new Resource<Modelo>
            {
                Title = $"Modelo #{modelo.Codigo}",
                HRef = $"/cadastro/modelos/{modelo.Codigo}",
                Data = modelo,
                Links = new Link[]
                {
                    new Link {Rel = "visualizacao-de-modelo", HRef = $"/cadastro/modelos/{modelo.Codigo}", Text = "Visualizar"},
                    new Link {Rel = "alteracao-de-modelos", HRef = $"/cadastro/modelos/{modelo.Codigo}/alteracao-de-modelos", Text = "Alterar"},
                    new Link {Rel = "exclusao-de-modelo", HRef = $"/cadastro/modelos/{modelo.Codigo}/exclusao-de-modelos", Text = "Excluir"}
                }
            };

            return Ok(resource);
        }

        [HttpGet("cadastro-de-modelos")]
        public IActionResult GetCadastroDeModelos()
        {
            var solicitacao = new SolicitacaoDeCadastroDeModelo
            {
                Codigo = Guid.NewGuid().ToString(),
                Nome = "Modelo #"
            };

            var resource = new ResourceForm<SolicitacaoDeCadastroDeModelo>
            {
                Title = "Consulta de Modelos",
                HRef = "/cadastro/modelos/cadastro-de-modelos",
                Data = solicitacao,
                Method = "POST",
                Action = "/cadastro/modelos/cadastro-de-modelos",
                Links = new Link[] { }
            };

            return Ok(resource);
        }

        [HttpPost("cadastro-de-modelos")]
        public IActionResult PostCadastroDeModelos(SolicitacaoDeCadastroDeModelo solicitacao)
        {
            var modelo = cadastroDeModelos.CadastraModelo(solicitacao);

            var resource = new Resource<Modelo>
            {
                Title = $"Modelo #{modelo.Codigo}",
                HRef = $"/cadastro/modelos/{modelo.Codigo}",
                Data = modelo,
                Links = new Link[]
                {
                    new Link {Rel = "visualizacao-de-modelo", HRef = $"/cadastro/modelos/{modelo.Codigo}", Text = "Visualizar"},
                    new Link {Rel = "alteracao-de-modelos", HRef = $"/cadastro/modelos/{modelo.Codigo}/alteracao-de-modelos", Text = "Alterar"},
                    new Link {Rel = "exclusao-de-modelo", HRef = $"/cadastro/modelos/{modelo.Codigo}/exclusao-de-modelos", Text = "Excluir"}
                }
            };

            return CreatedAtAction(nameof(GetModelo), new { id = modelo.Codigo }, resource);
        }
    }
}
