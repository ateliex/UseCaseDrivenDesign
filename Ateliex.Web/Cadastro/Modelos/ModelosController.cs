using Ateliex.Cadastro.Modelos.CadastroDeModelos;
using Ateliex.Cadastro.Modelos.ConsultaDeModelos;
using Microsoft.AspNetCore.Mvc;
using System;
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

        public IActionResult Index(SolicitacaoDeConsultaDeModelos solicitacao = null)
        {
            var resource = new ModelosResource();

            return Ok(resource);
        }

        [HttpGet("{id}")]
        public IActionResult GetModelo(string id)
        {
            var codigo = new CodigoDeModelo(id);

            var modelo = consultaDeModelos.ObtemModelo(codigo);

            var resource = new ModeloResource
            {
                Data = modelo
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

            var resource = new LinkedResourceForm<SolicitacaoDeConsultaDeModelos>
            {
                Data = solicitacao,
                Method = "GET"
            };

            return Ok(resource);
        }

        [HttpPost("consulta-de-modelos")]
        public IActionResult PostConsultaDeModelos(SolicitacaoDeConsultaDeModelos solicitacao)
        {
            var resposta = consultaDeModelos.ConsultaModelos(solicitacao);

            var resource = new ModelosResource
            {

            };

            return CreatedAtAction(nameof(Index), new { }, resource);
        }

        [HttpGet("cadastro-de-modelos")]
        public IActionResult GetCadastroDeModelos()
        {
            var solicitacao = new SolicitacaoDeCadastroDeModelo
            {
                Codigo = Guid.NewGuid().ToString(),
                Nome = "Modelo #"
            };

            var resource = new LinkedResourceForm<SolicitacaoDeCadastroDeModelo>
            {
                Data = solicitacao,
                Method = "POST"
            };

            return Ok(resource);
        }

        [HttpPost("cadastro-de-modelos")]
        public IActionResult PostCadastroDeModelos(SolicitacaoDeCadastroDeModelo solicitacao)
        {
            var resposta = cadastroDeModelos.CadastraModelo(solicitacao);

            var resource = new ModeloResource
            {

            };

            return CreatedAtAction(nameof(Index), new { }, resource);
        }
    }
}
