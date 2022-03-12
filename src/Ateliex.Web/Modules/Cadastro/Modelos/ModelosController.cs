using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Ateliex.Modules.Cadastro.Modelos
{
    [Route("api/cadastro/modelos")]
    public class ModelosController : ControllerBase
    {
        private readonly IConsultaDeModelos consultaDeModelos;

        private readonly ICadastroDeModelos cadastroDeModelos;

        public ModelosController(IConsultaDeModelos consultaDeModelos, ICadastroDeModelos cadastroDeModelos)
        {
            this.consultaDeModelos = consultaDeModelos;

            this.cadastroDeModelos = cadastroDeModelos;
        }

        [HttpGet(Name = "GetModelos")]
        public async Task<ActionResult<ResourceCollection<Modelo>>> GetModelos(SolicitacaoDeConsultaDeModelos solicitacao)
        {
            var modelos = await consultaDeModelos.ConsultaModelos(solicitacao);

            var data = modelos
                .Select(modelo => new Resource<Modelo>
                {
                    Title = $"Modelo #{modelo.CodigoDeModelo}",
                    HRef = $"/api/cadastro/modelos/{modelo.CodigoDeModelo}",
                    Data = modelo,
                    Links = new Link[]
                    {
                        new Link {Rel = "detalhes-de-modelo", HRef = $"/api/cadastro/modelos/{modelo.CodigoDeModelo}", Text = "Detalhar"},
                        new Link {Rel = "alteracao-de-modelos", HRef = $"/api/cadastro/modelos/{modelo.CodigoDeModelo}/alteracao-de-modelos", Text = "Alterar"},
                        new Link {Rel = "exclusao-de-modelos", HRef = $"/api/cadastro/modelos/{modelo.CodigoDeModelo}/exclusao-de-modelos", Text = "Excluir"}
                    }
                })
                .ToArray();

            var resource = new ResourceCollection<Modelo>
            {
                Title = "Modelos",
                HRef = "/api/cadastro/modelos",
                Data = data,
                Links = new Link[]
                {
                    new Link {Rel = "consulta-de-modelos", HRef = "/api/cadastro/modelos/consulta-de-modelos", Text = "Consulta de Modelos"},
                    new Link {Rel = "cadastro-de-modelos", HRef = "/api/cadastro/modelos/cadastro-de-modelos", Text = "Cadastro de Modelos"}
                }
            };

            return resource;
        }

        [HttpGet("consulta-de-modelos")]
        public ActionResult<ResourceForm<SolicitacaoDeConsultaDeModelos>> GetConsultaDeModelos()
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
                HRef = "/api/cadastro/modelos/consulta-de-modelos",
                Data = solicitacao,
                Method = "GET",
                Action = "/api/cadastro/modelos",
                Links = new Link[] { }
            };

            return resource;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Resource<Modelo>>> GetDetalhesDeModelo(string id)
        {
            var codigo = new CodigoDeModelo(id);

            var modelo = await consultaDeModelos.ObtemModelo(codigo);

            var resource = new Resource<Modelo>
            {
                Title = $"Modelo #{id}",
                HRef = $"/api/cadastro/modelos/{id}",
                Data = modelo,
                Links = new Link[]
                {
                    new Link {Rel = "recursos-de-modelo", HRef = $"/api/cadastro/modelos/{id}/recursos", Text = "Recursos"},
                    new Link {Rel = "alteracao-de-modelos", HRef = $"/api/cadastro/modelos/{id}/alteracao-de-modelos", Text = "Alterar"},
                    new Link {Rel = "exclusao-de-modelos", HRef = $"/api/cadastro/modelos/{id}/exclusao-de-modelos", Text = "Excluir"}
                }
            };

            return resource;
        }

        [HttpGet("{id}/recursos")]
        public async Task<ActionResult<ResourceCollection<Recurso>>> GetRecursosDeModelo(string id)
        {
            var codigo = new CodigoDeModelo(id);

            var modelo = await consultaDeModelos.ObtemModelo(codigo);

            var data = modelo.Recursos
                .Select(recurso => new Resource<Recurso>
                {
                    Title = $"Recurso #{recurso.Id}",
                    HRef = $"/api/cadastro/modelos/{id}/recursos",
                    Data = recurso,
                    Links = new Link[]
                    {
                        new Link {Rel = "detalhes-de-modelo", HRef = $"/api/cadastro/modelos/{id}/recursos/{recurso.Id}", Text = "Detalhar"},
                        new Link {Rel = "alteracao-de-recursos", HRef = $"/api/cadastro/modelos/{id}/recursos/{recurso.Id}/alteracao-de-recursos", Text = "Alterar"},
                        new Link {Rel = "exclusao-de-recursos", HRef = $"/api/cadastro/modelos/{id}/recursos/{recurso.Id}/exclusao-de-recursos", Text = "Excluir"}
                    }
                })
                .ToArray();

            var resource = new ResourceCollection<Recurso>
            {
                Title = "Recursos",
                HRef = $"/api/cadastro/modelos/{id}/recursos",
                Data = data,
                Links = new Link[]
                {
                    new Link {Rel = "adicao-de-recursos", HRef = $"/api/cadastro/modelos/{id}/recursos/adicao-de-recursos", Text = "Adição de Recursos"}
                }
            };

            return resource;
        }

        [HttpGet("{id}/recursos/adicao-de-recursos")]
        public ActionResult<ResourceForm<SolicitacaoDeAdicaoDeRecursoDeModelo>> GetAdicaoDeRecursos(string id)
        {
            var codigo = new CodigoDeModelo(id);

            var solicitacao = new SolicitacaoDeAdicaoDeRecursoDeModelo
            {
                ModeloCodigo = id,
                Descricao = "Recurso #"
            };

            var resource = new ResourceForm<SolicitacaoDeAdicaoDeRecursoDeModelo>
            {
                Title = "Adição de Recursos",
                HRef = $"/api/cadastro/modelos/{id}/recursos/adicao-de-recursos",
                Data = solicitacao,
                Method = "POST",
                Action = $"/api/cadastro/modelos/{id}/recursos/adicao-de-recursos",
                Links = new Link[] { }
            };

            return resource;
        }

        [HttpPost("{id}/recursos/adicao-de-recursos")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Resource<Recurso>>> PostAdicaoDeRecursos(string id, SolicitacaoDeAdicaoDeRecursoDeModelo solicitacao)
        {
            solicitacao.ModeloCodigo = id;

            var codigo = new CodigoDeModelo(id);

            var recurso = await cadastroDeModelos.AdicionaRecursoDeModelo(solicitacao);

            var resource = new Resource<Recurso>
            {
                Title = $"Recurso #{recurso.Id}",
                HRef = $"/api/cadastro/modelos/{id}/recusos/{recurso.Id}/adicao-de-recursos",
                Data = recurso,
                Links = new Link[]
                {
                    new Link {Rel = "detalhes-de-modelo", HRef = $"/api/cadastro/modelos/{id}/recursos/{recurso.Id}", Text = "Detalhar"},
                    new Link {Rel = "alteracao-de-recursos", HRef = $"/api/cadastro/modelos/{id}/recursos/{recurso.Id}/alteracao-de-recursos", Text = "Alterar"},
                    new Link {Rel = "exclusao-de-recursos", HRef = $"/api/cadastro/modelos/{id}/recursos/{recurso.Id}/exclusao-de-recursos", Text = "Excluir"}
                }
            };

            return CreatedAtAction(nameof(GetDetalhesDeRecurso), new { id = id, idDeRecurso = recurso.Id }, resource);
        }

        [HttpGet("{id}/recursos/{idDeRecurso}")]
        public async Task<ActionResult<Resource<Modelo>>> GetDetalhesDeRecurso(string id, int idDeRecurso)
        {
            var codigo = new CodigoDeModelo(id);

            var modelo = await consultaDeModelos.ObtemModelo(codigo);

            var recurso = modelo.ObtemRecurso(idDeRecurso);

            var resource = new Resource<Modelo>
            {
                Title = $"Recurso #{idDeRecurso}",
                HRef = $"/api/cadastro/modelos/{id}/recusos/{recurso.Id}",
                Data = modelo,
                Links = new Link[]
                {
                    new Link {Rel = "alteracao-de-recursos", HRef = $"/api/cadastro/modelos/{id}/recursos/{recurso.Id}/alteracao-de-recursos", Text = "Alterar"},
                    new Link {Rel = "exclusao-de-recursos", HRef = $"/api/cadastro/modelos/{id}/recursos/{recurso.Id}/exclusao-de-recursos", Text = "Excluir"}
                }
            };

            return resource;
        }

        [HttpGet("cadastro-de-modelos")]
        public ActionResult<ResourceForm<SolicitacaoDeCadastroDeModelo>> GetCadastroDeModelos()
        {
            var solicitacao = new SolicitacaoDeCadastroDeModelo
            {
                Codigo = Guid.NewGuid().ToString(),
                Nome = "Modelo #"
            };

            var resource = new ResourceForm<SolicitacaoDeCadastroDeModelo>
            {
                Title = "Cadastro de Modelos",
                HRef = "/api/cadastro/modelos/cadastro-de-modelos",
                Data = solicitacao,
                Method = "POST",
                Action = "/api/cadastro/modelos/cadastro-de-modelos",
                Links = new Link[] { }
            };

            return resource;
        }

        [HttpPost("cadastro-de-modelos")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Resource<Modelo>> PostCadastroDeModelos(SolicitacaoDeCadastroDeModelo solicitacao)
        {
            var modelo = cadastroDeModelos.CadastraModelo(solicitacao);

            var resource = new Resource<Modelo>
            {
                Title = $"Modelo #{modelo.CodigoDeModelo}",
                HRef = $"/api/cadastro/modelos/{modelo.CodigoDeModelo}",
                Data = modelo,
                Links = new Link[]
                {
                    new Link {Rel = "detalhes-de-modelo", HRef = $"/api/cadastro/modelos/{modelo.CodigoDeModelo}", Text = "Detalhar"},
                    new Link {Rel = "alteracao-de-modelos", HRef = $"/api/cadastro/modelos/{modelo.CodigoDeModelo}/alteracao-de-modelos", Text = "Alterar"},
                    new Link {Rel = "exclusao-de-modelos", HRef = $"/api/cadastro/modelos/{modelo.CodigoDeModelo}/exclusao-de-modelos", Text = "Excluir"}
                }
            };

            return CreatedAtAction(nameof(GetDetalhesDeModelo), new { id = modelo.CodigoDeModelo }, resource);

            //if (HttpContext.Request.Headers.ContainsKey("Accept"))
            //{
            //    var accept = HttpContext.Request.Headers["Accept"];

            //    if (accept.Contains("text/html"))
            //    {
            //    }
            //}

            //return CreatedAtAction(nameof(GetDetalhesDeModelo), new { id = modelo.Codigo }, modelo);
        }
    }
}
