using System.Windows.Controls;

namespace Ateliex.Modulos.Cadastro.Modelos.CadastroDeModelos
{
    public class ModeloValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            //ModeloViewModel viewModel = (value as BindingGroup).Items[0] as ModeloViewModel;

            //if (viewModel.HasErrors)
            //{
            //    return new ValidationResult(false, viewModel.Error);
            //}
            //else
            //{
                return ValidationResult.ValidResult;
            //}
        }
    }
}
