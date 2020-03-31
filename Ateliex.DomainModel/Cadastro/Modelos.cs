extern alias business;

using modelos = business::Ateliex.Cadastro.Modelos;

namespace Ateliex.Cadastro.Modelos
{
    public class CodigoDeModelo
    #region Business
        : modelos.CodigoDeModelo
    #endregion
    {
        public string Valor { get; }
    }

    public class Modelo
    #region Business
        : modelos.Modelo
    #endregion
    {
        public CodigoDeModelo CodigoDeModelo { get; }

        public string Nome { get; }

        #region Business
        modelos.CodigoDeModelo modelos.Modelo.CodigoDeModelo => CodigoDeModelo;
        #endregion
    }
}
