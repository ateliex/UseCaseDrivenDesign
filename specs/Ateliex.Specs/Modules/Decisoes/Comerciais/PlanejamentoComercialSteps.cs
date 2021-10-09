using System;
using TechTalk.SpecFlow;

namespace Ateliex.Modules.Decisoes.Comerciais
{
    [Binding]
    public class PlanejamentoComercialSteps
    {
        [Given(@"que o código escolhido para o plano comercial foi '(.*)'")]
        public void DadoQueOCodigoEscolhidoParaOPlanoComercialFoi(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"que o nome escolhido para o plano comercial foi de '(.*)'")]
        public void DadoQueONomeEscolhidoParaOPlanoComercialFoiDe(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"que a data escolhida para o plano comercial foi de '(.*)'")]
        public void DadoQueADataEscolhidaParaOPlanoComercialFoiDe(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"que a renda mensal bruta declarada para o plano comercial foi de R\$ (.*)\.(.*)")]
        public void DadoQueARendaMensalBrutaDeclaradaParaOPlanoComercialFoiDeR_(int p0, Decimal p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"eu criar o plano comercial")]
        public void QuandoEuCriarOPlanoComercial()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"um plano comercial deve ser criado")]
        public void EntaoUmPlanoComercialDeveSerCriado()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"o código do plano comercial criado deve ser '(.*)'")]
        public void EntaoOCodigoDoPlanoComercialCriadoDeveSer(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"o nome do plano comercial criado deve ser '(.*)'")]
        public void EntaoONomeDoPlanoComercialCriadoDeveSer(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"a data do plano comercial criado deve ser '(.*)'")]
        public void EntaoADataDoPlanoComercialCriadoDeveSer(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"a renda mensal bruta declarada no plano comercial criado deve ser de R\$ (.*)\.(.*)")]
        public void EntaoARendaMensalBrutaDeclaradaNoPlanoComercialCriadoDeveSerDeR_(int p0, Decimal p1)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
