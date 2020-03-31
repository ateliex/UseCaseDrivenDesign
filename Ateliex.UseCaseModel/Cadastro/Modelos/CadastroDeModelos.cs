namespace Ateliex.Cadastro.Modelos.CadastroDeModelos
{
    public interface CadastroDeModelos
    {
        RespostaDeCadastroDeModelo CadastraModelo(SolicitacaoDeCadastroDeModelo solicitacao);
    }

    public interface SolicitacaoDeCadastroDeModelo
    {
        string Nome { get; }
    }

    public interface RespostaDeCadastroDeModelo
    {
        CodigoDeModelo CodigoCadastrado { get; }
    }
}
