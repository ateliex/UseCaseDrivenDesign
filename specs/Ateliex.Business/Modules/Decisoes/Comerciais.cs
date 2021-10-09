using Ateliex.Modules.Cadastro.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ateliex.Modules.Decisoes.Comerciais
{
    public class PlanoComercial
    {
        string Codigo { get; }
        decimal CustoFixoPercentualTotal { get; }
        decimal CustoFixoTotal { get; }
        decimal CustoPercentualTotal { get; }
        ICollection<Custo> Custos { get; }
        decimal CustoVariavelPercentualTotal { get; }
        decimal CustoVariavelTotal { get; }
        DateTime Data { get; }
        ICollection<ItemDePlanoComercial> Itens { get; }
        string Nome { get; }
        decimal RendaBrutaMensal { get; }
        decimal RendaBrutaMensalCalculada { get; }

        //Custo AdicionaCusto(TipoDeCusto tipo, string descricao);
        //ItemDePlanoComercial AdicionaItem(Modelo modelo);
        //void DefineData(DateTime data);
        //void DefineNome(string nome);
        //void DefineRendaBrutaMensal(decimal rendaBrutaMensal);
        //bool ExisteItemDoModelo(Modelo modelo);
        //void RemoveCusto(Custo custo);
        //void RemoveItem(ItemDePlanoComercial item);
    }

    public enum TipoDeCusto
    {
        Fixo,
        Variavel,
    }

    public class Custo
    {
        string Descricao { get; }
        int Id { get; set; }
        decimal Percentual { get; }
        decimal PercentualCalculado { get; }
        PlanoComercial PlanoComercial { get; }
        string PlanoComercialCodigo { get; }
        TipoDeCusto Tipo { get; }
        decimal Valor { get; }
        decimal ValorCalculado { get; }

        //void DefineDescricao(string descricao);
        //void DefinePercentual(decimal percentual);
        //void DefineTipo(TipoDeCusto tipo);
        //void DefineValor(decimal valor);
    }

    public class ItemDePlanoComercial
    {
        decimal CustoDeProducao { get; }
        decimal? CustoDeProducaoSugerido { get; }
        decimal Margem { get; }
        decimal MargemCalculada { get; }
        decimal MargemPercentual { get; }
        decimal MargemPercentualCalculada { get; }
        Modelo Modelo { get; }
        string ModeloCodigo { get; }
        PlanoComercial PlanoComercial { get; }
        string PlanoComercialCodigo { get; }
        decimal PrecoDeVenda { get; }
        decimal? PrecoDeVendaDesejado { get; }
        decimal TaxaDeMarcacao { get; }
        decimal? TaxaDeMarcacaoSugerida { get; }

        //void DefineMargem(decimal margem);
        //void DefineMargemPercentual(decimal margemPercentual);
        //void DefinePrecoDeVendaDesejado(decimal valor);
        //void SugereTaxaDeMarcacao(decimal? taxaDeMarcacaoSugerida);
    }
}
