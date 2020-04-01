using System.Collections.Generic;
using System.Linq;

namespace Ateliex.Cadastro.Modelos.ConsultaDeModelos
{
    public class ItemDeConsultaDeModeloViewModel
    {
        public bool Selected { get; set; }

        public ItemDeConsultaDeModelos Modelo { get; set; }

        public static ItemDeConsultaDeModeloViewModel From(ItemDeConsultaDeModelos modelo, IEnumerable<ItemDeConsultaDeModelos> selecteds)
        {
            var selected = selecteds.Any(p => p.Codigo == modelo.Codigo);

            //var modeloViewModel = ModeloViewModel.From(modelo);

            //var viewModel = new ItemDeConsultaDeModeloViewModel
            //{
            //    Selected = selected,
            //    Modelo = modeloViewModel,
            //};

            //return viewModel;

            return null;
        }
    }
}
