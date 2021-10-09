using System;
using System.Windows;

namespace Ateliex.Modules.Cadastro.Modelos.CadastroDeModelos
{
    public partial class ModeloWindow : Window
    {
        private readonly ICadastroDeModelos cadastroDeModelos;

        public ModeloWindow(ICadastroDeModelos cadastroDeModelos)
        {
            InitializeComponent();

            this.cadastroDeModelos = cadastroDeModelos;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            codigoTextBox.Text = Guid.NewGuid().ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var solicitacao = new SolicitacaoDeCadastroDeModelo
            {
                Codigo = codigoTextBox.Text,
                Nome = nomeTextBox.Text
            };

            var resposta = cadastroDeModelos.CadastraModelo(solicitacao);
        }
    }
}
