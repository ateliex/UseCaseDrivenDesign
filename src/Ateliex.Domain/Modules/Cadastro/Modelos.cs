using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DomainModel;
using System.Linq;
using System.Threading.Tasks;

namespace Ateliex.Modules.Cadastro.Modelos
{
    public class Modelo : Entity
    {
        #region Atributos

        [DisplayName("Código")]
        public CodigoDeModelo Codigo { get; internal set; }

        [DisplayName("Nome")]
        public string Nome { get; internal set; }

        [DisplayName("Custo de Produção")]
        public decimal CustoDeProducao { get; internal set; }

        [DisplayName("Recursos")]
        public virtual ICollection<Recurso> Recursos { get; }

        #endregion

        #region Comportamentos

        internal Modelo(CodigoDeModelo codigo, string nome)
        {
            Codigo = codigo;

            Nome = nome;

            Recursos = new HashSet<Recurso>();

            // Infraestrutura.

            CodigoDeModelo = codigo.Valor;
        }

        internal void AlteraCodigo(CodigoDeModelo codigo)
        {
            Codigo = codigo;
        }

        internal void AlteraNome(string nome)
        {
            Nome = nome;
        }

        internal Recurso AdicionaRecurso(TipoDeRecurso tipo, string descricao, decimal custo, decimal unidades)
        {
            var max = Recursos.Count;

            var nextId = ++max;

            var recurso = new Recurso(this, nextId, tipo, descricao, custo, unidades);

            Recursos.Add(recurso);

            CustoDeProducao += recurso.Custo;

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

        #endregion

        #region Infraestrutura

        [DisplayName("Código")]
        public string CodigoDeModelo { get; internal set; }

        internal Modelo()
        {
            Recursos = new HashSet<Recurso>();
        }

        #endregion
    }

    public class CodigoDeModelo : ValueObject
    {
        public string Valor { get; internal set; }

        public CodigoDeModelo(string valor)
        {
            Valor = valor;
        }

        public override string ToString()
        {
            return $"Modelo-{Valor}";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Valor;
        }

        internal CodigoDeModelo()
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
        #region Atributos

        [DisplayName("Modelo")]
        public virtual Modelo Modelo { get; internal set; }

        [DisplayName("Id")]
        public int Id { get; internal set; }

        [DisplayName("Tipo")]
        public TipoDeRecurso Tipo { get; internal set; }

        [DisplayName("Descrição")]
        public string Descricao { get; internal set; }

        [DisplayName("Custo")]
        public decimal Custo { get; internal set; }

        [DisplayName("Unidades")]
        public decimal Unidades { get; internal set; }

        [DisplayName("Custo por Unidade")]
        public decimal CustoPorUnidade { get; internal set; }

        #endregion

        #region Comportamentos

        internal Recurso(Modelo modelo, int id, TipoDeRecurso tipo, string descricao, decimal custo, decimal unidades)
        {
            Modelo = modelo;

            Id = id;

            Tipo = tipo;

            Descricao = descricao;

            Custo = custo;

            Unidades = unidades;

            var custoPorUnidade = CalculaCustoPorUnidade(custo, unidades);

            CustoPorUnidade = custoPorUnidade;

            // Infraestrutura.

            CodigoDeModelo = modelo.CodigoDeModelo;
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

            var custoPorUnidade = CalculaCustoPorUnidade(custo, Unidades);

            CustoPorUnidade = custoPorUnidade;
        }

        internal void DefineUnidades(decimal unidades)
        {
            Unidades = unidades;

            var custoPorUnidade = CalculaCustoPorUnidade(Custo, unidades);

            CustoPorUnidade = custoPorUnidade;
        }

        private decimal CalculaCustoPorUnidade(decimal custo, decimal unidades)
        {
            if (unidades == 0)
            {
                return 0;
            }
            else
            {
                return custo / unidades;
            }
        }

        #endregion

        #region Infraestrutura

        [Infrastructure]
        public string CodigoDeModelo { get; internal set; }

        internal Recurso()
        {

        }

        #endregion
    }

    public interface IRepositorioDeModelos
    {
        Task<Modelo> ObtemModelo(CodigoDeModelo codigo);

        void Add(Modelo modelo);

        void Update(Modelo modelo);

        void Remove(Modelo modelo);
    }
}
