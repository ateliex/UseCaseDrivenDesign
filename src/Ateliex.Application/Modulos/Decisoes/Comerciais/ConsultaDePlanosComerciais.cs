using System;

namespace Ateliex.Modulos.Decisoes.Comerciais.ConsultaDePlanosComerciais
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
