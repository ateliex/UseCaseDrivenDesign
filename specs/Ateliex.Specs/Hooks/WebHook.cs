using Ateliex.Modules.Cadastro.Modelos;
using Ateliex.Modules.Decisoes.Vendas;
using BoDi;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using Xunit;

namespace Ateliex.Hooks
{
    [Binding]
    public class WebHook : IClassFixture<AteliexWebFactory>
    {
        private readonly IObjectContainer objectContainer;

        private readonly ISpecFlowOutputHelper specFlowOutputHelper;

        private readonly WebApplicationFactory<Startup> webFactory;

        private readonly HttpClient httpClient;

        private int counter = 0;

        public WebHook(
            IObjectContainer objectContainer,
            ISpecFlowOutputHelper specFlowOutputHelper,
            AteliexWebFactory webFactory)
        {
            this.objectContainer = objectContainer;

            this.specFlowOutputHelper = specFlowOutputHelper;

            counter++;

            specFlowOutputHelper.WriteLine($"WebHook --> {counter}");

            this.webFactory = webFactory.WithWebHostBuilder(builder => builder.ConfigureServices(services =>
            {

            }));

            httpClient = this.webFactory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("http://localhost")
            });

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [BeforeScenario]
        public void InitializeWeb(FeatureContext feature, ScenarioContext scenario)
        {
            if (feature.FeatureInfo.Title == "Cálculo (ou Calculadora) de Taxa de Marcação")
            {
                var calculoDeTaxaDeMarcacaoWeb = new CalculoDeTaxaDeMarcacaoWeb(httpClient);

                objectContainer.RegisterInstanceAs<CalculoDeTaxaDeMarcacao>(calculoDeTaxaDeMarcacaoWeb);
            }
            else if (feature.FeatureInfo.Title == "Cadastro de Modelos")
            {
                var cadastroDeModelosWeb = new CadastroDeModelosWeb(httpClient);

                objectContainer.RegisterInstanceAs<CadastroDeModelos>(cadastroDeModelosWeb);
            }
        }

        [BeforeTestRun]
        public static void BeforeTestRunInjection(ITestRunnerManager testRunnerManager, ITestRunner testRunner)
        {
            //All parameters are resolved from the test thread container automatically.
            //Since the global container is the base container of the test thread container, globally registered services can be also injected.

            //ITestRunManager from global container
            var location = testRunnerManager.TestAssembly.Location;

            //ITestRunner from test thread container
            var threadId = testRunner.ThreadId;
        }
    }
}
