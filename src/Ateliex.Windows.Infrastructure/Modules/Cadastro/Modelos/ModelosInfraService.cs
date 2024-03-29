﻿using System.Threading.Tasks;

namespace Ateliex.Modules.Cadastro.Modelos
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

        public async Task<Modelo[]> ConsultaModelos(SolicitacaoDeConsultaDeModelos solicitacao)
        {
            var modelos = await db.ConsultaModelos(solicitacao);

            return modelos;
        }

        public Modelo[] ObtemModelos()
        {
            var modelos = db.ObtemModelos();

            return modelos;
        }

        public async Task<Modelo> ObtemModelo(CodigoDeModelo codigo)
        {
            var modelo = await db.ObtemModelo(codigo);

            return modelo;
        }

        public void Add(Modelo modelo)
        {
            db.Add(modelo);

            var solicitacao = new SolicitacaoDeCadastroDeModelo
            {
                Nome = modelo.Nome
            };

            http.Add(modelo);
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

            http.Remove(modelo);
        }
    }
}
