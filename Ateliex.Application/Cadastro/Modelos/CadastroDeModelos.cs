﻿namespace Ateliex.Cadastro.Modelos.CadastroDeModelos
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
        public string Codigo { get; set; }

        public virtual TipoDeRecurso Tipo { get; set; }

        public virtual string Descricao { get; set; }

        public decimal Custo { get; set; }

        public int Unidades { get; set; }
    }
}
