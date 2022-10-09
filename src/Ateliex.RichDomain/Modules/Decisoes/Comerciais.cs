using Ateliex.Modules.Cadastro.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Ateliex.Modules.Decisoes.Comerciais
{
    public class PlanoComercial
    {
        public string Codigo { get; internal set; }

        public string Nome { get; internal set; }

        public DateTime Data { get; internal set; }

        public decimal RendaBrutaMensal { get; internal set; }

        public decimal RendaBrutaMensalCalculada
        {
            get
            {
                return 0;
            }
        }

        public decimal CustoFixoTotal
        {
            get
            {
                var total = Custos.Where(p => p.Tipo == TipoDeCusto.Fixo).Sum(p => p.Valor);

                return total;
            }
        }

        public decimal CustoFixoPercentualTotal
        {
            get
            {
                var total = Custos.Where(p => p.Tipo == TipoDeCusto.Fixo).Sum(p => p.PercentualCalculado);

                return total;

                //var percentual = 0m;

                //if (RendaBrutaMensal != 0)
                //{
                //    percentual = CustoFixoTotal / RendaBrutaMensal;
                //}

                //return percentual;
            }
        }

        public decimal CustoVariavelTotal
        {
            get
            {
                var total = Custos.Where(p => p.Tipo == TipoDeCusto.Variavel).Sum(p => p.ValorCalculado);

                return total;
            }
        }

        public decimal CustoVariavelPercentualTotal
        {
            get
            {
                var total = Custos.Where(p => p.Tipo == TipoDeCusto.Variavel).Sum(p => p.Percentual);

                return total;
            }
        }

        public decimal CustoPercentualTotal
        {
            get
            {
                var total = CustoFixoPercentualTotal + CustoVariavelTotal;

                return total;
            }
        }

        public virtual ICollection<Custo> Custos { get; }

        public virtual ICollection<ItemDePlanoComercial> Itens { get; }

        public PlanoComercial(string id, string nome, decimal rendaBrutaMensal)
        {
            Codigo = id;

            Nome = nome;

            RendaBrutaMensal = rendaBrutaMensal;

            Custos = new HashSet<Custo>();

            Itens = new HashSet<ItemDePlanoComercial>();
        }

        public void DefineNome(string nome)
        {
            Nome = nome;
        }

        public void DefineData(DateTime data)
        {
            Data = data;
        }

        public void DefineRendaBrutaMensal(decimal rendaBrutaMensal)
        {
            RendaBrutaMensal = rendaBrutaMensal;
        }

        internal PlanoComercial()
        {
            Custos = new HashSet<Custo>();

            Itens = new HashSet<ItemDePlanoComercial>();
        }

        public Custo AdicionaCusto(TipoDeCusto tipo, string descricao)
        {
            var model = new Custo(this, tipo, descricao);

            Custos.Add(model);

            return model;
        }

        public void RemoveCusto(Custo custo)
        {
            Custos.Remove(custo);
        }

        public bool ExisteItemDoModelo(Modelo modelo)
        {
            var existe = Itens.Any(p => p.Modelo.CodigoDeModelo == modelo.CodigoDeModelo);

            return existe;
        }

        public ItemDePlanoComercial AdicionaItem(Modelo modelo)
        {
            var model = new ItemDePlanoComercial(this, modelo);

            Itens.Add(model);

            return model;
        }

        public void RemoveItem(ItemDePlanoComercial item)
        {
            Itens.Remove(item);
        }
    }

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum TipoDeCusto
    {
        Fixo,
        [Description("Variável")]
        Variavel,
    }

    public class Custo
    {
        public PlanoComercial PlanoComercial { get; internal set; }

        public int Id { get; set; }

        public TipoDeCusto Tipo { get; internal set; }

        public string Descricao { get; internal set; }

        public decimal Valor { get; internal set; }

        public decimal Percentual { get; internal set; }

        public decimal ValorCalculado
        {
            get
            {
                if (Tipo == TipoDeCusto.Fixo)
                {
                    return Valor;
                }
                else if (Tipo == TipoDeCusto.Variavel)
                {
                    var valorCalculado = (PlanoComercial.RendaBrutaMensal * Percentual) / 100;

                    return valorCalculado;
                }
                else
                {
                    throw new InvalidCastException();
                }
            }
        }

        public decimal PercentualCalculado
        {
            get
            {
                if (Tipo == TipoDeCusto.Fixo)
                {
                    var percentualCalculado = 0m;

                    if (PlanoComercial.RendaBrutaMensal != 0)
                    {
                        percentualCalculado = (Valor / PlanoComercial.RendaBrutaMensal) * 100;
                    }

                    return percentualCalculado;
                }
                else if (Tipo == TipoDeCusto.Variavel)
                {
                    return Percentual;
                }
                else
                {
                    throw new InvalidCastException();
                }
            }
        }

        public Custo(PlanoComercial planoComercial, TipoDeCusto tipo, string descricao)
        {
            PlanoComercial = planoComercial;

            Tipo = tipo;

            Descricao = descricao;
        }

        public void DefineTipo(TipoDeCusto tipo)
        {
            Tipo = tipo;
        }

        public void DefineDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public void DefineValor(decimal valor)
        {
            Valor = valor;
        }

        public void DefinePercentual(decimal percentual)
        {
            Percentual = percentual;
        }

        internal Custo()
        {

        }

        public string PlanoComercialCodigo { get; internal set; }
    }

    public class ItemDePlanoComercial
    {
        public virtual PlanoComercial PlanoComercial { get; internal set; }

        public virtual Modelo Modelo { get; internal set; }

        public decimal CustoDeProducao { get { return Modelo.CustoDeProducao; } }

        public decimal? CustoDeProducaoSugerido
        {
            get
            {
                var custo = 0m;

                if (PrecoDeVendaDesejado.HasValue && CustoDeProducao != 0)
                {
                    custo = PrecoDeVendaDesejado.Value / CustoDeProducao;
                }

                return custo;
            }
        }

        public decimal Margem { get; internal set; }

        public decimal MargemPercentual { get; internal set; }

        public decimal MargemCalculada
        {
            get
            {
                var valor = MargemPercentual * PlanoComercial.RendaBrutaMensal;

                return valor;
            }
        }

        public decimal MargemPercentualCalculada
        {
            get
            {
                return 0;
            }
        }

        public decimal TaxaDeMarcacao
        {
            get
            {
                return 100 / (100 - (PlanoComercial.CustoFixoPercentualTotal + PlanoComercial.CustoVariavelPercentualTotal + MargemPercentual));
            }
        }

        public decimal? TaxaDeMarcacaoSugerida { get; internal set; }

        public decimal PrecoDeVenda
        {
            get
            {
                decimal precoDeVenda;

                var taxaDeMarcacao = TaxaDeMarcacao;

                var custoDeProducao = CustoDeProducao;

                ///////////////////////////////////////////////////
                precoDeVenda = taxaDeMarcacao * custoDeProducao; //
                ///////////////////////////////////////////////////

                return precoDeVenda;
            }
        }

        public decimal? PrecoDeVendaDesejado { get; internal set; }

        public ItemDePlanoComercial(PlanoComercial planoComercial, Modelo modelo)
        {
            PlanoComercial = planoComercial;

            Modelo = modelo;
        }

        public ItemDePlanoComercial(decimal margem)
        {
            Margem = margem;
        }

        public void DefineMargem(decimal margem)
        {
            Margem = margem;
        }

        public void DefineMargemPercentual(decimal margemPercentual)
        {
            MargemPercentual = margemPercentual;
        }

        public void SugereTaxaDeMarcacao(decimal? taxaDeMarcacaoSugerida)
        {
            TaxaDeMarcacaoSugerida = taxaDeMarcacaoSugerida;
        }

        public void DefinePrecoDeVendaDesejado(decimal valor)
        {
            PrecoDeVendaDesejado = valor;

            var taxaDeMarcacaoSugerida = PrecoDeVendaDesejado / CustoDeProducao;

            SugereTaxaDeMarcacao(taxaDeMarcacaoSugerida);
        }

        internal ItemDePlanoComercial()
        {

        }

        public string PlanoComercialCodigo { get; internal set; }

        public string ModeloCodigo { get; internal set; }
    }

    public interface IRepositorioDePlanosComerciais
    {
        PlanoComercial ObtemPlanoComercial(string id);

        void Add(PlanoComercial planoComercial);

        void Update(PlanoComercial planoComercial);

        void Remove(PlanoComercial planoComercial);
    }
}
