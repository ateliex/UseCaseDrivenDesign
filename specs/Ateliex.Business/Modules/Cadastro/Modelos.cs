namespace Ateliex.Modules.Cadastro.Modelos
{
    public class CodigoDeModelo
    {
        public string Valor { get; set; }
    }

    public class Modelo
    {
        public string Codigo { get; set; }
        
        public decimal CustoDeProducao { get; set; }
        
        public CodigoDeModelo Id { get; set; }
        
        public string Nome { get; set; }
        
        public Recurso[] Recursos { get; set; }
    }

    public enum TipoDeRecurso
    {
        Material,
        Transporte,
        Humano
    }

    public class Recurso
    {
        public decimal Custo { get; set; }
        
        public decimal CustoPorUnidade { get; set; }
        
        public string Descricao { get; set; }
        
        public int Id { get; set; }
        
        public Modelo Modelo { get; set; }
        
        public string ModeloCodigo { get; set; }
        
        public TipoDeRecurso Tipo { get; set; }
        
        public decimal Unidades { get; set; }
    }
}
