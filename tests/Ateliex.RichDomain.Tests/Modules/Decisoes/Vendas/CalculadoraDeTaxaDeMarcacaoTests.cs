using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ateliex.Modules.Decisoes.Vendas
{
    public class AoCalcularTaxaDeMarcacao : Test
    {
        protected CalculadoraDeTaxaDeMarcacao calculadoraDeTaxaDeMarcacao;

        protected decimal custoFixo;

        protected decimal custoVariavel;

        protected decimal margemDeLucro;

        protected decimal taxaDeMarcacao;

        public AoCalcularTaxaDeMarcacao()
        {
            calculadoraDeTaxaDeMarcacao = new CalculadoraDeTaxaDeMarcacao();
        }

        public override void Act()
        {
            taxaDeMarcacao = calculadoraDeTaxaDeMarcacao.CalculaTaxaDeMarcacao(custoFixo, custoVariavel, margemDeLucro);
        }

        public class ComSucesso : AoCalcularTaxaDeMarcacao
        {
            [Fact]
            public void O_Resuldado_Deve_Ser_Correto()
            {
                taxaDeMarcacao.Should().BeGreaterThan(0);
            }
        }
    }
}
