using FluentAssertions;
using System;
using System.Net.Http;
using TechTalk.SpecFlow;

namespace Ateliex.Modules.Decisoes.Vendas
{
    [Binding]
    public class CalculoDeTaxaDeMarcacaoSteps
    {
        private readonly ScenarioContext scenario;

        private readonly VendasClient vendasClient;

        public CalculoDeTaxaDeMarcacaoSteps(
            ScenarioContext scenario,
            HttpClient httpClient)
        {
            this.scenario = scenario;

            vendasClient = new VendasClient(httpClient);
        }

        [Given(@"que o custo fixo foi de (.*)%")]
        public void DadoCustoFixo(decimal cf)
        {
            scenario.Add("cf", cf);
        }

        [Given(@"que o custo variável foi de (.*)%")]
        public void DadoCustoVariavel(decimal cv)
        {
            scenario.Add("cv", cv);
        }

        [Given(@"que a margem de lucro escolhida foi de (.*)%")]
        public void DadoMargemDeLucro(decimal ml)
        {
            scenario.Add("ml", ml);
        }

        [When(@"a taxa de marcação é calculada")]
        public void QuandoCalculaTaxaDeMarcacao()
        {
            var cf = scenario.Get<decimal>("cf");

            var cv = scenario.Get<decimal>("cv");

            var ml = scenario.Get<decimal>("ml");

            var tm = vendasClient.PostSolicitacaoDeCalculoDeTaxaDeMarcacao(cf, cv, ml);

            scenario.Add("tm", tm);
        }

        [Then(@"o resultado deve ser de (.*)")]
        public void EntaoResultado(decimal expected)
        {
            var tm = scenario.Get<decimal>("tm");

            tm.Should().Be(expected);
        }
    }
}
