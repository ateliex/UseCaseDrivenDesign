extern alias business;
extern alias uc;

using System;
using consultaDeModelos = uc::Ateliex.Cadastro.Modelos.ConsultaDeModelos;
using modelos = business::Ateliex.Cadastro.Modelos;

namespace Ateliex.Cadastro.Modelos.ConsultaDeModelos
{
    public class ServicoDeConsultaDeModelos
    #region UC
        : consultaDeModelos.ConsultaDeModelos
    #endregion
    {
        public Modelo[] ConsultaModelos()
        {
            throw new NotImplementedException();
        }

        #region UC
        modelos.Modelo[] consultaDeModelos.ConsultaDeModelos.ConsultaModelos()
        {
            return ConsultaModelos();
        }
        #endregion
    }
}
