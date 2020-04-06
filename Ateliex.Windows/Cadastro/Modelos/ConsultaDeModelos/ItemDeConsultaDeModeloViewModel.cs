using System.Collections.Generic;
using System.Linq;

namespace Ateliex.Cadastro.Modelos.ConsultaDeModelos
{
    public class ItemDeConsultaDeModeloViewModel
    {
        public bool Selected { get; set; }

        public Modelo Modelo { get; set; }

        public static ItemDeConsultaDeModeloViewModel From(Modelo modelo, IEnumerable<Modelo> selecteds)
        {
            var selected = selecteds.Any(p => p.Codigo == modelo.Codigo);

            var viewModel = new ItemDeConsultaDeModeloViewModel
            {
                Selected = selected,
                Modelo = modelo,
            };

            return viewModel;
        }
    }
}
