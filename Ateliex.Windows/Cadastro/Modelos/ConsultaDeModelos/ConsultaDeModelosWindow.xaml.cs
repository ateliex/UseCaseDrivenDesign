using Ateliex.Cadastro.Modelos.ConsultaDeModelos;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Ateliex.Cadastro.Modelos.ConsultaDeModelos
{
    public partial class ConsultaDeModelosWindow : Window
    {
        private readonly IConsultaDeModelos consultaDeModelos;

        public ConsultaDeModelosWindow(IConsultaDeModelos consultaDeModelos)
        {
            this.consultaDeModelos = consultaDeModelos;

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var parametros = new ParametrosDeConsultaDeModelos
            {

            };

            var resultado = consultaDeModelos.ConsultaModelos(parametros);

            var list = resultado.Itens.Select(p => ItemDeConsultaDeModeloViewModel.From(p, selecteds)).ToList();

            CollectionViewSource modelosViewSource = ((CollectionViewSource)(this.FindResource("modelosViewSource")));

            modelosViewSource.Source = list;
        }

        private IEnumerable<ItemDeConsultaDeModelos> selecteds;

        public void SetSelecteds(IEnumerable<ItemDeConsultaDeModelos> selecteds)
        {
            this.selecteds = selecteds;
        }

        public IEnumerable<ItemDeConsultaDeModelos> GetSelecteds()
        {
            var list = new List<ItemDeConsultaDeModelos>();

            foreach (var item in modelosDataGrid.Items)
            {
                var viewModel = item as ItemDeConsultaDeModeloViewModel;

                if (viewModel.Selected)
                {
                    list.Add(viewModel.Modelo);
                }
            }

            return list;
        }
    }
}
