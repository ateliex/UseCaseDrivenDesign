using Ateliex.Modules.Cadastro.Modelos;
using System;
using System.Collections.Generic;

namespace Ateliex.Modules.Decisoes.Comerciais
{
    public class PlanoComercial
    {
        public string Codigo { get; set; }
        
        public decimal CustoFixoPercentualTotal { get; set; }
        
        public decimal CustoFixoTotal { get; set; }
        
        public decimal CustoPercentualTotal { get; set; }
        
        public ICollection<Custo> Custos { get; set; }
        
        public decimal CustoVariavelPercentualTotal { get; set; }
        
        public decimal CustoVariavelTotal { get; set; }
        
        public DateTime Data { get; set; }
        
        public ItemDePlanoComercial[] Itens { get; set; }
        
        public string Nome { get; set; }
        
        public decimal RendaBrutaMensal { get; set; }
        
        public decimal RendaBrutaMensalCalculada { get; set; }
    }

    public enum TipoDeCusto
    {
        Fixo,
        Variavel,
    }

    public class Custo
    {
        public string Descricao { get; set; }
        
        public int Id { get; set; }
        
        public decimal Percentual { get; set; }
        
        public decimal PercentualCalculado { get; set; }
        
        public PlanoComercial PlanoComercial { get; set; }
        
        public string PlanoComercialCodigo { get; set; }
        
        public TipoDeCusto Tipo { get; set; }
        
        public decimal Valor { get; set; }
        
        public decimal ValorCalculado { get; set; }
    }

    public class ItemDePlanoComercial
    {
        public decimal CustoDeProducao { get; set; }
        
        public decimal? CustoDeProducaoSugerido { get; set; }
        
        public decimal Margem { get; set; }
        
        public decimal MargemCalculada { get; set; }
        
        public decimal MargemPercentual { get; set; }
        
        public decimal MargemPercentualCalculada { get; set; }
        
        public Modelo Modelo { get; set; }
        
        public string ModeloCodigo { get; set; }
        
        public PlanoComercial PlanoComercial { get; set; }
        
        public string PlanoComercialCodigo { get; set; }
        
        public decimal PrecoDeVenda { get; set; }
        
        public decimal? PrecoDeVendaDesejado { get; set; }
        
        public decimal TaxaDeMarcacao { get; set; }
        
        public decimal? TaxaDeMarcacaoSugerida { get; set; }
    }

    public class Modelo
    {
        public string Codigo { get; set; }
        
        public decimal CustoDeProducao { get; set; }
        
        public CodigoDeModelo Id { get; set; }
        
        public string Nome { get; set; }
    }
}
