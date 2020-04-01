using System;

namespace Ateliex.Decisoes.Comerciais.PlanejamentoComercial
{
    public class ServicoDePlanejamentoComercial : IPlanejamentoComercial
    {
        public ServicoDePlanejamentoComercial()
        {

        }

        public RespostaDeCriacaoDePlanoComercial CriaPlano(SolicitacaoDeCriacaoDePlanoComercial solicitacao)
        {
            throw new NotImplementedException();
        }

        public RespostaDeAdicaoDeCustoDePlanoComercial AdicionaCustoDePlanoComercial(SolicitacaoDeAdicaoDeCustoDePlanoComercial solicitacao)
        {
            throw new NotImplementedException();
        }

        public RespostaDeAdicaoDeItemDePlanoComercial AdicionaItemDePlanoComercial(SolicitacaoDeAdicaoDeItemDePlanoComercial solicitacao)
        {
            throw new NotImplementedException();
        }

        public void ExcluiCustoDePlanoComercial(string codigo, string descricao)
        {
            throw new NotImplementedException();
        }

        public void ExcluiItemDePlanoComercial(string codigo, int id)
        {
            throw new NotImplementedException();
        }

        public void ExcluiPlano(string codigo)
        {
            throw new NotImplementedException();
        }
    }
}
