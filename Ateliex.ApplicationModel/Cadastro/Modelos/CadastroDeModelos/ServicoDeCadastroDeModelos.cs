extern alias business;
extern alias uc;

using System;
using cadastroDeModelos = uc::Ateliex.Cadastro.Modelos.CadastroDeModelos;
using modelos = business::Ateliex.Cadastro.Modelos;

namespace Ateliex.Cadastro.Modelos.CadastroDeModelos
{
    public class ServicoDeCadastroDeModelos
    #region UC
        : cadastroDeModelos.CadastroDeModelos
    #endregion
    {
        public RespostaDeCadastroDeModelo CadastraModelo(SolicitacaoDeCadastroDeModelo solicitacao)
        {
            throw new NotImplementedException();
        }

        #region UC
        cadastroDeModelos.RespostaDeCadastroDeModelo cadastroDeModelos.CadastroDeModelos.CadastraModelo(cadastroDeModelos.SolicitacaoDeCadastroDeModelo solicitacao)
        {
            //return CadastraModelo(solicitacao);

            throw new NotImplementedException();
        }
        #endregion
    }

    public class SolicitacaoDeCadastroDeModelo
    #region UC
        : cadastroDeModelos.SolicitacaoDeCadastroDeModelo
    #endregion
    {
        public string Nome { get; set; }
    }

    public class RespostaDeCadastroDeModelo
    #region UC
        : cadastroDeModelos.RespostaDeCadastroDeModelo
    #endregion
    {
        public CodigoDeModelo CodigoCadastrado { get; set; }

        #region UC
        modelos.CodigoDeModelo cadastroDeModelos.RespostaDeCadastroDeModelo.CodigoCadastrado => CodigoCadastrado;
        #endregion
    }
}
