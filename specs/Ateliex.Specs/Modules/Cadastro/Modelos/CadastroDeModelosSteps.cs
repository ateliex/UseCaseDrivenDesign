using FluentAssertions;
using System;
using TechTalk.SpecFlow;

namespace Ateliex.Modules.Cadastro.Modelos
{
    [Binding]
    public class CadastroDeModelosSteps
    {
        private readonly ScenarioContext scenario;

        private readonly CadastroDeModelos cadastroDeModelos;

        private readonly Modelo modelo;

        private Recurso recurso;

        private Modelo modeloCadastrado;

        private Modelo modeloComRecursoAdicionado;

        public CadastroDeModelosSteps(
            ScenarioContext scenario,
            CadastroDeModelos cadastroDeModelos)
        {
            this.scenario = scenario;

            this.cadastroDeModelos = cadastroDeModelos;

            modelo = new Modelo();
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
            modeloCadastrado = cadastroDeModelos.CadastraModelo(modelo);
        }

        [Then(@"um modelo deve ser cadastrado")]
        public void EntaoModelo()
        {
            modeloCadastrado.Should().NotBeNull();
        }

        [Then(@"o código do modelo cadastrado deve ser '(.*)'")]
        public void EntaoCodigo(string expected)
        {
            modeloCadastrado.Codigo.Should().Be(expected);
        }

        [Then(@"o nome do modelo cadastrado deve ser '(.*)'")]
        public void EntaoNome(string expected)
        {
            modeloCadastrado.Nome.Should().Be(expected);
        }

        //

        [Given(@"que um modelo foi cadastrado com sucesso")]
        public void DadoQueUmModeloFoiCadastradoComSucesso()
        {
            var modelo = new Modelo
            {
                Codigo = "M02",
            };

            modeloCadastrado = cadastroDeModelos.CadastraModelo(modelo);

            modeloCadastrado.Should().NotBeNull();
        }

        [Given(@"que um recurso de '(.*)' foi necessário para esse modelo")]
        public void DadoQueUmRecursoDeFoiNecessarioParaEsseModelo(string p0)
        {
            recurso = new Recurso
            {
                Modelo = modeloCadastrado
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
            modeloComRecursoAdicionado = cadastroDeModelos.AdicionaRecursoDeModelo(recurso);
        }

        [Then(@"esse modelo deve conter um recurso de '(.*)' adicionado")]
        public void EntaoEsseModeloDeveConterUmRecursoDeAdicionado(string p0)
        {
            modeloComRecursoAdicionado.Should().NotBeNull();
        }

        [Then(@"o custo de produção desse modelo deve ser R\$ (.*)")]
        public void EntaoOCustoDeProducaoDesseModeloDeveSerR(Decimal p0)
        {
            modeloComRecursoAdicionado.CustoDeProducao.Should().Be(p0);
        }

        [Then(@"o custo desse recurso de modelo adicionado deve ser R\$ (.*)")]
        public void EntaoOCustoDesseRecursoDeModeloAdicionadoDeveSerR(Decimal p0)
        {
            var recurso = modeloComRecursoAdicionado.Recursos[0];

            recurso.Custo.Should().Be(p0);
        }

        [Then(@"as unidades desse recurso de modelo adicionado devem ser (.*)")]
        public void EntaoAsUnidadesDesseRecursoDeModeloAdicionadoDevemSer(Decimal p0)
        {
            var recurso = modeloComRecursoAdicionado.Recursos[0];

            recurso.Unidades.Should().Be(p0);
        }

        [Then(@"o custo por unidade desse recurso de modelo adicionado deve ser R\$ (.*)")]
        public void EntaoOCustoPorUnidadeDesseRecursoDeModeloAdicionadoDeveSerR(Decimal p0)
        {
            var recurso = modeloComRecursoAdicionado.Recursos[0];

            recurso.CustoPorUnidade.Should().Be(p0);
        }

        [Then(@"o tipo desse recurso de modelo adicionado deve ser '(.*)'")]
        public void EntaoOTipoDesseRecursoDeModeloAdicionadoDeveSer(string p0)
        {
            var recurso = modeloComRecursoAdicionado.Recursos[0];

            var tipo = (TipoDeRecurso)Enum.Parse(typeof(TipoDeRecurso), p0);

            recurso.Tipo.Should().Be(tipo);
        }

        [Given(@"que (.*) unidades do recurso '(.*)' de '(.*)' de R\$ (.*) foi adicionado para esse modelo")]
        public void DadoQueUnidadesDoRecursoDeDeRFoiAdicionadoParaEsseModelo(Decimal p0, string p1, string p2, Decimal p3)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
