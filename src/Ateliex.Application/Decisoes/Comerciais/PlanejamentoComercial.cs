using System;

namespace Ateliex.Decisoes.Comerciais.PlanejamentoComercial
{
    public interface IPlanejamentoComercial
    {
        PlanoComercial CriaPlano(SolicitacaoDeCriacaoDePlanoComercial solicitacao);

        Custo AdicionaCustoDePlanoComercial(SolicitacaoDeAdicaoDeCustoDePlanoComercial solicitacao);

        ItemDePlanoComercial AdicionaItemDePlanoComercial(SolicitacaoDeAdicaoDeItemDePlanoComercial solicitacao);

        void ExcluiCustoDePlanoComercial(string codigo, string descricao);

        void ExcluiItemDePlanoComercial(string codigo, int id);

        void ExcluiPlano(string codigo);

    }

    public class SolicitacaoDeCriacaoDePlanoComercial
    {
        public string Codigo { get; set; }

        public string Nome { get; set; }

        public DateTime Data { get; set; }

        public decimal RendaBrutaMensal { get; set; }
    }

    public class SolicitacaoDeAdicaoDeCustoDePlanoComercial
    {
        public string Codigo { get; set; }

        public TipoDeCusto Tipo { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public decimal Percentual { get; set; }
    }

    public class SolicitacaoDeAdicaoDeItemDePlanoComercial
    {
        public string Codigo { get; set; }

        public int Id { get; set; }

        public string CodigoDeModelo { get; set; }

        public decimal Margem { get; set; }

        public decimal MargemPercentual { get; set; }

        public decimal? TaxaDeMarcacaoSugerida { get; set; }

        public decimal? PrecoDeVendaDesejado { get; set; }
    }
}
