﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Linq;
using System.Web;

namespace Ateliex.Modules.Cadastro.Modelos
{
    [Route("/cadastro/modelos")]
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
        public IActionResult GetModelos(SolicitacaoDeConsultaDeModelos solicitacao)
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
                        new Link {Rel = "detalhes-de-modelo", HRef = $"/cadastro/modelos/{modelo.Codigo}", Text = "Detalhar"},
                        new Link {Rel = "alteracao-de-modelos", HRef = $"/cadastro/modelos/{modelo.Codigo}/alteracao-de-modelos", Text = "Alterar"},
                        new Link {Rel = "exclusao-de-modelos", HRef = $"/cadastro/modelos/{modelo.Codigo}/exclusao-de-modelos", Text = "Excluir"}
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
        public IActionResult GetDetalhesDeModelo(string id)
        {
            var codigo = new CodigoDeModelo(id);

            var modelo = consultaDeModelos.ObtemModelo(codigo);

            var resource = new Resource<Modelo>
            {
                Title = $"Modelo #{id}",
                HRef = $"/cadastro/modelos/{id}",
                Data = modelo,
                Links = new Link[]
                {
                    new Link {Rel = "recursos-de-modelo", HRef = $"/cadastro/modelos/{id}/recursos", Text = "Recursos"},
                    new Link {Rel = "alteracao-de-modelos", HRef = $"/cadastro/modelos/{id}/alteracao-de-modelos", Text = "Alterar"},
                    new Link {Rel = "exclusao-de-modelos", HRef = $"/cadastro/modelos/{id}/exclusao-de-modelos", Text = "Excluir"}
                }
            };

            return Ok(resource);
        }

        [HttpGet("{id}/recursos")]
        public IActionResult GetRecursosDeModelo(string id)
        {
            var codigo = new CodigoDeModelo(id);

            var modelo = consultaDeModelos.ObtemModelo(codigo);

            var data = modelo.Recursos
                .Select(recurso => new Resource<Recurso>
                {
                    Title = $"Recurso #{recurso.Id}",
                    HRef = $"/cadastro/modelos/{id}/recursos",
                    Data = recurso,
                    Links = new Link[]
                    {
                        new Link {Rel = "detalhes-de-modelo", HRef = $"/cadastro/modelos/{id}/recursos/{recurso.Id}", Text = "Detalhar"},
                        new Link {Rel = "alteracao-de-recursos", HRef = $"/cadastro/modelos/{id}/recursos/{recurso.Id}/alteracao-de-recursos", Text = "Alterar"},
                        new Link {Rel = "exclusao-de-recursos", HRef = $"/cadastro/modelos/{id}/recursos/{recurso.Id}/exclusao-de-recursos", Text = "Excluir"}
                    }
                })
                .ToArray();

            var resource = new ResourceCollection<Recurso>
            {
                Title = "Recursos",
                HRef = $"/cadastro/modelos/{id}/recursos",
                Data = data,
                Links = new Link[]
                {
                    new Link {Rel = "adicao-de-recursos", HRef = $"/cadastro/modelos/{id}/recursos/adicao-de-recursos", Text = "Adição de Recursos"}
                }
            };

            return Ok(resource);
        }

        [HttpGet("{id}/recursos/adicao-de-recursos")]
        public IActionResult GetAdicaoDeRecursos(string id)
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
                HRef = $"/cadastro/modelos/{id}/recursos/adicao-de-recursos",
                Data = solicitacao,
                Method = "POST",
                Action = $"/cadastro/modelos/{id}/recursos/adicao-de-recursos",
                Links = new Link[] { }
            };

            return Ok(resource);
        }

        [HttpPost("{id}/recursos/adicao-de-recursos")]
        public IActionResult PostAdicaoDeRecursos(string id, [FromBody] SolicitacaoDeAdicaoDeRecursoDeModelo solicitacao)
        {
            solicitacao.ModeloCodigo = id;

            var codigo = new CodigoDeModelo(id);

            var recurso = cadastroDeModelos.AdicionaRecursoDeModelo(solicitacao);

            if (HttpContext.Request.Headers.ContainsKey("Accept"))
            {
                var accept = HttpContext.Request.Headers["Accept"];

                if (accept == "text/html")
                {
                    var resource = new Resource<Recurso>
                    {
                        Title = $"Recurso #{recurso.Id}",
                        HRef = $"/cadastro/modelos/{id}/recusos/{recurso.Id}/adicao-de-recursos",
                        Data = recurso,
                        Links = new Link[]
                        {
                    new Link {Rel = "detalhes-de-modelo", HRef = $"/cadastro/modelos/{id}/recursos/{recurso.Id}", Text = "Detalhar"},
                    new Link {Rel = "alteracao-de-recursos", HRef = $"/cadastro/modelos/{id}/recursos/{recurso.Id}/alteracao-de-recursos", Text = "Alterar"},
                    new Link {Rel = "exclusao-de-recursos", HRef = $"/cadastro/modelos/{id}/recursos/{recurso.Id}/exclusao-de-recursos", Text = "Excluir"}
                        }
                    };

                    return CreatedAtAction(nameof(GetDetalhesDeRecurso), new { id = id, idDeRecurso = recurso.Id }, resource);
                }
            }

            return CreatedAtAction(nameof(GetDetalhesDeRecurso), new { id = codigo.Valor, idDeRecurso = recurso.Id }, recurso);
        }

        [HttpGet("{id}/recursos/{idDeRecurso}")]
        public IActionResult GetDetalhesDeRecurso(string id, int idDeRecurso)
        {
            var codigo = new CodigoDeModelo(id);

            var modelo = consultaDeModelos.ObtemModelo(codigo);

            var recurso = modelo.ObtemRecurso(idDeRecurso);

            var resource = new Resource<Modelo>
            {
                Title = $"Recurso #{idDeRecurso}",
                HRef = $"/cadastro/modelos/{id}/recusos/{recurso.Id}",
                Data = modelo,
                Links = new Link[]
                {
                    new Link {Rel = "alteracao-de-recursos", HRef = $"/cadastro/modelos/{id}/recursos/{recurso.Id}/alteracao-de-recursos", Text = "Alterar"},
                    new Link {Rel = "exclusao-de-recursos", HRef = $"/cadastro/modelos/{id}/recursos/{recurso.Id}/exclusao-de-recursos", Text = "Excluir"}
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
                Title = "Cadastro de Modelos",
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
                        new Link {Rel = "detalhes-de-modelo", HRef = $"/cadastro/modelos/{modelo.Codigo}", Text = "Detalhar"},
                        new Link {Rel = "alteracao-de-modelos", HRef = $"/cadastro/modelos/{modelo.Codigo}/alteracao-de-modelos", Text = "Alterar"},
                        new Link {Rel = "exclusao-de-modelos", HRef = $"/cadastro/modelos/{modelo.Codigo}/exclusao-de-modelos", Text = "Excluir"}
                }
            };

            return CreatedAtAction(nameof(GetDetalhesDeModelo), new { id = modelo.Codigo }, resource);

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
