using System;

namespace Ateliex.Modulos.Decisoes.Comerciais.PlanejamentoComercial
{
    public class ServicoDePlanejamentoComercial : IPlanejamentoComercial
    {
        public ServicoDePlanejamentoComercial()
        {

        }

        public PlanoComercial CriaPlano(SolicitacaoDeCriacaoDePlanoComercial solicitacao)
        {
            throw new NotImplementedException();
        }

        public Custo AdicionaCustoDePlanoComercial(SolicitacaoDeAdicaoDeCustoDePlanoComercial solicitacao)
        {
            throw new NotImplementedException();
        }

        public ItemDePlanoComercial AdicionaItemDePlanoComercial(SolicitacaoDeAdicaoDeItemDePlanoComercial solicitacao)
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
