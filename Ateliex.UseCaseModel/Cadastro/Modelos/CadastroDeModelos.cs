
namespace Ateliex.Cadastro.Modelos.CadastroDeModelos
{
    public interface ICadastroDeModelos
    {
        RespostaDeCadastroDeModelo CadastraModelo(SolicitacaoDeCadastroDeModelo solicitacao);
    }

    public class SolicitacaoDeCadastroDeModelo
    {
        public string Nome { get; }
    }

    public class RespostaDeCadastroDeModelo
    {
        CodigoDeModelo CodigoCadastrado { get; }
    }
}
