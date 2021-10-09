using System;

namespace Ateliex.Modules.Decisoes.Comerciais
{
    public interface ConsultaDePlanosComerciais
    {
        PlanoComercial[] ConsultaPlanosComerciais(SolicitacaoDeConsultaDePlanosComerciais solicitacao);

        PlanoComercial[] ObtemObservavelDePlanosComerciais();
    }

    public class SolicitacaoDeConsultaDePlanosComerciais
    {

    }
}
