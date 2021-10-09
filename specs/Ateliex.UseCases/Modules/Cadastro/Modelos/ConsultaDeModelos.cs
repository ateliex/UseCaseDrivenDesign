namespace Ateliex.Modules.Cadastro.Modelos
{
    public interface ConsultaDeModelos
    {
        Modelo[] ConsultaModelos(SolicitacaoDeConsultaDeModelos solicitacao);

        Modelo ObtemModelo(CodigoDeModelo codigo);
    }

    public class SolicitacaoDeConsultaDeModelos
    {
        public string Nome { get; set; }

        public long PrimeiraPagina { get; set; }

        public long TamanhoDaPagina { get; set; }
    }
}