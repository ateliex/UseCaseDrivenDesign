using System.Windows.Controls;

namespace Ateliex.Modules.Decisoes.Comerciais.PlanejamentoComercial
{
    public class PlanoComercialValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            //PlanoComercialViewModel viewModel = (value as BindingGroup).Items[0] as PlanoComercialViewModel;

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
