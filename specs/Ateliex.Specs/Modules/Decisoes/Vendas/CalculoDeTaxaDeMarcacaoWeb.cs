using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Ateliex.Modules.Decisoes.Vendas
{
    public class CalculoDeTaxaDeMarcacaoWeb : CalculoDeTaxaDeMarcacao
    {
        private readonly WebApplicationFactory<Startup> webFactory;

        private readonly HttpClient httpClient;

        public CalculoDeTaxaDeMarcacaoWeb(AteliexWebFactory webFactory)
        {
            this.webFactory = webFactory.WithWebHostBuilder(builder => builder.ConfigureServices(services =>
            {

            }));

            httpClient = webFactory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("http://localhost")
            });
        }

        public decimal CalculaTaxaDeMarcacao(decimal cf, decimal cv, decimal ml)
        {
            var path = new Uri("/api/vendas/calculoDeTaxaDeMarcacao", UriKind.Relative);

            var httpContent = new StringContent("", Encoding.UTF8, "application/json");

            var httpResponse = httpClient.PostAsync(path, httpContent).ConfigureAwait(false).GetAwaiter().GetResult();

            httpResponse.EnsureSuccessStatusCode();

            var content = httpResponse.Content.ReadAsStringAsync().Result;

            var tm = decimal.Parse(content);

            return tm;
        }
    }
}
