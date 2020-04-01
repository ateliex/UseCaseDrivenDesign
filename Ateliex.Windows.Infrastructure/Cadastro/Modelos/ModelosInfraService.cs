using Ateliex.Cadastro.Modelos.CadastroDeModelos;
using Ateliex.Cadastro.Modelos.ConsultaDeModelos;

namespace Ateliex.Cadastro.Modelos
{
    public class ModelosInfraService : IConsultaDeModelos, IRepositorioDeModelos
    {
        private readonly ModelosDbService db;

        private readonly ModelosHttpService http;

        public ModelosInfraService(ModelosDbService db, ModelosHttpService http)
        {
            this.db = db;

            this.http = http;
        }

        public ResultadoDaConsultaDeModelos ConsultaModelos(ParametrosDeConsultaDeModelos parametros)
        {
            var resposta = db.ConsultaModelos(parametros);

            return resposta;
        }

        public Modelo[] ObtemModelos()
        {
            var modelos = db.ObtemModelos();

            return modelos;
        }

        public Modelo ObtemModelo(CodigoDeModelo codigo)
        {
            var modelo = db.ObtemModelo(codigo);

            return modelo;
        }

        public void Add(Modelo modelo)
        {
            db.Add(modelo);

            var solicitacao = new SolicitacaoDeCadastroDeModelo
            {
                Nome = modelo.Nome
            };

            http.CadastraModelo(solicitacao);
        }

        public void Update(Modelo modelo)
        {
            db.Update(modelo);

            //http.AdicionaRecursoDeModelo(solicitacao);

            // TODO.
        }

        public void Remove(Modelo modelo)
        {
            db.Remove(modelo);

            http.RemoveModelo(modelo.Codigo);
        }
    }
}
