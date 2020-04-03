using System;
using System.Transactions;

namespace Ateliex.Cadastro.Modelos.CadastroDeModelos
{
    public class ServicoDeCadastroDeModelos : ICadastroDeModelos
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IRepositorioDeModelos repositorioDeModelos;

        public ServicoDeCadastroDeModelos(IUnitOfWork unitOfWork, IRepositorioDeModelos repositorioDeModelos)
        {
            this.unitOfWork = unitOfWork;

            this.repositorioDeModelos = repositorioDeModelos;
        }

        public Modelo CadastraModelo(SolicitacaoDeCadastroDeModelo solicitacao)
        {
            unitOfWork.BeginTransaction();

            try
            {
                var modelo = new Modelo(solicitacao.Codigo, solicitacao.Nome);

                repositorioDeModelos.Add(modelo);

                unitOfWork.Commit();

                return modelo;
            }
            catch (Exception)
            {
                unitOfWork.Rollback();

                throw;
            }
        }

        public Recurso AdicionaRecursoDeModelo(SolicitacaoDeAdicaoDeRecursoDeModelo solicitacao)
        {
            throw new NotImplementedException();
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
