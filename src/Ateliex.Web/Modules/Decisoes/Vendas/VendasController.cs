using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ateliex.Modules.Decisoes.Vendas
{
    [ApiController]
    [Route("/vendas")]
    public class VendasController : ControllerBase
    {
        private readonly CalculoDeTaxaDeMarcacao calculoDeTaxaDeMarcacao;

        public VendasController(CalculoDeTaxaDeMarcacao calculoDeTaxaDeMarcacao)
        {
            this.calculoDeTaxaDeMarcacao = calculoDeTaxaDeMarcacao;
        }

        [HttpPost("calculoDeTaxaDeMarcacao")]
        public IActionResult Post([FromBody] CalculoDeTaxaDeMarcacaoRequest request)
        {
            var tm = calculoDeTaxaDeMarcacao.CalculaTaxaDeMarcacao(request.CF, request.CV, request.ML);

            return Accepted(tm);
        }
    }

    public class CalculoDeTaxaDeMarcacaoRequest
    {
        public decimal CF { get; set; }
        
        public decimal CV { get; set; }
        
        public decimal ML { get; set; }
    }
}
