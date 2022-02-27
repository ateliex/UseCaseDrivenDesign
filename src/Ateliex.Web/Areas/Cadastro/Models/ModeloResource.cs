using System.ComponentModel;

namespace Ateliex.Areas.Cadastro.Models
{
    public class ModeloResource
    {
        [DisplayName("Código")]
        public string Id { get; set; }

        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Custo de Produção")]
        public decimal CustoDeProducao { get; set; }
    }
}
