using Ateliex.Cadastro.Modelos.ConsultaDeModelos;
using Ateliex.Decisoes.Comerciais;
using Ateliex.Decisoes.Comerciais.ConsultaDePlanosComerciais;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace Ateliex
{
    public partial class MainWindow
    {
        private readonly IServiceProvider serviceProvider;

        public MainWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            this.serviceProvider = serviceProvider;
        }

        private void CadastroDeModelosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var modelosWindow = serviceProvider.GetRequiredService<ModelosWindow>();

            modelosWindow.Show();
        }

        private void PlanejamentoComercialMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var planosComerciaisForm = serviceProvider.GetRequiredService<PlanosComerciaisWindow>();

            planosComerciaisForm.Show();
        }
    }
}
