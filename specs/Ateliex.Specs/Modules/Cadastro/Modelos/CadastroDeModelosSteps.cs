using FluentAssertions;
using System;
using System.Net.Http;
using TechTalk.SpecFlow;

namespace Ateliex.Modules.Cadastro.Modelos
{
    [Binding]
    public class CadastroDeModelosSteps
    {
        private readonly ScenarioContext scenario;

        private readonly ModelosClient modelosClient;

        private readonly SolicitacaoDeCadastroDeModelo modelo;

        private SolicitacaoDeAdicaoDeRecursoDeModelo recurso;

        private ResourceOfModelo modeloCadastrado;

        private ResourceOfRecurso recursoAdicionado;

        public CadastroDeModelosSteps(
            ScenarioContext scenario,
            HttpClient httpClient)
        {
            this.scenario = scenario;

            modelosClient = new ModelosClient(httpClient);

            modelo = new SolicitacaoDeCadastroDeModelo();
        }

        [Given(@"que o código escolhido para o modelo foi de '(.*)'")]
        public void DadoCodigo(string codigo)
        {
            modelo.Codigo = codigo;
        }

        [Given(@"que o nome escolhido para o modelo foi de '(.*)'")]
        public void DadoNome(string nome)
        {
            modelo.Nome = nome;
        }

        [When(@"eu cadastrar o modelo")]
        public void QuandoCadastraModelo()
        {
            modeloCadastrado = modelosClient.PostCadastroDeModelos(modelo.Codigo, modelo.Nome);
        }

        [Then(@"um modelo deve ser cadastrado")]
        public void EntaoModelo()
        {
            modeloCadastrado.Should().NotBeNull();
        }

        [Then(@"o código do modelo cadastrado deve ser '(.*)'")]
        public void EntaoCodigo(string expected)
        {
            modeloCadastrado.Data.CodigoDeModelo.Should().Be(expected);
        }

        [Then(@"o nome do modelo cadastrado deve ser '(.*)'")]
        public void EntaoNome(string expected)
        {
            modeloCadastrado.Data.Nome.Should().Be(expected);
        }

        //

        [Given(@"que um modelo foi cadastrado com sucesso")]
        public void DadoQueUmModeloFoiCadastradoComSucesso()
        {
            var modelo = new SolicitacaoDeCadastroDeModelo
            {
                Codigo = "M02",
            };

            modeloCadastrado = modelosClient.PostCadastroDeModelos(modelo.Codigo, modelo.Nome);

            modeloCadastrado.Should().NotBeNull();
        }

        [Given(@"que um recurso de '(.*)' foi necessário para esse modelo")]
        public void DadoQueUmRecursoDeFoiNecessarioParaEsseModelo(string p0)
        {
            recurso = new SolicitacaoDeAdicaoDeRecursoDeModelo
            {
                ModeloCodigo = modeloCadastrado.Data.CodigoDeModelo
            };

            recurso.Descricao = p0;
        }

        [Given(@"que o custo desse recurso do modelo foi de R\$ (.*)")]
        public void DadoQueOCustoDesseRecursoDoModeloFoiDeR(Decimal p0)
        {
            recurso.Custo = p0;
        }

        [Given(@"que as unidades desse recurso do modelo foram de (.*)")]
        public void DadoQueAsUnidadesDesseRecursoDoModeloForamDe(Decimal p0)
        {
            recurso.Unidades = p0;
        }

        [Given(@"que o tipo desse recurso do modelo foi '(.*)'")]
        public void DadoQueOTipoDesseRecursoDoModeloFoi(string p0)
        {
            var tipo = (TipoDeRecurso)Enum.Parse(typeof(TipoDeRecurso), p0);

            recurso.Tipo = tipo;
        }

        [When(@"eu adicionar esse recurso ao modelo")]
        public void QuandoEuAdicionarEsseRecursoAoModelo()
        {
            recursoAdicionado = modelosClient.PostAdicaoDeRecursos(
                modeloCadastrado.Data.CodigoDeModelo,
                recurso.ModeloCodigo,
                recurso.Tipo,
                recurso.Descricao,
                recurso.Custo,
                recurso.Unidades);
        }

        [Then(@"esse modelo deve conter um recurso de '(.*)' adicionado")]
        public void EntaoEsseModeloDeveConterUmRecursoDeAdicionado(string p0)
        {
            recursoAdicionado.Data.Modelo.Should().NotBeNull();
        }

        [Then(@"o custo de produção desse modelo deve ser R\$ (.*)")]
        public void EntaoOCustoDeProducaoDesseModeloDeveSerR(Decimal p0)
        {
            recursoAdicionado.Data.Modelo.CustoDeProducao.Should().Be(p0);
        }

        [Then(@"o custo desse recurso de modelo adicionado deve ser R\$ (.*)")]
        public void EntaoOCustoDesseRecursoDeModeloAdicionadoDeveSerR(Decimal p0)
        {
            recursoAdicionado.Data.Custo.Should().Be(p0);
        }

        [Then(@"as unidades desse recurso de modelo adicionado devem ser (.*)")]
        public void EntaoAsUnidadesDesseRecursoDeModeloAdicionadoDevemSer(Decimal p0)
        {
            recursoAdicionado.Data.Unidades.Should().Be(p0);
        }

        [Then(@"o custo por unidade desse recurso de modelo adicionado deve ser R\$ (.*)")]
        public void EntaoOCustoPorUnidadeDesseRecursoDeModeloAdicionadoDeveSerR(Decimal p0)
        {
            recursoAdicionado.Data.CustoPorUnidade.Should().Be(p0);
        }

        [Then(@"o tipo desse recurso de modelo adicionado deve ser '(.*)'")]
        public void EntaoOTipoDesseRecursoDeModeloAdicionadoDeveSer(string p0)
        {
            var tipo = (TipoDeRecurso)Enum.Parse(typeof(TipoDeRecurso), p0);

            recursoAdicionado.Data.Tipo.Should().Be(tipo);
        }

        [Given(@"que (.*) unidades do recurso '(.*)' de '(.*)' de R\$ (.*) foi adicionado para esse modelo")]
        public void DadoQueUnidadesDoRecursoDeDeRFoiAdicionadoParaEsseModelo(Decimal p0, string p1, string p2, Decimal p3)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
