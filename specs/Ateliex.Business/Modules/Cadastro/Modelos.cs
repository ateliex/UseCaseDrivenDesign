using System.Collections.Generic;

namespace Ateliex.Modules.Cadastro.Modelos
{
    public class CodigoDeModelo
    {
        string Valor { get; }

        //string ToString();
    }

    public class Modelo
    {
        string Codigo { get; }
        decimal CustoDeProducao { get; }
        CodigoDeModelo Id { get; }
        string Nome { get; }
        ICollection<Recurso> Recursos { get; }

        //Recurso ObtemRecurso(int idDeRecurso);
    }

    public enum TipoDeRecurso
    {
        Material,
        Transporte,
        Humano
    }

    public class Recurso
    {
        decimal Custo { get; }
        decimal CustoPorUnidade { get; }
        string Descricao { get; }
        int Id { get; }
        Modelo Modelo { get; }
        string ModeloCodigo { get; }
        TipoDeRecurso Tipo { get; }
        int Unidades { get; }
    }
}
