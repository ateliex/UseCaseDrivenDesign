using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Ateliex.Modules.Cadastro.Modelos
{
    public class CadastroDeModelosWeb : CadastroDeModelos
    {
        private readonly HttpClient httpClient;

        public CadastroDeModelosWeb(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Modelo CadastraModelo(Modelo modelo)
        {
            var path = new Uri("/cadastro/modelos/cadastro-de-modelos", UriKind.Relative);

            var content = JsonSerializer.Serialize(modelo);

            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");

            var httpResponse = httpClient.PostAsync(path, httpContent).ConfigureAwait(false).GetAwaiter().GetResult();

            //httpResponse.EnsureSuccessStatusCode();

            var response = httpResponse.Content.ReadAsStringAsync().Result;

            var modeloCadastrado = JsonSerializer.Deserialize<Modelo>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return modeloCadastrado;
        }

        public Modelo AdicionaRecursoDeModelo(Recurso recurso)
        {
            var path = new Uri($"/cadastro/modelos/{recurso.Modelo.Codigo}/recursos/adicao-de-recursos", UriKind.Relative);

            var content = JsonSerializer.Serialize(recurso);

            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");

            var httpResponse = httpClient.PostAsync(path, httpContent).ConfigureAwait(false).GetAwaiter().GetResult();

            //httpResponse.EnsureSuccessStatusCode();

            var response = httpResponse.Content.ReadAsStringAsync().Result;

            var recursoAdicionado = JsonSerializer.Deserialize<Recurso>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var modeloComRecursoAdicionado = recursoAdicionado.Modelo;

            modeloComRecursoAdicionado.Recursos = new Recurso[]
            {
                recursoAdicionado
            };

            return modeloComRecursoAdicionado;
        }

        public void RemoveRecursoDeModelo(string codigo, string descricao)
        {
            throw new NotImplementedException();
        }

        public void RemoveModelo(string codigo)
        {
            throw new NotImplementedException();
        }
    }
}
