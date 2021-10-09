using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ateliex.Modules.Decisoes.Vendas
{
    [Route("api/vendas")]
    public class VendasController : Controller
    {
        private readonly CalculoDeTaxaDeMarcacao calculoDeTaxaDeMarcacao;

        public VendasController(CalculoDeTaxaDeMarcacao calculoDeTaxaDeMarcacao)
        {
            this.calculoDeTaxaDeMarcacao = calculoDeTaxaDeMarcacao;
        }

        [HttpPost("calculoDeTaxaDeMarcacao")]
        public IActionResult Post([FromBody] decimal cf, [FromBody] decimal cv, [FromBody] decimal ml)
        {
            var tm = calculoDeTaxaDeMarcacao.CalculaTaxaDeMarcacao(cf, cv, ml);

            return Ok(tm);
        }
    }
}
