using System;

namespace Ateliex.Decisoes.Comerciais.ConsultaDePlanosComerciais
{
    public interface IConsultaDePlanosComerciais
    {
        RespostaDeConsultaDePlanosComerciais ConsultaPlanosComerciais(ParametrosDeConsultaDePlanosComerciais parametros);

        PlanoComercial[] ObtemObservavelDePlanosComerciais();
    }

    public class ParametrosDeConsultaDePlanosComerciais
    {

    }

    public class RespostaDeConsultaDePlanosComerciais
    {
        public ItemDeConsultaDePlanosComerciais[] Itens { get; internal set; }
    }

    public class ItemDeConsultaDePlanosComerciais
    {
        public string Codigo { get; internal set; }

        public string Nome { get; internal set; }

        public DateTime Data { get; internal set; }

        public decimal RendaBrutaMensal { get; internal set; }
    }
}
