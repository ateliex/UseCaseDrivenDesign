using System;
using System.Collections.Generic;
using System.Text;

namespace Ateliex.Modules.Decisoes.Vendas
{
    public interface CalculoDeTaxaDeMarcacao
    {
        public decimal CalculaTaxaDeMarcacao(decimal cf, decimal cv, decimal ml);
    }
}
