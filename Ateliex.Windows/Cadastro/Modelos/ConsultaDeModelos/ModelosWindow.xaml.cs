using Ateliex.Cadastro.Modelos.CadastroDeModelos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using System.Windows.Data;

namespace Ateliex.Cadastro.Modelos.ConsultaDeModelos
{
    public partial class ModelosWindow
    {
        private readonly IConsultaDeModelos consultaDeModelos;

        private readonly IServiceProvider serviceProvider;

        public ModelosWindow(IServiceProvider serviceProvider, IConsultaDeModelos consultaDeModelos)
        {
            InitializeComponent();

            this.serviceProvider = serviceProvider;

            this.consultaDeModelos = consultaDeModelos;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var parametros = new ParametrosDeConsultaDeModelos
            {

            };

            var resultado = consultaDeModelos.ConsultaModelos(parametros);

            CollectionViewSource modelosViewSource = ((CollectionViewSource)(this.FindResource("modelosViewSource")));

            modelosViewSource.Source = resultado.Itens;
        }

        private void SetStatusBar(string value)
        {
            statusBarLabel.Content = value;

            //statusBarTimer.Enabled = true;
        }

        private void AdicionarModeloButton_Click(object sender, RoutedEventArgs e)
        {
            var modeloWindow = serviceProvider.GetRequiredService<ModeloWindow>();

            modeloWindow.Show();
        }
    }
}
