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
            unitOfWork.BeginTransaction();

            try
            {
                var codigo = new CodigoDeModelo(solicitacao.Codigo);

                var modelo = repositorioDeModelos.ObtemModelo(codigo);

                var recurso = modelo.AdicionaRecurso(solicitacao.Tipo, solicitacao.Descricao, solicitacao.Custo, solicitacao.Unidades);

                repositorioDeModelos.Update(modelo);

                unitOfWork.Commit();

                return recurso;
            }
            catch (Exception)
            {
                unitOfWork.Rollback();

                throw;
            }
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
