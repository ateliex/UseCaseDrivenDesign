using System.ComponentModel;

namespace Ateliex.Areas.Cadastro.Models
{
    public class Modelo
    {
        [Description("Id")]
        public string Id { get; set; }

        [Description("Código")]
        public string Codigo { get; set; }

        [Description("Nome")]
        public string Nome { get; set; }

        [Description("Custo de Produção")]
        public decimal CustoDeProducao { get; set; }

    }
}
