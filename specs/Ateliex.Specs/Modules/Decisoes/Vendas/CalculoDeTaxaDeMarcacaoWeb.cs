using System;
using System.Net.Http;
using System.Text;

namespace Ateliex.Modules.Decisoes.Vendas
{
    public class CalculoDeTaxaDeMarcacaoWeb : CalculoDeTaxaDeMarcacao
    {
        private readonly HttpClient httpClient;

        public CalculoDeTaxaDeMarcacaoWeb(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public decimal CalculaTaxaDeMarcacao(decimal cf, decimal cv, decimal ml)
        {
            var path = new Uri("/api/vendas/calculoDeTaxaDeMarcacao", UriKind.Relative);

            var content = $"{{ cf: {cf} }}";

            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");

            var httpResponse = httpClient.PostAsync(path, httpContent).ConfigureAwait(false).GetAwaiter().GetResult();

            //httpResponse.EnsureSuccessStatusCode();

            var response = httpResponse.Content.ReadAsStringAsync().Result;

            var tm = decimal.Parse(response);

            return tm;
        }
    }
}
