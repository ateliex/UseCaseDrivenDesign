using System.Collections.Generic;
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
        public CodigoDeModelo Id { get; private set; }

        public string Codigo { get; private set; }

        public string Nome { get; private set; }

        public decimal CustoDeProducao
        {
            get
            {
                var total = Recursos.Sum(p => p.CustoPorUnidade);

                return total;
            }
        }

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

        //private void Recursos_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        //{
        //    if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
        //    {
        //        var recurso = e.NewItems[0] as Recurso;

        //        recurso.Modelo = this;

        //        var total = Recursos.Count;

        //        //recurso.Id = total;
        //    }
        //}

        private Modelo()
        {

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
        public virtual Modelo Modelo { get; private set; }

        public int Id { get; private set; }

        public TipoDeRecurso Tipo { get; private set; }

        public string Descricao { get; private set; }

        public decimal Custo { get; private set; }

        public int Unidades { get; private set; }

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

        public Recurso(Modelo modelo, TipoDeRecurso tipo, string descricao, decimal custo, int unidades)
        {
            Modelo = modelo;

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

        private Recurso()
        {
            //PropertyChanged += Recurso_PropertyChanged;
        }

        //private static void Recurso_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    var recurso = sender as Recurso;

        //    if (recurso.Modelo == null) return;

        //    if (e.PropertyName == nameof(CustoPorUnidade))
        //    {
        //        recurso.Modelo.OnPropertyChanged("CustoDeProducao");
        //    }
        //}

        public string ModeloCodigo { get; private set; }
    }

    public interface IRepositorioDeModelos
    {
        Modelo ObtemModelo(CodigoDeModelo codigo);

        void Add(Modelo modelo);
    }
}
