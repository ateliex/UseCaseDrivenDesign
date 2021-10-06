using Ateliex.Modulos.Cadastro.Modelos.ConsultaDeModelos;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Ateliex.Modulos.Cadastro.Modelos.ConsultaDeModelos
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
            var solicitacao = new SolicitacaoDeConsultaDeModelos
            {

            };

            var modelos = consultaDeModelos.ConsultaModelos(solicitacao);

            var list = modelos.Select(p => ItemDeConsultaDeModeloViewModel.From(p, selecteds)).ToList();

            CollectionViewSource modelosViewSource = ((CollectionViewSource)(this.FindResource("modelosViewSource")));

            modelosViewSource.Source = list;
        }

        private IEnumerable<Modelo> selecteds;

        public void SetSelecteds(IEnumerable<Modelo> selecteds)
        {
            this.selecteds = selecteds;
        }

        public IEnumerable<Modelo> GetSelecteds()
        {
            var list = new List<Modelo>();

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
