using System;

namespace Ateliex.Modules.Decisoes.Comerciais
{
    public interface IConsultaDePlanosComerciais
    {
        PlanoComercial[] ConsultaPlanosComerciais(SolicitacaoDeConsultaDePlanosComerciais solicitacao);

        PlanoComercial[] ObtemObservavelDePlanosComerciais();
    }

    public class SolicitacaoDeConsultaDePlanosComerciais
    {

    }
}
