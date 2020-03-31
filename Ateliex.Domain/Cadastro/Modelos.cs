namespace Ateliex.Cadastro.Modelos
{
    public class CodigoDeModelo
    {
        public string Valor { get; }
    }

    public class Modelo
    {
        public CodigoDeModelo CodigoDeModelo { get; }

        public string Nome { get; }
    }

    internal interface IRepositorioDeModelos
    {
        Modelo ObtemModelo(CodigoDeModelo codigo);
    }
}
