using Ateliex.Modules.Decisoes.Vendas;
using BoDi;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using Xunit;

namespace Ateliex.Hooks
{
    [Binding]
    public class WebHook : IClassFixture<AteliexWebFactory>
    {
        private readonly IObjectContainer objectContainer;

        private readonly AteliexWebFactory webFactory;

        public WebHook(
            IObjectContainer objectContainer,
            AteliexWebFactory webFactory)
        {
            this.objectContainer = objectContainer;

            this.webFactory = webFactory;
        }

        [BeforeScenario]
        public void InitializeWeb(ScenarioContext scenario)
        {
            var calculoDeTaxaDeMarcacaoWeb = new CalculoDeTaxaDeMarcacaoWeb(webFactory);

            objectContainer.RegisterInstanceAs<CalculoDeTaxaDeMarcacao>(calculoDeTaxaDeMarcacaoWeb);
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
