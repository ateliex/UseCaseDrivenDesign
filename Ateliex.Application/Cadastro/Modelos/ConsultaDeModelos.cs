namespace Ateliex.Cadastro.Modelos.ConsultaDeModelos
{
    public interface IConsultaDeModelos
    {
        ResultadoDaConsultaDeModelos ConsultaModelos(ParametrosDeConsultaDeModelos parametros);

        Modelo ObtemModelo(CodigoDeModelo codigo);
    }

    public class ParametrosDeConsultaDeModelos
    {
        public string Nome { get; set; }

        public long PrimeiraPagina { get; set; }

        public long TamanhoDaPagina { get; set; }
    }

    public class ResultadoDaConsultaDeModelos
    {
        public ItemDeConsultaDeModelos[] Itens { get; internal set; }
    }

    public class ItemDeConsultaDeModelos
    {
        public string Codigo { get; internal set; }

        public string Nome { get; internal set; }
    }
}
