namespace Ateliex.Cadastro.Modelos.ConsultaDeModelos
{
    public interface IConsultaDeModelos
    {
        ResultadoDaConsultaDeModelos ConsultaModelos(ParametrosDeConsultaDeModelos parametros);
    }

    public class ParametrosDeConsultaDeModelos
    {

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
