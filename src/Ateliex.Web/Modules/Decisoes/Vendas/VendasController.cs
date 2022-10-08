using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ateliex.Modules.Decisoes.Vendas
{
    [ApiController]
    [Route("api/vendas")]
    public class VendasController : ControllerBase
    {
        private readonly CalculoDeTaxaDeMarcacao calculoDeTaxaDeMarcacao;

        public VendasController(CalculoDeTaxaDeMarcacao calculoDeTaxaDeMarcacao)
        {
            this.calculoDeTaxaDeMarcacao = calculoDeTaxaDeMarcacao;
        }

        [HttpPost("calculoDeTaxaDeMarcacao")]
        public ActionResult<decimal> PostSolicitacaoDeCalculoDeTaxaDeMarcacao(decimal cf, decimal cv, decimal ml)
        {
            var tm = calculoDeTaxaDeMarcacao.CalculaTaxaDeMarcacao(cf, cv, ml);

            return tm;
        }
    }
}
