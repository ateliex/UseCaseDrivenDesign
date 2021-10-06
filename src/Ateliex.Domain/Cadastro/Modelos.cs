using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DomainModel;
using System.Linq;

namespace Ateliex.Cadastro.Modelos
{
    public class CodigoDeModelo
    {
        public string Valor { get; }

        public CodigoDeModelo(string valor)
        {
            Valor = valor;
        }

        public override string ToString()
        {
            return $"Modelo-{Valor}";
        }
    }

    public class Modelo : Entity
    {
        [Description("Id")]
        public CodigoDeModelo Id { get; internal set; }

        [Description("Código")]
        public string Codigo { get; internal set; }

        [Description("Nome")]
        public string Nome { get; internal set; }

        [Description("Custo de Produção")]
        public decimal CustoDeProducao
        {
            get
            {
                var total = Recursos.Sum(p => p.CustoPorUnidade);

                return total;
            }
        }

        [Description("Recursos")]
        public virtual ICollection<Recurso> Recursos { get; }

        public Modelo(string codigo, string nome)
        {
            Id = new CodigoDeModelo(codigo);

            Codigo = codigo;

            Nome = nome;

            Recursos = new HashSet<Recurso>();

            //Recursos.CollectionChanged += Recursos_CollectionChanged;
        }

        internal void AlteraCodigo(CodigoDeModelo codigo)
        {
            Id = codigo;
        }

        internal void AlteraNome(string nome)
        {
            Nome = nome;
        }

        internal Recurso AdicionaRecurso(TipoDeRecurso tipo, string descricao, decimal custo, int unidades)
        {
            var max = Recursos.Count;

            var nextId = ++max;

            var recurso = new Recurso(this, nextId, tipo, descricao, custo, unidades);

            Recursos.Add(recurso);

            return recurso;
        }

        public Recurso ObtemRecurso(int idDeRecurso)
        {
            var recurso = Recursos.FirstOrDefault(recurso => recurso.Id == idDeRecurso);

            if (recurso == default(Recurso))
            {
                throw new ApplicationException();
            }

            return recurso;
        }

        //internal void Recursos_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        //{
        //    if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
        //    {
        //        var recurso = e.NewItems[0] as Recurso;

        //        recurso.Modelo = this;

        //        var total = Recursos.Count;

        //        //recurso.Id = total;
        //    }
        //}

        internal Modelo()
        {
            Recursos = new HashSet<Recurso>();
        }
    }

    public enum TipoDeRecurso
    {
        Material,
        Transporte,
        Humano
    }

    public class Recurso : Entity
    {
        [Description("Modelo")]
        public virtual Modelo Modelo { get; internal set; }

        [Description("Id")]
        public int Id { get; internal set; }

        [Description("Tipo")]
        public TipoDeRecurso Tipo { get; internal set; }

        [Description("Descrição")]
        public string Descricao { get; internal set; }

        [Description("Custo")]
        public decimal Custo { get; internal set; }

        [Description("Unidades")]
        public int Unidades { get; internal set; }

        [Description("Custo por Unidade")]
        public decimal CustoPorUnidade
        {
            get
            {
                if (Unidades == 0)
                {
                    return 0;
                }
                else
                {
                    var custoPorUnidade = Custo / Unidades;

                    return custoPorUnidade;
                }
            }
        }

        public Recurso(Modelo modelo, int id, TipoDeRecurso tipo, string descricao, decimal custo, int unidades)
        {
            Modelo = modelo;

            Id = id;

            Tipo = tipo;

            Descricao = descricao;

            Custo = custo;

            Unidades = unidades;
        }

        internal void DefineTipo(TipoDeRecurso tipo)
        {
            Tipo = tipo;
        }

        internal void DefineDescricao(string descricao)
        {
            Descricao = descricao;
        }

        internal void DefineCusto(decimal custo)
        {
            Custo = custo;
        }

        internal void DefineUnidades(int unidades)
        {
            Unidades = unidades;
        }

        internal Recurso()
        {
            //PropertyChanged += Recurso_PropertyChanged;
        }

        //internal static void Recurso_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    var recurso = sender as Recurso;

        //    if (recurso.Modelo == null) return;

        //    if (e.PropertyName == nameof(CustoPorUnidade))
        //    {
        //        recurso.Modelo.OnPropertyChanged("CustoDeProducao");
        //    }
        //}

        [Infrastructure]
        public string ModeloCodigo { get; internal set; }
    }

    public interface IRepositorioDeModelos
    {
        Modelo ObtemModelo(CodigoDeModelo codigo);

        void Add(Modelo modelo);

        void Update(Modelo modelo);

        void Remove(Modelo modelo);
    }
}
