using System.Threading.Tasks;

namespace Ateliex.Modules.Cadastro.Modelos
{
    public interface IConsultaDeModelos
    {
        Task<Modelo[]> ConsultaModelos(SolicitacaoDeConsultaDeModelos solicitacao);

        Task<Modelo> ObtemModelo(CodigoDeModelo codigo);
    }

    public class SolicitacaoDeConsultaDeModelos
    {
        public string Nome { get; set; }

        public long PrimeiraPagina { get; set; }

        public long TamanhoDaPagina { get; set; }
    }
}