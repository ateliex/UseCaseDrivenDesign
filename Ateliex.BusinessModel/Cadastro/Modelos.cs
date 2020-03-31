namespace Ateliex.Cadastro.Modelos
{
    public interface CodigoDeModelo
    {
        string Valor { get; }
    }

    public interface Modelo
    {
        CodigoDeModelo CodigoDeModelo { get; }

        string Nome { get; }
    }
}
