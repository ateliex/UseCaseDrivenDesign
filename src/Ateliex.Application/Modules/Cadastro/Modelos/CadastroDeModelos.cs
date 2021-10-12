namespace Ateliex.Modules.Cadastro.Modelos
{
    public interface ICadastroDeModelos
    {
        Modelo CadastraModelo(SolicitacaoDeCadastroDeModelo solicitacao);

        Recurso AdicionaRecursoDeModelo(SolicitacaoDeAdicaoDeRecursoDeModelo solicitacao);

        void RemoveRecursoDeModelo(string codigo, string descricao);

        void RemoveModelo(string codigo);
    }

    public class SolicitacaoDeCadastroDeModelo
    {
        public string Codigo { get; set; }

        public string Nome { get; set; }
    }

    public class SolicitacaoDeAdicaoDeRecursoDeModelo
    {
        public string ModeloCodigo { get; set; }

        public TipoDeRecurso Tipo { get; set; }

        public string Descricao { get; set; }

        public decimal Custo { get; set; }

        public decimal Unidades { get; set; }
    }
}
