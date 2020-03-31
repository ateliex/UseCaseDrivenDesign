extern alias business;

using System;
using modelos = business::Ateliex.Cadastro.Modelos;

namespace Ateliex.Cadastro.Modelos.ConsultaDeModelos
{
    public class ServicoDeConsultaDeModelos : IConsultaDeModelos
    {
        public modelos.Modelo[] ConsultaModelos()
        {
            throw new NotImplementedException();
        }
    }
}
