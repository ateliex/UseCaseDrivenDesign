using Ateliex.Modules.Cadastro.Modelos;
using Ateliex.Modules.Cadastro.Modelos.ConsultaDeModelos;
using Ateliex.Modules.Decisoes.Comerciais.ConsultaDePlanosComerciais;
using System.Collections.Generic;
using System.Windows;

namespace Ateliex.Modules.Decisoes.Comerciais.PlanejamentoComercial
{
    public partial class PlanejamentoComercialWindow
    {
        private readonly IConsultaDePlanosComerciais consultaDePlanosComerciais;

        private readonly IConsultaDeModelos consultaDeModelos;

        public PlanejamentoComercialWindow(IConsultaDePlanosComerciais consultaDePlanosComerciais, IConsultaDeModelos consultaDeModelos)
        {
            InitializeComponent();

            this.consultaDePlanosComerciais = consultaDePlanosComerciais;

            this.consultaDeModelos = consultaDeModelos;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //var planosComerciais = await consultaDePlanosComerciais.ObtemObservavelDePlanosComerciais();

            //var list = planosComerciais.Select(p => PlanoComercialViewModel.From(p)).ToList();

            //var observableCollection = new PlanosComerciaisObservableCollection(
            //    planosComerciaisService,                
            //    list
            //);

            //planosComerciaisBindingSource.DataSource = bindingList;

            //observableCollection.StatusChanged += SetStatusBar;

            //CollectionViewSource planosComerciaisViewSource = ((CollectionViewSource)(this.FindResource("planosComerciaisViewSource")));

            //planosComerciaisViewSource.Source = observableCollection;
        }

        //void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        //{
        //    e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        //}

        private void SetStatusBar(string value)
        {
            statusBarLabel.Content = value;

            //statusBarTimer.Enabled = true;
        }

        private void AdicionarModeloButton_Click(object sender, RoutedEventArgs e)
        {
            var consultaDeModelosWindow = new ConsultaDeModelosWindow(
                consultaDeModelos
            );

            var selecteds = GetSelectedItens();

            //consultaDeModelosWindow.SetSelecteds(selecteds);

            consultaDeModelosWindow.ShowDialog();

            var planoComercial = planosComerciaisDataGrid.CurrentItem as ItemDePlanoComercial;

            var modelos = consultaDeModelosWindow.GetSelecteds();

            foreach (var modelo in modelos)
            {
                //if (!planoComercial.Itens.Contains(modelo))
                //{
                //    planoComercial.Itens.AdicionaItem(modelo);
                //}
            }
        }

        private IEnumerable<ItemDePlanoComercial> GetSelectedItens()
        {
            var list = new List<ItemDePlanoComercial>();

            foreach (var item in itensDataGrid.Items)
            {
                var viewModel = item as ItemDePlanoComercial;

                //list.Add(viewModel.Modelo);
            }

            return list;
        }
    }
}
