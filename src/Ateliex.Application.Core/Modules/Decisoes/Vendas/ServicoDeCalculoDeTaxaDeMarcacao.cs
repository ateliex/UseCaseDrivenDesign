using System;
using System.Collections.Generic;
using System.Text;

namespace Ateliex.Modules.Decisoes.Vendas
{
    public class ServicoDeCalculoDeTaxaDeMarcacao : CalculoDeTaxaDeMarcacao
    {
        private readonly CalculadoraDeTaxaDeMarcacao calculadoraDeTaxaDeMarcacao;

        public ServicoDeCalculoDeTaxaDeMarcacao(CalculadoraDeTaxaDeMarcacao calculadoraDeTaxaDeMarcacao)
        {
            this.calculadoraDeTaxaDeMarcacao = calculadoraDeTaxaDeMarcacao;
        }

        public decimal CalculaTaxaDeMarcacao(decimal cf, decimal cv, decimal ml)
        {
            return calculadoraDeTaxaDeMarcacao.CalculaTaxaDeMarcacao(cf, cv, ml);
        }
    }
}
