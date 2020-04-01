using Ateliex.Cadastro.Modelos.CadastroDeModelos;
using Ateliex.Cadastro.Modelos.ConsultaDeModelos;
using System;

namespace Ateliex.Cadastro.Modelos
{
    public class ModelosHttpService : IConsultaDeModelos, ICadastroDeModelos
    {
        public ModelosHttpService()
        {

        }

        public ResultadoDaConsultaDeModelos ConsultaModelos(ParametrosDeConsultaDeModelos parametros)
        {
            throw new NotImplementedException();
        }

        public RespostaDeAdicaoDeRecursoDeModelo AdicionaRecursoDeModelo(SolicitacaoDeAdicaoDeRecursoDeModelo solicitacao)
        {
            throw new NotImplementedException();
        }

        public RespostaDeCadastroDeModelo CadastraModelo(SolicitacaoDeCadastroDeModelo solicitacao)
        {
            var resposta = new RespostaDeCadastroDeModelo
            {

            };

            return resposta;
        }

        public void RemoveModelo(string codigo)
        {
            
        }

        public void RemoveRecursoDeModelo(string codigo, string descricao)
        {
            
        }
    }
}
